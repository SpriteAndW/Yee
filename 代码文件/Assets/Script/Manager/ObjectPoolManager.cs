using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using UnityEngine;

namespace Assets.Script.Manager
{
    public sealed class ObjectPoolManager : HideActor<ObjectPoolManager>
    {
        [Header("特效池")] public Dictionary<int, List<GameObject>> EffectPool = new();
        [Header("物品池")] public Dictionary<int, List<GameObject>> ItemPool = new();
        [Header("池")] public Dictionary<ObjectType, Dictionary<int, List<GameObject>>> Pool = new();
        [Header("技能池")] public Dictionary<int, List<GameObject>> SkillPool = new();
        [Header("UI池")] public Dictionary<int, List<GameObject>> UIPool = new();
        [Header("合成水果（幻珠）池")] public Dictionary<int, List<GameObject>> FruitPool = new();

        public ObjectPoolManager()
        {
            Init();
        }

        /// <summary>
        ///     初始化
        /// </summary>
        public void Init()
        {
            Pool.Add(ObjectType.Skill, SkillPool);
            Pool.Add(ObjectType.Item, ItemPool);
            Pool.Add(ObjectType.Effect, EffectPool);
            Pool.Add(ObjectType.UI, UIPool);
            Pool.Add(ObjectType.Fruits, FruitPool);
        }

        /// <summary>
        ///     从池中获取
        /// </summary>
        public GameObject GetByPool(ObjectType type, int id)
        {
            if (!Pool[type].ContainsKey(id) || Pool[type][id].Count <= 0)
            {
                //已空，移除键
                Pool[type].Remove(id);
                return null;
            }

            var t = Pool[type][id][0];
            Pool[type][id].RemoveAt(0);
            return t;
        }

        /// <summary>
        ///     添加到池里
        /// </summary>
        public void AddToPool(ObjectType type, int id, GameObject obj)
        {
            //如果包含键，添加到列表里
            if (Pool[type].ContainsKey(id))
            {
                obj.SetActive(false);
                Pool[type][id].Add(obj);
            }
            else
            {
                //新初始化一个列表，把物体添加进池里
                var list = new List<GameObject> { obj };
                //添加进字典
                Pool[type].Add(id, list);
                obj.SetActive(false);
            }
        }


        /// <summary>
        ///     清空池
        /// </summary>
        public void ClearPool(Dictionary<int, List<GameObject>> dic)
        {
            foreach (var t in dic) t.Value.Clear();
        }
    }
}