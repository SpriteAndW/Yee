using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Characters;
using Assets.Plugins.Script.BaseClass.Active;

namespace Assets.Script.Manager
{
    public class AttackManager : ConfigActor<AttackManager>
    {
        private int damage = 10;
        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Enemy")
            {
                other.GetComponent<EnemyBase>().ApplyDamage(damage);
            }

        }
        private void OnTriggerExit(Collider other)
        {

        }

    }
}