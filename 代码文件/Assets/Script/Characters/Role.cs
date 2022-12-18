using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Manager;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Script.Characters
{
    public class Role : Character, IFight
    {
        [Header("Id")] public int Id;
        [Header("当前生命值")] public float HP;
        [Header("最大生命值")] public float MaxHP;

        [Header("当前法术值")] public float MP;
        [Header("最大法术值")] public float MaxMP;

        [Header("类型")] public RoleType RoleOfType;
        [Header("速度")] public float Speed;
        [Header("生存状态")] public ExistState StateOfExist;
        [Header("战斗状态")] public FightState StateOfFight;
        [Header("动画状态")] public AnimState StateOFAnim;
        [Header("标签")] public List<UnitTag> Tags;

        /// <summary>
        ///     应用伤害
        /// </summary>
        public virtual void ApplyDamage(float damage)
        {
            if (StateOfExist != ExistState.Alive) return;
            switch (HP - damage)
            {
                case > 0:
                    HP -= damage;
                    StateOfFight = FightState.Damage;
                    break;
                case <= 0:
                    HP = 0;
                    StateOfExist = ExistState.Dead;
                    if(RoleOfType==RoleType.Player)
                    {
                        AnimatorManager.Instance.SetAnimatorBool(GetComponent<Animator>(), "Die", true);
                        RunTimeManager.Instance.Load();
                    }
                    break;
            }
            AudioManager.Instance.PlayByName(0,"2挥舞");
            AnimatorManager.Instance.SetAnimatiorTrigger(GetComponent<Animator>(),"Hit");
        }

        public void ApplyMp(int needMp)
        {
            switch(MP - needMp)
            {
                case > 0:
                    MP -= needMp;
                    break;
                case <= 0:
                    MP = 0;
                    break;
            }
        }

        /// <summary>
        ///     应用力
        /// </summary>
        public void ApplyForce(GameObject causer, float force)
        {
            var t = (new Vector3((transform.position-causer.transform.position).x,0,(transform.position - causer.transform.position).z)).normalized;
            transform.DOMove(transform.position + t * force, 1f);
        }

        public void ApplyMove(Vector3 targetDir,float Duration)
        {
            transform.DOMove(transform.position+targetDir, Duration);
        }

        public virtual void Awake()
        {
            tag = "Character";
        }
    }
}