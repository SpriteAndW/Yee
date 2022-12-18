#region

using System.Data;
using System.IO;
using Excel;
using UnityEditor;
using UnityEngine;

#endregion

namespace Assets.Editor
{
    public static class ExcelReader //Excel读取器
    {
        //读取目录
        private const string LoadPath = "/Resources/Data/Excel";

        //储存目录
        private const string SavePath = "/Resources/Data/Txt/";

        [MenuItem("基本工具/Excel转Txt")]
        public static void ExportExcelToTxt()
        {
            //文件路径
            var assetPath = Application.dataPath + LoadPath;
            //Excel后缀名
            var files = Directory.GetFiles(assetPath, "*.xlsx");
            for (var i = 0; i < files.Length; i++)
            {
                files[i] = files[i].Replace('\\', '/'); //\替换成/
                //通过文件流读取文件
                using var fs = File.Open(files[i], FileMode.Open, FileAccess.Read);
                //文件流转成excel
                var excelDataReader = ExcelReaderFactory.CreateOpenXmlReader(fs);
                //获得excel数据
                var dataSet = excelDataReader.AsDataSet();
                //读取excel第一张表
                var table = dataSet.Tables[0];
                //将表中内容，读取后，存储到，对应的txt文件
                ReadTableToTxt(files[i], table);
            }

            //刷新编辑器
            AssetDatabase.Refresh();
        }

        private static void ReadTableToTxt(string filePath, DataTable table)
        {
            //获得文件名（不要文件后缀，生成与之名字相同的txt文件）
            var fileName = Path.GetFileNameWithoutExtension(filePath);
            //txt文件存储的路径
            var path = Application.dataPath + SavePath + fileName + ".txt";
            //判断Resources/Data/Txt文件夹里是否存在对应的txt文件，如果是，则删除
            if (File.Exists(path)) File.Delete(path);
            //文件流创建txt文件
            using var fs = new FileStream(path, FileMode.Create);
            //文件流转写入流，方便写入字符串
            using var sw = new StreamWriter(fs);
            //遍历table
            for (var row = 0; row < table.Rows.Count; row++)
            {
                var dataRow = table.Rows[row];
                var str = string.Empty;
                //遍历列
                for (var col = 0; col < table.Columns.Count; col++)
                {
                    var val = dataRow[col].ToString();
                    str = str + val + "\t"; //每一项tab分割
                }

                //写入
                sw.Write(str);
                //如果不是最后一行，换行
                if (row != table.Rows.Count - 1) sw.WriteLine(); //写入txt文件
            }
        }
    }
}