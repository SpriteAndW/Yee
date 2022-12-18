using Assets.Plugins.Script.BaseClass.Hide;
using RootLibrary;
using UnityEngine;

namespace Assets.Script.Manager
{
    public sealed class ResourceManager : HideActor<ResourceManager>
    {
        /// <summary>
        ///     读取路径下的文件
        /// </summary>
        public T LoadResource<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        /// <summary>
        ///     读取路径下的所有文件
        /// </summary>
        public T[] LoadResourcesUnCheck<T>(string path) where T : Object
        {
            //读取路径下的所有T文件
            return Resources.LoadAll<T>(path);
        }

        /// <summary>
        ///     读取路径下的所有文件
        /// </summary>
        public T[] LoadResources<T>(string path) where T : Object
        {
            //读取路径下的所有T文件
            var t = Resources.LoadAll<T>(path);
            //如果为空就返回
            if (t.Length == 0) return null;
            //去重
            t = t.HashDistinct();
            //如果元素为空就去除
            for (var i = t.Length - 1; i >= 0; i--)
                if (t[i] == null)
                    t = t.RemoveAt(i);
            return t;
        }
    }
}