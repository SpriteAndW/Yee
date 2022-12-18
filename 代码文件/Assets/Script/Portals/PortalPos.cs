using UnityEngine;

namespace Assets.Script.Portals
{
    public class PortalPos : PortalBase
    {
        public int PortalPosId;
        public Vector3 Pos;

        public override void OnTriggerAction(Transform t)
        {
            base.OnTriggerAction(t);
            PortalRole.position = Pos;
            PortalRole = null;
        }
    }
}