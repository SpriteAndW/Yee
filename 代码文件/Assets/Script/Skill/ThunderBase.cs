using Assets.Plugins.System;
using UnityEngine;
using Assets.Script.Skill;

namespace Assets.Script.Skill
{
    public class ThunderBase : SkillBase
    {
        public virtual void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("Character")) return;
            var t = other.GetComponent<IFight>();
            if (t == null) return;
            t.ApplyDamage(Data.Damage);
            t.ApplyForce(gameObject, Data.Force);
        }
    }
}