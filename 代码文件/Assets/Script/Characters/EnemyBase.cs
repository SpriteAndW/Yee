using System;
using Assets.Plugins.System;
using Assets.Script.AI;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Script.Characters
{
    public class EnemyBase : OtherRole
    {
        public override void Awake()
        {
            base.Awake();
            RoleOfType = RoleType.Enemy;
        }

        public override void ApplyDamage(float damage)
        {
            base.ApplyDamage(damage);
            if (HP <= 0)
            {
                GetComponent<Animator>().SetTrigger("Die");
                GetComponent<AIBase>().MoveType = AIMoveType.Death;
                GetComponent<NavMeshAgent>().enabled = false;
                GetComponent<Collider>().isTrigger = true;
            }
        }
    }
}