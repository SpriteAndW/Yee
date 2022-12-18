using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using Assets.Script.Manager;
using UnityEditor;
using UnityEngine;

namespace Assets.Script.Manager
{
    public sealed class SaveManager : HideActor<SaveManager>
    {
        //玩家存档文件名称
        public static string[] SaveFileName = { "YiChing.txt" };

        public void Load(int id)
        {
            SaveByJson.AppLoadDataByJson(id);
            DataManager.Instance.GetFromInventoryBag();
            DataManager.Instance.GetFromPlayerData();
        }

        public void Save(int id)
        {
            DataManager.Instance.RefreshPlayerData();
            DataManager.Instance.RefreshInventoryBag();
            SaveByJson.AppStoreDataByJson(id);
        }
    }
}

public readonly struct SaveByJson
{
    /// <summary>
    ///     删档工具
    /// </summary>

    #region Delete

    public static void AppDeleteDataByJson(int id)
    {
        //Json删除
        SaveSystem.DeleteSaveFile(SaveManager.SaveFileName[id]);
    }

    #endregion

    /// <summary>
    ///     Json存储器
    /// </summary>
    //序列化
    [SerializeField]
    private struct SaveData //要存储的变量
    {
        public PlayerData PlayerOfData;
        public InventoryData Inventory;
    }

    public static InventoryData SaveInventory => DataManager.Instance.InventoryBag;
    public static PlayerData SavePlayerData => DataManager.Instance.PlayerOfData;

    /// <summary>
    ///     存档工具
    /// </summary>

    #region Save

    public static void AppStoreDataByJson(int id) //Json存储
    {
        SaveSystem.SaveByJson(SaveManager.SaveFileName[id], JsonSave());
        //刷新编辑器
    }

    private static SaveData JsonSave() //存储进Json文件
    {
        var jsonData = new SaveData
        {
            Inventory = SaveInventory,
            PlayerOfData = SavePlayerData
        };
        return jsonData;
    }

    #endregion

    /// <summary>
    ///     读档工具
    /// </summary>

    #region Load

    public static void AppLoadDataByJson(int id)
    {
        var jsonData = SaveSystem.LoadFromJson<SaveData>(SaveManager.SaveFileName[id]);
        if (jsonData.Equals(null)) return;
        JsonLoad(jsonData);
        //刷新编辑器
    }

    private static void JsonLoad(SaveData t) //读取Json文件
    {
        DataManager.Instance.PlayerOfData = t.PlayerOfData;
        DataManager.Instance.InventoryBag = t.Inventory;
    }

    #endregion
}