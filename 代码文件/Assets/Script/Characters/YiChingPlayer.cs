using System.Collections;
using Assets.Plugins.System;
using Assets.Script.FootStep;
using Assets.Script.Manager;
using RootLibrary;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

namespace Assets.Script.Characters
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class YiChingPlayer : Role
    {
        public delegate void Actions();

        public delegate void Inputs();

        private Transform _cameraTransform;

        private Vector3 _offset;

        public NavMeshAgent Agent;
        public Inputs CameraInput;
        public FootStepBase FootStep;
        public int Magic;
        public Inputs MoveInput;
        public Vector3 MoveTarget;
        public Rigidbody Rb;
        public Actions StepActions;
        public Transform WeaponList;

        public GameObject[] fuluPrefab;
        public bool isMiniGame;

        public override void Awake()
        {
            base.Awake();
            tag = "Player";
        }

        public void Update()
        {
            MoveInput?.Invoke();
            StepActions?.Invoke();
            if (!isMiniGame)
            {
                CameraInput?.Invoke();
            }
        }

        public void UpdateNavAgent()
        {
            if (InputManager.InputButtonDic[InputsType.MouseRightButtonDown]())
            {
                Agent.isStopped = false;
                AnimatorManager.Instance.SetAnimatiorTrigger(GetComponent<Animator>(), "StartWalk");
                AnimatorManager.Instance.SetAnimatorBool(GetComponent<Animator>(), "Walk", true);
                AnimatorManager.Instance.ResetAnimartorTrigger(GetComponent<Animator>(), "StopWalk");
            }

            if (InputManager.InputButtonDic[InputsType.MouseRightButton]())
            {
                MoveTarget = LibV.GetMouseRayPosition();
                Agent.SetDestination(MoveTarget);
                AnimatorManager.Instance.SetAnimatorBool(GetComponent<Animator>(), "Walk", true);
            }

            if (InputManager.InputButtonDic[InputsType.MouseRightButtonUp]())
            {
                Agent.isStopped = true;
                AnimatorManager.Instance.SetAnimatorBool(GetComponent<Animator>(), "Walk", false);
                AnimatorManager.Instance.SetAnimatiorTrigger(GetComponent<Animator>(), "StopWalk");
                AnimatorManager.Instance.ResetAnimartorTrigger(GetComponent<Animator>(), "StartWalk");
            }
        }

        public void JudgeAttack()
        {
            if (InputManager.InputButtonDic[InputsType.MouseLeftButton]())
            {
                AnimatorManager.Instance.SetAnimatiorTrigger(GetComponent<Animator>(), "TaoMu");
            }
        }

        public void UpdateAnim()
        {


        }

        public void CameraFollow()
        {
            _cameraTransform.LerpFollow(transform.position, _offset, 0.85f);
        }

        public void DoFootStep()
        {
            /*            if (MoveTarget.Distance3(transform.position) >= 0.5f ) FootStep.DoPlay();
                        else
                            FootStep.DoStop();*/
        }

        public void Start()
        {
            MoveTarget = transform.position;
            FootStep = GetComponent<FootStepBase>();
            if (FootStep != null) StepActions += DoFootStep;
            _cameraTransform = Camera.main.transform;
            _offset = transform.position - _cameraTransform.position;
            Agent = GetComponent<NavMeshAgent>();
            MoveInput += UpdateNavAgent;
            MoveInput += JudgeAttack;
            CameraInput += CameraFollow;
            PlayerManager.Instance.Player = this;
        }
    }
}