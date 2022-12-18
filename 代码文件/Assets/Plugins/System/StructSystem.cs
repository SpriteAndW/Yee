#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Plugins.System
{
    [Serializable]
    public struct EnemyBase //敌人
    {
        [Header("Id")] public int Id;
        [Header("名字")] public string Name;
        [Header("生命值")] public float HP;
        [Header("速度")] public float Speed;
    }

    [Serializable]
    public struct WeaponDataInit //武器初始数据
    {
        [Header("Id")] public int Id;
        [Header("攻击伤害")] public float AttackDamage;
        [Header("攻击范围")] public float AttackRadius;
        //[Header("拥有者")] public Role OwnRole;
        //[Header("攻击音效（随机播放）")] public List<int> HitClips = new();
        public Dictionary<int, int> CreateMaterials;
    }

    [Serializable]
    public struct PlayerData //玩家数据
    {
        public float HP;
        public int Magic;
        public Vector3 Pos;
    }

    [Serializable]
    public struct InventoryData //背包数据
    {
        public List<int> Ids;
        public List<int> Counts;
    }

    [Serializable]
    public struct SkillData //技能数据
    {
        [Header("Id")] public int Id;
        [Header("类型")] public SkillType Type;
        [Header("技能指示器类型")] public SkillIndictorType SkillIndictortype;
        [Header("所需解锁物品Id和数量")] public string[] NeededObjId;
        [Header("所需使用物品id和数量")] public string[] NeededUseId;
        [Header("所需状态id和数量")] public string[] NeededStateId;
        [Header("生成方式")] public SkillInstateType InstantType;
        [Header("预制体")] public GameObject SkillPrefab;
        [Header("冷却时间")] public float SkillCD;
        [Header("消耗")] public int Drain;
        [Header("速度")] public float Speed;
        [Header("伤害")] public float Damage;
        [Header("力度")] public float Force;
        [Header("持续时间")] public float Duration;
        [Header("特效")] public GameObject[] Effects;
        [Header("名字")] public string name;
        [Header("图像")] public Sprite image;
        [Header("介绍")] public string introduction;
    }

}