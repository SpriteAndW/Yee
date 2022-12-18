#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

#region

using Assets.Plugins.System;
using UnityEngine;

#endregion

namespace Assets.Plugins.Script.BaseClass.Active
{
    /// <summary>
    ///     Singleton配置Actor类单例
    /// </summary>
    /// <summary>
    ///     所有配置对象都继承ConfigActor
    /// </summary>
    public abstract class ConfigActor<T> : ConfigAActor, IECore where T : ConfigActor<T>
    {
        //声明单例

        [Header("多单例存在时优先级")] public SingletonPriority IePriority = SingletonPriority.Late;

        //设置单例
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            switch (Instance)
            {
                case null:
                    lock (IeLocker)
                    {
                        Instance = FindObjectOfType<T>();
                        if (Instance == null) Instance = (T)this;
                    }

                    break;
                default:
                    if (Instance != this)
                        switch (IePriority)
                        {
                            case SingletonPriority.Late:
                                DestroyImmediate(Instance);
                                Instance = (T)this;
                                break;
                            case SingletonPriority.Last:
                            default:
                                DestroyImmediate(this);
                                break;
                        }

                    break;
            }

            RegisterIECore();
        }

        //在删除时
        public virtual void OnDestroy()
        {
            RemoveIECore();
        }

        public virtual void OnChangeScene() //切换场景时重新注册接口
        {
            RegisterIECore();
        }

        /// <summary>
        ///     IEUpdate接口
        /// </summary>

        #region InterfaceDefault

        //注册接口
        public virtual void RegisterIECore()
        {
            if (!RunTimeSystem.Instance.IECores.Contains(this)) RunTimeSystem.Instance.IECores.Add(this);
        }

        //移除接口
        public virtual void RemoveIECore()
        {
            if (RunTimeSystem.Instance.IECores.Contains(this)) RunTimeSystem.Instance.IECores.Remove(this);
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