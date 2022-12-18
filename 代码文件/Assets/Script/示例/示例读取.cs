using System;
using Assets.Plugins.System;
using UnityEngine;

namespace Assets.Script.示例
{
    public class 示例读取 : MonoBehaviour
    {
        public bool 读取;
        public 示例Data 示例的Data;

        public void Update()
        {
            if (读取)
            {
                读取 = false;
                读取并且写入数据();
            }
        }

        public void 读取并且写入数据()
        {
            //清空数据
            示例的Data.结构体列表.Clear();
            //文本
            var t = Resources.Load<TextAsset>("Data/Txt/示例Excel");
            //初始化字典表
            var data = new GameConfigData(t.text);
            //长度
            var length = data.GetLines();
            for (var i = 0; i < length; i++)
            {
                var new数据 = new 示例结构体
                {
                    名字 = data.GetOneById(i.ToString())["Name"],
                    索引 = Convert.ToInt32(data.GetOneById(i.ToString())["Id"])
                };
                示例的Data.结构体列表.Add(new数据);
            }
        }
    }
}