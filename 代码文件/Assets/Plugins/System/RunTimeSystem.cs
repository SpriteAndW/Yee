#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Hide;

namespace Assets.Plugins.System
{
    public sealed class RunTimeSystem : HideActor<RunTimeSystem> //不继承Monobehavior可以直接初始化
    {
        /// <summary>
        ///     管理器类
        /// </summary>

        #region

        //优化基本代码
        // ReSharper disable once InconsistentNaming
        public List<IECore> IECoreES = new();

        //构造函数
        public List<IECore> IECores
        {
            get => IECoreES;
            set => IECoreES = value;
        }

        #endregion

        /// <summary>
        ///     场景物体类
        /// </summary>

        #region

        //优化基本代码
        // ReSharper disable once InconsistentNaming
        public List<IECore> IENCoreES = new();

        //构造函数
        // ReSharper disable once InconsistentNaming
        public List<IECore> IENCores
        {
            get => IENCoreES;
            set => IENCoreES = value;
        }

        #endregion

        /// <summary>
        ///     方法
        /// </summary>

        #region

        //重新设置IECore
        public void RunTimeReSetIECore()
        {
            for (var i = IECores.Count - 1; i >= 0; i--)
                if (IECores[i] == null)
                    IECores.RemoveAt(i);
            for (var i = IENCores.Count - 1; i >= 0; i--)
                if (IENCores[i] == null)
                    IENCores.RemoveAt(i);
        }

        //清除全部IECore
        public void RunTimeClearAll()
        {
            IECores.Clear();
            IENCores.Clear();
        }

        //清除全部IE
        public void RunTimeClearIE()
        {
            IECores.Clear();
        }

        //清除全部IEN
        // ReSharper disable once InconsistentNaming
        public void RunTimeClearIEN()
        {
            IENCores.Clear();
        }

        //开始时运行
        public void RunTimeOnStart()
        {
            for (var i = 0; i < IECores.Count; i++) IECores[i].OnStart();
            for (var i = 0; i < IENCores.Count; i++) IENCores[i].OnStart();
        }

        //Update
        public void RunTimeOnUpdate()
        {
            for (var i = 0; i < IECores.Count; i++) IECores[i].OnUpdate();
            for (var i = 0; i < IENCores.Count; i++) IENCores[i].OnUpdate();
        }

        //LateUpdate
        public void RunTimeOnLateUpdate()
        {
            for (var i = 0; i < IECores.Count; i++) IECores[i].OnLateUpdate();
            for (var i = 0; i < IENCores.Count; i++) IENCores[i].OnLateUpdate();
        }

        //FixedUpdate
        public void RunTimeOnFixedUpdate()
        {
            for (var i = 0; i < IECores.Count; i++) IECores[i].OnFixedUpdate();
            for (var i = 0; i < IENCores.Count; i++) IENCores[i].OnFixedUpdate();
        }

        #endregion
    }
}