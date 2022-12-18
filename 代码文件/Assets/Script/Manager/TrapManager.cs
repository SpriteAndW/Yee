using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using Assets.Script.Traps;
using DG.Tweening;
using UnityEngine;

namespace Assets.Script.Manager
{
    public class TrapManager : HideActor<TrapManager>
    {
        public delegate void TrapAction(Trap t);

        public Dictionary<TrapType, Dictionary<int, Trap>> TrapDic = new()
        {
            { TrapType.Default, new Dictionary<int, Trap>() },
            { TrapType.Burning, new Dictionary<int, Trap>() },
            { TrapType.Spear, new Dictionary<int, Trap>() },
            { TrapType.CodeDoor, new Dictionary<int, Trap>() }
        };

        public void Register(Trap t)
        {
            if (TrapDic[t.TrapOfType].ContainsKey(t.Id)) return;
            TrapDic[t.TrapOfType].Add(t.Id, t);
            switch (t.TrapOfType)
            {
                case TrapType.Spear:
                    t.DoActions += Rise;
                    break;
                case TrapType.Default:
                    break;
                case TrapType.Burning:
                    t.DoActions += Burning;
                    break;
                case TrapType.CodeDoor:
                    t.DoActions += OpenCodeDoor;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public void Rise(Trap t)
        {
            Debug.Log("踩到机关了，嘻嘻");
            t.transform.DOLocalMoveY(t.StartPos.y + t.RiseDistance, t.RiseTime);
        }

        public void Burning(Trap t)
        {
            CoroutineManager.Instance.StartCoroutine(ContinueDamage(t));
        }

        public void OpenCodeDoor(Trap t)
        {
            if (TrapDic[t.ApplyTrapOfType].ContainsKey(t.ApplyId))
                TrapDic[t.ApplyTrapOfType][t.ApplyId].OnTriggerAction();
        }

        public IEnumerator ContinueDamage(Trap t)
        {
            var effectTime = t.EffectTime;
            while (effectTime > 0)
            {
                var collides = Physics.OverlapSphere(t.transform.position, t.EffectRange);
                foreach (var i in collides)
                    if (i.GetComponent<IFight>() != null)
                    {
                        var f = i.GetComponent<IFight>();
                        f.ApplyDamage(t.Damage);
                    }

                yield return new WaitForSeconds(0.5f);
                effectTime -= 0.5f;
            }
        }
    }
}