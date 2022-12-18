using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using Assets.Script.Characters;
using UnityEngine;

namespace Assets.Script.Manager
{
    public sealed class DataManager : HideActor<DataManager>
    {
        #region StoreData

        /// <summary>
        ///     刷新背包结构
        /// </summary>
        public void RefreshInventoryBag()
        {
            InventoryBag.Ids.Clear();
            InventoryBag.Counts.Clear();
            foreach (var i in InventoryDic)
            {
                InventoryBag.Ids.Add(i.Key);
                InventoryBag.Counts.Add(i.Value);
            }
        }

        /// <summary>
        ///     玩家数据结构
        /// </summary>
        public void RefreshPlayerData()
        {
            PlayerOfData.HP = Player.HP;
            PlayerOfData.Magic = Player.Magic;
            PlayerOfData.Pos = Player.transform.position;
        }

        #endregion

        #region Variable

        public DataManager()
        {
            ResourceInit();
        }

        #region =>

        [Header("音效字典")] public Dictionary<int, AudioClip> AudioClioDic = new();
        [Header("音效数组")] public AudioClip[] AudioClipArray;

        [Header("音效读取路径")] public string AudioPath = "Audio";

        public void ResourceInit()
        {
            //读取路径下的所有音频文件
            AudioClipArray = ResourceManager.Instance.LoadResourcesUnCheck<AudioClip>(AudioPath);
            //添加进字典
            if (AudioClipArray == null) return;
            for (var i = 0; i < AudioClipArray.Length; i++) AudioClioDic.Add(i, AudioClipArray[i]);
        }

        //玩家
        public YiChingPlayer Player => PlayerManager.Instance.Player;

        //背包字典
        public Dictionary<int, int> InventoryDic => InventoryManager.Instance.InventoryDic;

        #endregion

        #region DataSaver

        //背包结构
        public InventoryData InventoryBag = new()
        {
            Ids = new List<int>(),
            Counts = new List<int>()
        };

        //玩家数据
        public PlayerData PlayerOfData;

        #endregion

        #endregion

        #region GetData

        /// <summary>
        ///     用Id获取对话
        /// </summary>
        public string GetTalkById(int id)
        {
            var t = GameConfigManager.Instance.GetTalkById(id.ToString());
            return t != null ? t["Talk"] : "XX";
        }

        /// <summary>
        ///     用Id获取物品名称
        /// </summary>
        public string GetItemNameById(int id)
        {
            var t = GameConfigManager.Instance.GetDescriptionById(id.ToString());
            return t != null ? t["Nme"] : "XX";
        }

        /// <summary>
        ///     用Id获取物品描述
        /// </summary>
        public string GetItemDescriptionById(int id)
        {
            var t = GameConfigManager.Instance.GetDescriptionById(id.ToString());
            return t != null ? t["Des"] : "XX";
        }

        /// <summary>
        ///     从背包结构获取背包字典
        /// </summary>
        public void GetFromInventoryBag()
        {
            InventoryDic.Clear();
            var count = InventoryBag.Ids.Count;
            for (var i = 0; i < count; ++i) InventoryDic.Add(InventoryBag.Ids[i], InventoryBag.Counts[i]);
        }

        /// <summary>
        ///     从玩家结构获取玩家数据
        /// </summary>
        public void GetFromPlayerData()
        {
            Player.HP = PlayerOfData.HP;
            Player.Magic = PlayerOfData.Magic;
            Player.transform.position = PlayerOfData.Pos;
        }

        #endregion
    }
}