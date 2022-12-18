using Assets.Plugins.System;
using Assets.Script.Manager;
using UnityEngine;
using static Assets.Script.Manager.PortalManager;

namespace Assets.Script.Portals
{
    public class PortalB : PortalBase
    {
        public SetPosB SetPosBAction;

        public override void Register()
        {
            base.Register();
            PortalManager.Instance.Register(this);
        }

        public override void Start()
        {
            PortalOfType = PortalType.AToB;
            if (PortalPoint == default) PortalPoint = transform.position;
            base.Start();
        }

        public override void OnTriggerAction(Transform t)
        {
            base.OnTriggerAction(t);
            SetPosBAction?.Invoke(this, t);
            PortalRole = null;
        }
    }
}