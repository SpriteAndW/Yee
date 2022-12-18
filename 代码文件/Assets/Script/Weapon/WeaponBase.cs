using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Characters;
using Assets.Script.Manager;
using UnityEngine;

namespace Assets.Script.Weapon
{
    public class WeaponBase : Actor, IWeapon
    {
        //有空把数据弄进ScriptableObject里🤬
        [Header("攻击伤害")] public float AttackDamage;
        [Header("攻击范围")] public float AttackRadius;

        [Header("攻击音效（随机播放）")] public List<int> HitClips = new();

        //有空把数据弄进ScriptableObject里🤬
        [Header("Id")] public int Id;
        [Header("拥有者")] public Role OwnRole;

        public virtual void Init()
        {
        }

        public virtual void Employ()
        {
        }

        public virtual void Attack()
        {
            FightManager.Instance.DoDamageForEach(FightManager.Instance.GetVictims(this), AttackDamage);
        }
    }
}