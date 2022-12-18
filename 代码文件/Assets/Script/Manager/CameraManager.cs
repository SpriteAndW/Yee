using Assets.Plugins.Script.BaseClass.Hide;
using Assets.Plugins.System;
using RootLibrary;
using UnityEngine;

namespace Assets.Script.Manager
{
    public class CameraManager : HideActor<CameraManager>
    {
        [Header("最大距离")] public float MaxViewDistance = 50f;
        [Header("最小距离")] public float MinViewDistance = 20f;
        [Header("滚轮缩进距离速度")] public float ZoomSpeed = 0.002f;

        /// <summary>
        ///     鼠标滚轮缩放镜头
        /// </summary>
        public void MouseWheelZoom()
        {
            switch (InputManager.InputAxisDic[InputsType.MouseScrollWheel]())
            {
                case 0:
                    break;
                case < 0:
                    Camera.main.fieldOfView = MathV.Clamp(Camera.main.fieldOfView + ZoomSpeed, MinViewDistance,
                        MaxViewDistance);
                    break;
                case > 0:
                    Camera.main.fieldOfView = MathV.Clamp(Camera.main.fieldOfView - ZoomSpeed, MinViewDistance,
                        MaxViewDistance);
                    break;
            }
        }
    }
}