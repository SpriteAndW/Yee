using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Script.Portals;
using UnityEngine;

namespace Assets.Script.Manager
{
    public class PortalManager : HideActor<PortalManager>
    {
        public delegate void PortalToB(PortalA t, int id);

        public delegate void SetPosB(PortalB t, Transform role);

        public Dictionary<int, PortalA> PortalADic = new();
        public Dictionary<int, PortalB> PortalBDic = new();
        public Dictionary<int, PortalPos> PortalPosDic = new();

        public void Register(PortalA t)
        {
            if (PortalADic.ContainsKey(t.Id)) return;
            t.PortalToAction += PortalFromAToB;
            PortalADic.Add(t.Id, t);
        }

        public void Register(PortalB t)
        {
            if (PortalBDic.ContainsKey(t.Id)) return;
            t.SetPosBAction += SetRolePos;
            PortalBDic.Add(t.Id, t);
        }

        public void PortalFromAToB(PortalA t, int id)
        {
            if (PortalADic.ContainsKey(t.Id)) PortalBDic[id].OnTriggerAction(t.PortalRole);
        }

        public void SetRolePos(PortalB t, Transform role)
        {
            role.transform.position = t.PortalPoint;
        }
    }
}