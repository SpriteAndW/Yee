#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

using Assets.Plugins.System;

namespace Assets.Plugins.Script.BaseClass.Active
{
    public abstract class ENActor : Actor, IECore
    {
        //在启用时
        public virtual void OnEnable()
        {
            RegisterIECore();
        }

        //在禁用时
        public virtual void OnDisable()
        {
            RemoveIECore();
        }

        //在删除时
        public virtual void OnDestroy()
        {
            RemoveIECore();
        }

        /// <summary>
        ///     IEUpdate接口
        /// </summary>

        #region InterfaceDefault

        //注册接口
        public virtual void RegisterIECore()
        {
            if (!RunTimeSystem.Instance.IENCores.Contains(this)) RunTimeSystem.Instance.IENCores.Add(this);
        }

        //移除接口
        public virtual void RemoveIECore()
        {
            if (RunTimeSystem.Instance.IENCores.Contains(this)) RunTimeSystem.Instance.IENCores.Remove(this);
        }

        //OnStart
        public virtual void OnStart()
        {
            RegisterIECore();
        }

        //OnUpdate
        public virtual void OnUpdate()
        {
        }

        //OnLateUpdate
        public virtual void OnLateUpdate()
        {
        }

        //OnFixedUpdate
        public virtual void OnFixedUpdate()
        {
        }

        #endregion
    }
}