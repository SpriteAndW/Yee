using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using Assets.Script.Weapon;
using RootLibrary;
using UnityEngine;

namespace Assets.Script.Manager
{
    public class FightManager : HideActor<FightManager>
    {
        [Header("事件字典")] public Dictionary<int, Action<WeaponBase>> ActionDic = new();
        [Header("协程字典")] public Dictionary<int, IEnumerator> CoroutineDic = new();
        [Header("委托字典")] public Dictionary<int, Delegate> DelegateDic = new();

        public FightManager()
        {
            Init();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            ActionDic.Add(0, Slash);
        }

        /// <summary>
        ///     获得受害者
        /// </summary>
        public List<IFight> GetVictims(WeaponBase t)
        {
            var collides = Physics.OverlapSphere(t.transform.forward, t.AttackRadius);
            return (from collider in collides
                    where collider.GetComponent<IFight>() != null
                    select collider.GetComponent<IFight>()).ToList();
        }

        /// <summary>
        ///     受害者受到伤害
        /// </summary>
        public void DoDamageForEach(List<IFight> t, float damage)
        {
            foreach (var i in t) i.ApplyDamage(damage);
        }

        #region Action

        /// <summary>
        ///     斩击
        /// </summary>
        public void Slash(WeaponBase t)
        {
            AudioManager.Instance.PlayClip(3, t.HitClips.NextItem());
        }

        #endregion

        #region Coroutine

        public IEnumerator Combat(WeaponBase t, float combatTime)
        {
            while (combatTime >= 0)
            {
                var ray = new Ray(new Vector3(t.transform.position.x, t.transform.position.y, t.transform.position.z),
                    t.transform.forward);
                if (Physics.Raycast(ray, out var hit, MathV.Pi * 2.7f))
                {
                    var fight = hit.transform.GetComponent<IFight>();
                    fight?.ApplyDamage(20f);
                }

                yield return new WaitForSeconds(0.27f);
                combatTime -= 0.27f;
            }
        }

        #endregion
    }
}