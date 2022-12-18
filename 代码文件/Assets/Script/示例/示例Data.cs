using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.示例
{
    [CreateAssetMenu(fileName = "示例", menuName = "示例/示例数据", order = 0)]
    public class 示例Data : ScriptableObject
    {
        public List<示例结构体> 结构体列表 = new();
    }

    [Serializable]
    public struct 示例结构体
    {
        public int 索引;
        public string 名字;
    }
}