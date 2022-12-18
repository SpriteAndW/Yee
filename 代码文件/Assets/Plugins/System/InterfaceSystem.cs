#region

//===================================================||
//作者：溫柔可愛柠檬草
//===================================================||

#endregion

using UnityEngine;

namespace Assets.Plugins.System
{
    #region IPortal;

    public interface IPortal
    {
        void Register();
        void OnTriggerAction(Transform t);
    }

    #endregion

    #region ITrap

    public interface ITrap
    {
        void Register();
        void OnTriggerAction();
    }

    #endregion

    #region IFootStep

    public interface IFootStep
    {
        int GetFootStepId();
        GroundType GetFootStepType();
    }

    #endregion

    #region Weapon

    public interface IWeapon
    {
        void Init();
        void Employ();
    }

    #endregion

    /// <summary>
    ///     UI
    /// </summary>
    public interface IUI
    {
        void Register();
    }

    /// <summary>
    ///     Fight
    /// </summary>

    #region

    public interface IFight //战斗接口
    {
        void ApplyDamage(float damage); //应用伤害
        void ApplyForce(GameObject causer, float force);
    }

    #endregion

    /// <summary>
    ///     AI
    /// </summary>

    #region

    public interface IAI //AI接口
    {
        void Register(); //注册接口
        void Delete(); //移除接口
        void Idle(); //呆滞
        void RandomRoaming(); //随机漫游
        void ChaseTarget(); //追逐目标 
    }

    #endregion

    /// <summary>
    ///     对象池
    /// </summary>

    #region

    public interface IObjectPool //垃圾接口
    {
        void Recovery(); //回收
    }

    #endregion

    /// <summary>
    ///     运行
    /// </summary>

    #region

    public interface IECore //IECore接口
    {
        void RegisterIECore(); //注册接口
        void RemoveIECore(); //移除接口
        void OnStart(); //在Update前一帧调用
        void OnUpdate(); //在每一帧调用
        void OnLateUpdate(); //在每下一帧调用
        void OnFixedUpdate(); //按固定速率帧调用

        void IEOnDestroy() //删除时
        {
        }

        void IEOnEnable() //启用时
        {
        }

        void IEOnDisable() //禁用时
        {
        }
    }

    #endregion
}