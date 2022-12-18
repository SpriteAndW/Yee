using System.Collections.Generic;
using UnityEngine;

namespace Assets.Script.Data
{
    [CreateAssetMenu(fileName = "BookDatas", menuName = "ScriptableObject/Book数据", order = 0)]
    public class BookDatas : ScriptableObject
    {
        public List<BookCharmInformation> BookCharmDatas;
        public List<BookEnemyInformation> BookEnemyDatas;
        public List<BookMagicInformation> BookMagicDatas;
        public List<BookMapInformation> BookMapDatas;
        public List<BookScreenedInformation> BookScreenedDatas;
        public List<BookThunderInformation> BookThunderDatas;
        public List<BookZhenInformation> BookZhenDatas;

        public BookCharmInformation GetCharmDetail(string id)
        {
            return BookCharmDatas.Find(i=>i.CharmID==id);
        }
        public BookEnemyInformation GetEnemyDetail(string id)
        {
            return BookEnemyDatas.Find(i => i.EnemyID == id);
        }
        public BookMagicInformation GetMagicDetail(string id)
        {
            return BookMagicDatas.Find(i => i.MagicID == id);
        }
        public BookMapInformation GetMapDetail(string id)
        {
            return BookMapDatas.Find(i => i.MapID == id);
        }
        public BookScreenedInformation GetScreenedDetail(string id)
        {
            return BookScreenedDatas.Find(i => i.ScreenedID == id);
        }
        public BookThunderInformation GetThunderDetail(string id)
        {
            return BookThunderDatas.Find(i => i.ThunderID == id);
        }
        public BookZhenInformation GetZhenDetail(string id)
        {
            return BookZhenDatas.Find(i => i.ZhenID == id);
        }
    }
    [System.Serializable]
    public class BookMapInformation
    {
        public string MapID;
        public string MapName;

        // 需要补可以查看探索地图的图像 

        public List<BookMapPoint> MapPoints;
    }
    [System.Serializable]
    public class BookMapPoint
    {
        public string MapPointID;
        public string MapPointName;

        public int TracePointID; //追踪地点
    }
    [System.Serializable]
    public struct BookCharmInformation
    {
        public string CharmID;
        public string CharmName;
        public Sprite CharmImage;
        [TextArea] public string CharmIntroduction;
    }
    [System.Serializable]
    public struct BookZhenInformation 
    {
        public string ZhenID;
        public string ZhenName;
        public Sprite ZhenImage;
        [TextArea] public string ZhenIntroduction;
    }
    [System.Serializable]
    public struct BookMagicInformation
    {
        public string MagicID;
        public string MagicName;
        public Sprite MagicImage;
        [TextArea] public string MagicIntroduction;
    }
    [System.Serializable]
    public struct BookThunderInformation 
    {
        public string ThunderID;
        public string ThunderName;
        public Sprite ThunderImage;
        [TextArea] public string ThunderIntroduction;
    }
    [System.Serializable]
    public struct BookScreenedInformation 
    {
        public string ScreenedID;
        public string ScreenedName;
        public Sprite ScreenedImage;
        [TextArea] public string ScreenedIntroduction;
    }
    [System.Serializable]
    public struct BookEnemyInformation 
    {
        public string EnemyID;
        public string EnemyName;
        public Sprite EnemyImage;
        [TextArea] public string EnemyIntroduction;
    }
}