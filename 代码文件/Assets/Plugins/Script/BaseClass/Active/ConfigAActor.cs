namespace Assets.Plugins.Script.BaseClass.Active
{
    public abstract class ConfigAActor : Actor
    {
        //声明锁
        public static readonly object IeLocker = new();
    }
}