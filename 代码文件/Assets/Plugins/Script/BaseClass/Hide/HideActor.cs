#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

using Assets.Plugins.Script.BaseClass.Core;

namespace Assets.Plugins.Script.BaseClass.Hide
{
    /// <summary>
    ///     Singleton静态单例
    /// </summary>
    public abstract class HideActor<T> : BActor where T : new()
    {
        //声明单例
        private static T _ieInstance;

        //构造单例
        public static T Instance
        {
            get
            {
                if (_ieInstance != null) return _ieInstance;
                lock (IeLocker)
                {
                    _ieInstance ??= new T();
                }

                return _ieInstance;
            }
        }
    }
}