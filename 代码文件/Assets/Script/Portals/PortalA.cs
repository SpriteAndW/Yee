using Assets.Plugins.System;
using Assets.Script.Manager;
using UnityEngine;
using static Assets.Script.Manager.PortalManager;

namespace Assets.Script.Portals
{
    public class PortalA : PortalBase
    {
        public int PortalBId;
        public PortalToB PortalToAction;

        public override void Register()
        {
            base.Register();
            PortalManager.Instance.Register(this);
        }

        public override void Start()
        {
            PortalOfType = PortalType.AToB;
            base.Start();
        }

        public override void OnTriggerAction(Transform t)
        {
            base.OnTriggerAction(t);
            Debug.Log("A执行");
            PortalToAction?.Invoke(this, PortalBId);
            PortalRole = null;
        }
    }
}