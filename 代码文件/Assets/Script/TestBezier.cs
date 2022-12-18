using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using RootLibrary;
using UnityEngine;

public class TestBezier : MonoBehaviour
{

    public GameObject obj;
    public List<Vector3> sb;
    public List<GameObject> Objs;

    // Update is called once per frame
    public void Start()
    {
        for (var i = 0; i < Objs.Count; i++)
        {
            sb.Add(Objs[i].transform.position);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) DoAnim();
    }

    private void DoAnim()
    {
        obj.transform.position = Objs[0].transform.position;
        var pathvec = Bezier2Path();
        obj.transform.DOPath(pathvec, 3);
    }

    //获取二阶贝塞尔曲线路径数组
    private Vector3[] Bezier2Path()
    {
        var path = new Vector3[sb.Count];
        for (var i = 1; i <= sb.Count; i++)
        {
            float t = i / (float)sb.Count;
            path[i - 1] = LibV.BezierMethod(t, sb);
        }

        return path;
    }
}