#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

#region

using System;
using System.IO;
using UnityEngine;

#endregion

#region

namespace Assets.Plugins.System
{
    /// <summary>
    ///     Json
    /// </summary>
    public static class SaveSystem
    {
        /// <summary>
        ///     存档
        /// </summary>

        #region Save

        public static void SaveByJson(string saveFileName, object data)
        {
            //将存档转成Json
            var json = JsonUtility.ToJson(data);
            //指定文件
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            try
            {
                File.WriteAllText(path, json);
#if UNITY_EDITOR
                Debug.Log($"保存成功.\n{path}");
#endif
            }
            catch (Exception exception)
            {
#if UNITY_EDITOR
                Debug.LogError($"保存失败.\n{path}.\n{exception}");
#endif
            }
        }

        #endregion

        /// <summary>
        ///     读档
        /// </summary>

        #region Load

        public static T LoadFromJson<T>(string saveFileName)
        {
            //指定文件
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            switch (File.Exists(path))
            {
                case true:
                    try
                    {
#if UNITY_EDITOR
                        Debug.Log($"读取成功.\n{path}");
#endif
                        var json = File.ReadAllText(path);
                        var data = JsonUtility.FromJson<T>(json);
                        return data;
                    }
                    catch (Exception exception)
                    {
#if UNITY_EDITOR
                        Debug.Log($"读取失败.\n{path}.\n{exception}");
#endif
                        return default;
                    }
                case false:
#if UNITY_EDITOR
                    Debug.Log($"不存在.\n{path}");
#endif
                    return default;
            }
        }

        #endregion

        /// <summary>
        ///     删档
        /// </summary>

        #region Delete

        public static void DeleteSaveFile(string saveFileName)
        {
            //指定文件
            var path = Path.Combine(Application.persistentDataPath, saveFileName);
            switch (File.Exists(path))
            {
                case true:
                    try
                    {
#if UNITY_EDITOR
                        Debug.Log($"删除成功.\n{path}");
#endif
                        File.Delete(path);
                    }
                    catch (Exception exception)
                    {
#if UNITY_EDITOR
                        Debug.Log($"删除失败.\n{path}.\n{exception}");
#endif
                    }

                    break;
                case false:
#if UNITY_EDITOR
                    Debug.Log($"不存在.\n{path}");
#endif
                    break;
            }

            #endregion
        }
    }
}

#endregion