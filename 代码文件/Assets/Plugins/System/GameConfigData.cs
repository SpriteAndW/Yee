#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

#region

using System.Collections.Generic;
using System.Linq;

#endregion

namespace Assets.Plugins.System
{
    /// <summary>
    ///     Data管理器
    /// </summary>
    public class GameConfigData
    {
        public GameConfigData(string str)
        {
            DataDic = new List<Dictionary<string, string>>();
            //换行分割
            var lines = str.Split('\n');
            //第一行是存储数据的类型
            var title = lines[0].Trim().Split('\t'); //tab切割
            //从第二行开始遍历数据
            for (var i = 1; i < lines.Length; i++)
            {
                var dic = new Dictionary<string, string>();
                var tempArr = lines[i].Trim().Split('\t');
                for (var j = 0; j < tempArr.Length; j++) dic.Add(title[j], tempArr[j]);
                DataDic.Add(dic);
            }
        }

        public List<Dictionary<string, string>> DataDic { get; set; }

        public int GetLines()
        {
            return DataDic.Count;
        }

        public List<Dictionary<string, string>> GetDic()
        {
            return DataDic;
        }

        public Dictionary<string, string> GetOneById(string id)
        {
            return DataDic.FirstOrDefault(dic => dic["Id"] == id);
        }
    }
}