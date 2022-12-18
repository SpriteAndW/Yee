using RootLibrary;
using UnityEngine;

namespace Assets.Script
{
    public class TestCameraFollow : MonoBehaviour
    {
        private Camera _controlCamera; // 控制的相机

        private Transform _self;

        [Header("默认角度")] public float DefaultAngle = -135;

        [Header("跟随的目标对象")] public Transform FollowTarget = null;

        [Header("离目标对象的高度")] public float Height = 1.5f;

        [Header("仰角Y最大值")] public float MaxY = 80;

        [Header("仰角Y最小值")] public float MinY = -80;

        [Header("相机跟随移动速度")] public float MoveSpeed = 10;

        [Header("离目标对象的距离")] public float Radius = 3;

        [Header("旋转角度参数")] public Vector2 Rotate;

        [Header("相机旋转速度")] public float RotateSpeed = 2;

        [Header("视口大小")] public float ViewSize = 60;

        public void Start()
        {
            _controlCamera = GetComponent<Camera>();
            _self = _controlCamera.transform;
        }

        public void Update()
        {
            var inputX = Input.GetAxis("Mouse X");
            var inputY = Input.GetAxis("Mouse Y");
            Rotate.x += inputX * RotateSpeed;
            Rotate.y += inputY * RotateSpeed;
            ViewSize -= Input.mouseScrollDelta.y * MathV.Pi;
            ViewSize = ViewSize switch
            {
                < 1 => 1,
                > 60 => 60,
                _ => ViewSize
            };
            if (Rotate.x is >= 360f or <= -360f) Rotate.x = 0f;
            if (Rotate.y < MinY)
                Rotate.y = MinY;
            else if (Rotate.y > MaxY) Rotate.y = MaxY;
            _controlCamera.fieldOfView = ViewSize;
        }

        public void LateUpdate()
        {
            var startPosition = _self.position;
            var targetPos = FollowTarget.position;
            targetPos.y += Height;
            var v1 = CalcAbsolutePoint(Rotate.x, Radius);
            var endPosition = targetPos + new Vector3(v1.x, 0f, v1.y);
            var v2 = CalcAbsolutePoint(Rotate.x + DefaultAngle, 1f);
            var viewPoint = new Vector3(v2.x, 0f, v2.y) + targetPos;
            var dist = Vector3.Distance(endPosition, viewPoint);
            var v3 = CalcAbsolutePoint(Rotate.y, dist);
            endPosition += new Vector3(0f, v3.y, 0f);
            if (Physics.Linecast(targetPos, endPosition, out var hit))
            {
                var gameObjectTag = hit.collider.gameObject.tag;
                if (!gameObjectTag.Equals("MainCamera") || !gameObjectTag.Equals("Player"))
                    endPosition = hit.point - (endPosition - hit.point).normalized * 0.2f;
            }

            _self.position = Vector3.Lerp(startPosition, endPosition, Time.deltaTime * MoveSpeed);
            var rotateQ = Quaternion.LookRotation(viewPoint - endPosition);
            _self.rotation = Quaternion.Slerp(transform.rotation, rotateQ, Time.deltaTime * MoveSpeed);
        }

        public Vector2 CalcAbsolutePoint(float angle, float dist)
        {
            return LibV.CalcAbsolutePoint(angle, dist);
        }
    }
}