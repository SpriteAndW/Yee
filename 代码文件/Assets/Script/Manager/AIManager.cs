using System;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using Assets.Script.AI;
using UnityEngine;

namespace Assets.Script.Manager
{
    public sealed class AIManager : HideActor<AIManager>
    {
        [Header("AI")] public List<AIBase> AIs = new();
        [Header("总控移动类型")] public AIManagerMoveType AllMoveType = AIManagerMoveType.Idle;

        /// <summary>
        ///     AI移动
        /// </summary>
        public void AIMove()
        {
            switch (AllMoveType)
            {
                case AIManagerMoveType.Default:
                    break;
                case AIManagerMoveType.Idle:
                    Idling();
                    break;
                case AIManagerMoveType.Roaming:
                    Roaming();
                    break;
                case AIManagerMoveType.Chasing:
                    Chasing();
                    break;
                case AIManagerMoveType.Back:
                    Back();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        ///     呆滞
        /// </summary>
        public void Idling()
        {
            foreach (var t in AIs)
                t.Idle();
        }

        /// <summary>
        ///     漫游
        /// </summary>
        public void Roaming()
        {
            foreach (var t in AIs)
                t.RandomRoaming();
        }

        /// <summary>
        ///     追逐
        /// </summary>
        public void Chasing()
        {
            foreach (var t in AIs)
                t.ChaseTarget();
        }

        /// <summary>
        ///     返回初始位置
        /// </summary>
        public void Back()
        {
            foreach (var t in AIs)
            {
                 t.Back();
            }
        }
    }
}