using System.Collections.Generic;
using Assets.Plugins.Script.BaseClass.Active;
using DG.Tweening;
using RootLibrary;
using UnityEngine;

namespace Assets.Script.Weapon
{
    public class BezierDotween : Actor
    {
        public GameObject End;
        public int Num = 8;
        public List<Vector3> PathPoints = new();
        public GameObject Start;

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.A)) DoAnim();
        }

        public void DoAnim()
        {
            transform.position = Start.transform.position;
            InitPaths();
            var pathVec = BezierPath();
            transform.DOPath(pathVec, 3);
        }

        public void InitPaths()
        {
            PathPoints.Clear();
            var x = (End.transform.position.x - Start.transform.position.x);
            var y = (End.transform.position.y - Start.transform.position.y);
            var z = (End.transform.position.z - Start.transform.position.z);
            var xs = LibV.LinSpaceByCount(Start.transform.position.x, End.transform.position.x, Num - 1);
            var ys = LibV.LinSpaceByCount(Start.transform.position.y, End.transform.position.y, Num - 1);
            var zs = LibV.LinSpaceByCount(Start.transform.position.z, End.transform.position.z, Num - 1);
            var offsetX = MathV.NextIn(-x, x);
            var offsetY = MathV.NextIn(-y, y);
            var offsetZ = MathV.NextIn(-z, z);
            for (var i = 0; i < Num - 1; i++)
                PathPoints.Add(new Vector3((float)xs[i] + offsetX, (float)ys[i] + offsetY,
                    (float)zs[i] + offsetZ));
            PathPoints.Add(End.transform.position);
        }

        public Vector3[] BezierPath()
        {
            var path = new Vector3[PathPoints.Count];
            for (var i = 1; i <= PathPoints.Count; i++)
            {
                var t = i / (float)PathPoints.Count;
                path[i - 1] = LibV.BezierMethod(t, PathPoints);
            }

            return path;
        }
    }
}