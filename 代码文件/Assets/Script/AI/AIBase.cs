using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Characters;
using Assets.Script.Manager;
using RootLibrary;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Script.AI
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AIBase : Actor, IAI
    {
        //AI感觉委托
        public delegate void AIStimulatorDelegate();

        [Header("AI感觉")] public Dictionary<AIStimulator, bool> AISense = new()
        {
            { AIStimulator.Hear, false },
            { AIStimulator.Sight, false },
            { AIStimulator.Pain, false }
        };

        [Header("AI感觉行动")] public Dictionary<AIStimulator, AIStimulatorDelegate> AISenseAction = new();
        [Header("听觉")] public AIStimulatorDelegate HearHandler;

        [Header("AI移动类型")] public AIMoveType MoveType = AIMoveType.Default;
        [Header("状态")] public AIBuffState AIBuffState = AIBuffState.Default;
        public Sprite[] Sprites;
        [Header("导航")] public NavMeshAgent NavAgent;
        [Header("动画")] public Animator Anim;
        [Header("痛觉")] public AIStimulatorDelegate PainHandler;
        [Header("视觉")] public AIStimulatorDelegate SightHandler;

        [Header("目标")] public Transform Target;
        [Header("随机巡逻范围")] public float RoameRange = 5;
        [Header("技能距离")] public float SkillRange = 10f;
        [Header("技能间隔")] public float SkillCD = 6f;
        [Header("攻击距离")] public float AttackRange = 5f;
        [Header("攻击间隔")] public float AttackCD = 2f;
        [Header("攻击伤害")] public int AttackDamage = 20;
        [Header("听到玩家位置")] public Vector3 HearPos;
        [Header("远程攻击预制体")] public GameObject SkillGameObj;
        [Header("等待时间")] public float WaitTime = 3;
        private Vector3 _startPos; //初始位置
        private float _lastAttackTime;
        private float _lastSkillTime;
        private float startNavAgentSpeed;
        private float realWaitTime;
        private Vector3 wayPoint;
        private Vector3 lastPos;
        private float tempTime;

        #region Common

        public void Awake()
        {
            HearHandler += ToHearPos;
            SightHandler += ChaseTarget;
            PainHandler += ChaseTarget;

            AISenseAction.Add(AIStimulator.Hear, HearHandler);
            AISenseAction.Add(AIStimulator.Sight, SightHandler);
            AISenseAction.Add(AIStimulator.Pain, PainHandler);

            _startPos = transform.position;
        }


        private void Update()
        {
            if (AIBuffState == AIBuffState.Puzzle || MoveType == AIMoveType.Death)
            {
                Idle();
            }
            else
            {
                FoundPlayer();
                SenseAction();
                SwitchMoveType();
            }

            if (_lastAttackTime > -1)
            {
                _lastAttackTime -= Time.deltaTime;
            }

            if (_lastSkillTime > -1)
            {
                _lastSkillTime -= Time.deltaTime;
            }
        }

        /// <summary>
        ///     改变移动状态
        /// </summary>
        public void SwitchMoveType()
        {
            switch (MoveType)
            {
                case AIMoveType.Default:
                case AIMoveType.Idle:
                case AIMoveType.Roaming:
                    RandomRoaming();
                    break;
                case AIMoveType.Chasing:
                    NavAgent.speed = startNavAgentSpeed * 1.5f;
                    break;
            }
        }

        /// <summary>
        ///     改变敌人状态(头顶图片)
        /// </summary>
        /// <param name="aiBuffState"></param>
        public void ChangeBuffState(AIBuffState aiBuffState)
        {
            var spriteObj = GetComponentInChildren<SpriteRenderer>();
            switch (aiBuffState)
            {
                case AIBuffState.Default:
                    spriteObj.enabled = false;
                    break;
                case AIBuffState.Burn:
                    spriteObj.enabled = true;
                    spriteObj.sprite = Sprites[0];
                    break;
                case AIBuffState.Dizz:
                    spriteObj.enabled = true;
                    spriteObj.sprite = Sprites[1];
                    break;
                case AIBuffState.Puzzle:
                    break;
            }
        }

        public void SenseAction()
        {
            if (AISense[AIStimulator.Pain])
            {
                AISenseAction[AIStimulator.Pain]?.Invoke();
            }
            else
            {
                if (AISense[AIStimulator.Sight])
                {
                    AISenseAction[AIStimulator.Sight]?.Invoke();
                }
                else
                {
                    if (AISense[AIStimulator.Hear])
                    {
                        AISenseAction[AIStimulator.Hear]?.Invoke();
                    }
                    else
                    {
                        Back();
                    }
                }
            }
        }

        public void Start()
        {
            NavAgent = GetComponent<NavMeshAgent>();
            Anim = GetComponent<Animator>();
            Register();
            startNavAgentSpeed = NavAgent.speed;
            wayPoint = transform.position;
        }


        public void Register()
        {
            if (this.In(AIManager.Instance.AIs)) return;
            AIManager.Instance.AIs.Add(this);
        }

        public void Delete()
        {
            if (!this.In(AIManager.Instance.AIs)) return;
            AIManager.Instance.AIs.Remove(this);
        }

        public void Idle()
        {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Chase", false);
        }

        public void Back()
        {
            if (Vector3.Distance(transform.position, _startPos) > RoameRange * 1.5f)
            {
                NavAgent.SetDestination(_startPos);
            }
            else
            {
                MoveType = AIMoveType.Roaming;
            }
        }

        public void RandomRoaming()
        {
            // NavAgent.SetDestination(transform.position.NextCircularPoint3(RoameRange));
            if (Vector3.Distance(wayPoint, transform.position) <= NavAgent.stoppingDistance) //返回A与B之间的距离,判断是否到了随机巡逻点
            {
                NavAgent.isStopped = true;

                Anim.SetBool("Walk", false);

                if (realWaitTime > 0)
                {
                    realWaitTime -= Time.deltaTime;
                }
                else
                {
                    if (RoameRange != 0)
                    {
                        // GetNewWayPoint();
                        wayPoint = new Vector3(transform.position.NextCircularPoint3(RoameRange).x,
                            transform.position.y, transform.position.NextCircularPoint3(RoameRange).z);
                    }
                }
            }
            else
            {
                if (Time.time - tempTime > 3)
                {
                    tempTime = Time.time;
                    //判断是否有移动
                    if ((transform.position - lastPos).sqrMagnitude <= 0.5f)
                    {
                        wayPoint = new Vector3(transform.position.NextCircularPoint3(RoameRange).x,
                            transform.position.y, transform.position.NextCircularPoint3(RoameRange).z);
                    }

                    lastPos = transform.position;
                }


                Anim.SetBool("Walk", true);
                NavAgent.speed = startNavAgentSpeed;
                NavAgent.isStopped = false;
                NavAgent.destination = wayPoint;
            }
        }

        public void ToHearPos()
        {
            NavAgent.SetDestination(HearPos);

            if (Vector3.Distance(transform.position, HearPos) <= 1)
            {
                AISense[AIStimulator.Hear] = false;
            }
        }

        public void ChaseTarget()
        {
            //敌人在视距1.5倍会会持续追击玩家
            if (Vector3.Distance(Target.position, transform.position) <= ViewDistance * 1.5f &&
                !AISense[AIStimulator.Pain])
            {
                Anim.SetBool("Chase", true);

                if (CanSkillAttack(SkillCD, SkillRange) && SkillCD != 0 && SkillGameObj != null)
                {
                    StartCoroutine(SkillAttack());
                }
                else if (CanSimpleAttack(AttackCD, AttackRange))
                {
                    SimpleAttack();
                }

                if (Vector3.Distance(Target.position, transform.position) <= NavAgent.stoppingDistance)
                {
                    NavAgent.isStopped = true;
                }
                else
                {
                    NavAgent.SetDestination(Target.position);
                    NavAgent.isStopped = false;
                    MoveType = AIMoveType.Chasing;
                }
            }
            else if (!AISense[AIStimulator.Pain])
            {
                AISense[AIStimulator.Sight] = false;
                AISense[AIStimulator.Hear] = false;
                Anim.SetBool("Chase", false);
            }
        }

        private bool CanSkillAttack(float skillCD, float skillRange)
        {
            if (_lastSkillTime <= 0 && Vector3.Distance(Target.position, transform.position) <= skillRange)
            {
                _lastSkillTime = skillCD;
                return true;
            }

            return false;
        }

        private bool CanSimpleAttack(float attackCD, float attackRange)
        {
            if (_lastAttackTime <= 0 && Vector3.Distance(Target.position, transform.position) <= attackRange)
            {
                _lastAttackTime = attackCD;
                return true;
            }

            return false;
        }

        private IEnumerator SkillAttack()
        {
            NavAgent.speed = 0;
            Anim.SetTrigger("SkillAtk");
            yield return new WaitForSeconds(1f);
            var obj1 = Instantiate(SkillGameObj, transform.position + Vector3.up * 5, Quaternion.identity);
            NavAgent.speed = startNavAgentSpeed;
        }


        private void SimpleAttack()
        {
            if (Target.gameObject.CompareTag("Player"))
            {
                transform.LookAt(Target);

                Anim.SetTrigger("SimpleAtk");
                Target.gameObject.GetComponent<YiChingPlayer>().HP -= AttackDamage;
                

            }
        }

        #endregion

        #region Sight

        [Header("视距")] public float ViewDistance = 30;

        [Header("视角")] public float ViewAngle = 90;

        public void FoundPlayer()
        {
            var colliders = Physics.OverlapSphere(transform.position, ViewDistance); //敌人中心点，周围半径查找碰撞体 var表示一个数组

            foreach (var target in colliders)
            {
                if (target.CompareTag("Player"))
                {
                    //玩家拥有铁幻珠Buff,敌人无法看到玩家
                    if (PlayerManager.Instance.NowBuffStates.Contains(0))
                    {
                        return;
                    }

                    //敌人看到玩家
                    var dir = target.transform.position - transform.position;
                    var angle = Vector3.Angle(dir, transform.forward);
                    if (angle <= ViewAngle / 2)
                    {
                        if (Physics.Raycast(transform.position, dir, out var hit, ViewDistance))
                        {
                            Target = target.gameObject.transform;
                            AISense[AIStimulator.Sight] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// // 获得随机巡逻点
        /// </summary>
        void GetNewWayPoint()
        {
            realWaitTime = WaitTime;

            Vector3 random = transform.position.NextCircularPoint3(RoameRange);

            Vector3 randomPoint = new Vector3(_startPos.x + random.x, transform.position.y, _startPos.z + random.z);

            NavMeshHit hit;
            wayPoint = NavMesh.SamplePosition(randomPoint, out hit, RoameRange, 1) ? hit.position : transform.position;

            if (Vector3.Distance(transform.position, _startPos) > RoameRange * 2)
            {
                wayPoint = _startPos;
            }
        }

        /// <summary>
        ///     敌人巡逻范围
        /// </summary>
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, RoameRange);
            Gizmos.DrawWireSphere(transform.position, ViewDistance);
        }

        #endregion
    }
}