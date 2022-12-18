using System.Collections.Generic;
using Assets.Plugins.System;
using UnityEngine;

namespace Assets.Script.Data
{
    [CreateAssetMenu(fileName = "WeaponDatas", menuName = "ScriptableObject/武器数据", order = 0)]
    public class WeaponDataScriptObject : ScriptableObject
    {
        public List<WeaponDataInit> WeaponDataInits = new();
    }
}