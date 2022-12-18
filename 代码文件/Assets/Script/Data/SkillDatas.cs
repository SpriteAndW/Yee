using System.Collections.Generic;
using Assets.Plugins.System;
using UnityEngine;

namespace Assets.Script.Data
{
    [CreateAssetMenu(fileName = "SkillDatas", menuName = "ScriptableObject/Skill数据", order = 0)]
    public class SkillDatas : ScriptableObject
    {
        public List<SkillData> SkillsDatas;

        public SkillData GetSkillData(int id)
        {
            return SkillsDatas.Find( i=> i.Id ==id);
        }
    }
}