using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.System;
using Assets.Script.Manager;
using UnityEngine;
using RootLibrary;
using Assets.Plugins.Script.BaseClass.Active;

namespace Assets.Script.Manager
{
    public class ColliderManager : ConfigActor<ColliderManager>
    {


        public ColliderType colliderType;

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("获得武器");
            int id;
            int.TryParse(other.gameObject.name,out id);
            switch (colliderType)
            {
                case ColliderType.Weapon_DaoQi:
                    WeaponManager.Instance.CreateWeapon(id);
                    break;
                case ColliderType.FuLu:

                    break;
            }
            MessageManager.Instance.ShowMessage("获得"+other.gameObject.name);
            Destroy(this);
        }
        private void OnTriggerExit(Collider other)
        {
            
        }


    }
}
