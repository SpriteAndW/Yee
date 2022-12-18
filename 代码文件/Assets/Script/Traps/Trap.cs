using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Manager;
using DG.Tweening;
using UnityEngine;

namespace Assets.Script.Traps
{
    public class Trap : Actor, ITrap
    {
        [Header("交互Id")] public int ApplyId;
        [Header("交互类型")] public TrapType ApplyTrapOfType;
        [Header("伤害")] public float Damage;
        [Header("委托")] public TrapManager.TrapAction DoActions;
        [Header("影响范围")] public float EffectRange;
        [Header("影响时间")] public float EffectTime;
        [Header("Id")] public int Id;
        [Header("正在行动")] public bool IsAction;
        [Header("升起距离")] public float RiseDistance;
        [Header("升起时间")] public float RiseTime;
        [Header("开始位置")] public Vector3 StartPos;
        [Header("类型")] public TrapType TrapOfType;

        /// <summary>
        ///     注册接口
        /// </summary>
        public void Register()
        {
            TrapManager.Instance.Register(this);
        }

        public void OnTriggerAction()
        {
            if (!IsAction)
            {
                IsAction = true;
                DoActions?.Invoke(this);
            }
        }

        public void ReSet()
        {
            IsAction = false;
            transform.DOMove(StartPos, 1f);
        }

        public void Start()
        {
            StartPos = transform.position;
            Register();
        }
    }
}