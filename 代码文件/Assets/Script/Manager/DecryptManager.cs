using System.Collections.Generic;
using System.Linq;
using Assets.Plugins.Script.BaseClass.Hide;
using RootLibrary;
using UnityEngine;

namespace Assets.Script.Manager
{
    public sealed class DecryptManager : HideActor<DecryptManager>
    {
        [Header("阵法")] public Dictionary<int, bool> CircleDic = new();
        [Header("密码表")] public Dictionary<string, string> Codes = new();

        /// <summary>
        ///     新建密码
        /// </summary>
        public void CreateNewCode(string code)
        {
            if (!Codes.ContainsKey(code))
                Codes.Add(code, "");
            else
                Codes[code] = "";
        }

        /// <summary>
        ///     旋转开锁
        /// </summary>
        public bool RotateUnLock(float a, float b, float t)
        {
            return t.IsBetween(a, b);
        }

        /// <summary>
        ///     输入密码
        /// </summary>
        public bool InputCode(string code, string t)
        {
            Codes[code] += t;
            return Codes[code].Equals(code);
        }

        /// <summary>
        ///     清除密码
        /// </summary>
        public void ClearCode(string code)
        {
            Codes[code] = "";
        }

        /// <summary>
        ///     布阵
        /// </summary>
        public void ApplyCircle(List<int> ids)
        {
            foreach (var id in ids) CircleDic.Add(id, false);
        }

        /// <summary>
        ///     增加阵眼
        /// </summary>
        public void AddCircleEye(int id)
        {
            if (!CircleDic.ContainsKey(id)) CircleDic.Add(id, false);
        }

        /// <summary>
        ///     移除阵眼
        /// </summary>
        public void RemoveCircleEye(int id)
        {
            if (!CircleDic.ContainsKey(id)) CircleDic.Remove(id);
        }

        /// <summary>
        ///     激活阵眼
        /// </summary>
        public void OpenCircleEye(int id)
        {
            if (CircleDic.ContainsKey(id)) CircleDic[id] = true;
        }

        /// <summary>
        ///     关闭阵眼
        /// </summary>
        public void CloseCircleEye(int id)
        {
            if (CircleDic.ContainsKey(id)) CircleDic[id] = false;
        }

        /// <summary>
        ///     破阵
        /// </summary>
        public bool BreakCircle()
        {
            return CircleDic.All(t => t.Value);
        }
    }
}