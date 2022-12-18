using System;
using System.Collections.Generic;
using RootLibrary;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Plugins.System
{
    public static class InputManager
    {
        public static Dictionary<InputsType, Func<float>> InputAxisDic = new()
        {
            { InputsType.Horizontal, GetInputAxisHorizontal },
            { InputsType.Vertical, GetInputAxisVertical },
            { InputsType.MouseScrollWheel, GetMouseWheelAxis }
        };

        public static Dictionary<InputsType, Func<bool>> InputButtonDic = new()
        {
            { InputsType.MouseLeftButtonDown, GetButtonDown0 },
            { InputsType.MouseRightButtonDown, GetButtonDown1 },
            { InputsType.MouseMiddleButtonDown, GetButtonDown2 },
            { InputsType.MouseLeftButtonUp, GetButtonUp0 },
            { InputsType.MouseRightButtonUp, GetButtonUp1 },
            { InputsType.MouseMiddleButtonUp, GetButtonUp2 },
            { InputsType.MouseLeftButton, GetButton0 },
            { InputsType.MouseRightButton, GetButton1 },
            { InputsType.MouseMiddleButton, GetButton2 }
        };

/*        public static Dictionary<InputsType, Func<bool>> InputKeyDic = new()
        {
            { InputsType.KeyCodeA, Input.GetKeyDown(KeyCode.A) },
            { InputsType.KeyCodeD, Input.GetKeyDown(KeyCode.D)},
            { InputsType.KeyCodeQ, Input.GetKeyDown(KeyCode.Q) },
            { InputsType.KeyCodeW, Input.GetKeyDown(KeyCode.W) },
            { InputsType.KeyCodeE ,Input.GetKeyDown(KeyCode.E) },
            { InputsType.KeyCodeR, Input.GetKeyDown(KeyCode.R) },
            { InputsType.KeyCodeF, Input.GetKeyDown(KeyCode.F) }
        };*/

        /// <summary>
        ///     轴输入目标点
        /// </summary>
        public static Vector3 AxisMoveTarget(this Transform t, float speed)
        {
            return new Vector3(t.position.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed, t.position.y,
                t.position.z + Input.GetAxis("Vertical") * Time.deltaTime * speed);
        }

        /// <summary>
        ///     刚体目标点
        /// </summary>
        public static Vector3 RigidBodyTarget(this Rigidbody t, float speed)
        {
            return new Vector3(t.position.x + Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed, t.position.y,
                t.position.z + Input.GetAxis("Vertical") * Time.fixedDeltaTime * speed);
        }

        /// <summary>
        ///     设置导航目标为鼠标位置
        /// </summary>
        public static void SetMouseTarget(this NavMeshAgent t)
        {
            t.SetDestination(LibV.GetMouseRayPosition());
        }

        /// <summary>
        ///     刚体旋转
        /// </summary>
        public static void RigidBogyRotate(GameObject model, float turnSpeed)
        {
            var dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            var quaDir = Quaternion.LookRotation(dir, Vector3.up);
            model.transform.rotation =
                Quaternion.Slerp(model.transform.rotation, quaDir, Time.fixedDeltaTime * turnSpeed);
        }

        /// <summary>
        ///     鼠标左键按下
        /// </summary>
        public static bool GetButtonDown0()
        {
            return Input.GetButtonDown("MouseLeftButton");
        }

        /// <summary>
        ///     鼠标左键按
        /// </summary>
        public static bool GetButton0()
        {
            return Input.GetButton("MouseLeftButton");
        }

        /// <summary>
        ///     鼠标左键抬起
        /// </summary>
        public static bool GetButtonUp0()
        {
            return Input.GetButtonUp("MouseLeftButton");
        }

        /// <summary>
        ///     鼠标右键按下
        /// </summary>
        public static bool GetButtonDown1()
        {
            return Input.GetButtonDown("MouseRightButton");
        }

        /// <summary>
        ///     鼠标右键按
        /// </summary>
        public static bool GetButton1()
        {
            return Input.GetButton("MouseRightButton");
        }

        /// <summary>
        ///     鼠标右键抬起
        /// </summary>
        public static bool GetButtonUp1()
        {
            return Input.GetButtonUp("MouseRightButton");
        }

        /// <summary>
        ///     鼠标中键按下
        /// </summary>
        public static bool GetButtonDown2()
        {
            return Input.GetButtonDown("MouseMiddleButton");
        }

        /// <summary>
        ///     鼠标中键按
        /// </summary>
        public static bool GetButton2()
        {
            return Input.GetButton("MouseMiddleButton");
        }

        /// <summary>
        ///     鼠标中键抬起
        /// </summary>
        public static bool GetButtonUp2()
        {
            return Input.GetButtonUp("MouseMiddleButton");
        }

        /// <summary>
        ///     滚轮
        /// </summary>
        public static float GetMouseWheelAxis()
        {
            return Input.GetAxis("Mouse ScrollWheel");
        }

        /// <summary>
        ///     水平输入
        /// </summary>
        public static float GetInputAxisHorizontal()
        {
            return Input.GetAxis("Horizontal");
        }

        /// <summary>
        ///     竖直输入
        /// </summary>
        public static float GetInputAxisVertical()
        {
            return Input.GetAxis("Vertical");
        }
    }
}