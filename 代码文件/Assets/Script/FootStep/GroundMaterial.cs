using Assets.Plugins.Script.BaseClass.Active;
using Assets.Plugins.System;

namespace Assets.Script.FootStep
{
    public class GroundMaterial : Actor, IFootStep
    {
        public GroundType GroundOfType;
        public int Id;

        public int GetFootStepId()
        {
            return Id;
        }

        public GroundType GetFootStepType()
        {
            return GroundOfType;
        }
    }
}