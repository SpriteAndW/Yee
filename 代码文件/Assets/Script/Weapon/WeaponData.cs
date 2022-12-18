using System;
using Assets.Plugins.System;

namespace Assets.Script.Weapon
{
    [Serializable]
    public class WeaponData
    {
        public int Id;
        public WeaponDataInit InitData;

        public WeaponData()
        {
            Init();
        }

        public void Init()
        {
        }
    }
}