using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;
using Assets.Script.Manager;
using UnityEngine;

namespace Assets.Script.Portals
{
    public abstract class PortalBase : Actor, IPortal
    {
        public int Id;
        public PortalType PortalOfType;
        public Transform PortalRole;
        public Vector3 PortalPoint;
        public virtual void Register()
        {
        }

        public virtual void OnTriggerAction(Transform t)
        {
            Debug.Log("踩到传送门");
            PortalRole = t;
        }

        public virtual void Start()
        {
            Register();
        }
    }
}