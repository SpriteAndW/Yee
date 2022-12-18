using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoDraw : MonoBehaviour {

    public GameObject prefab;//预制体
    public int numberOfObjects = 20; //物体总数
    public float radius = 5f; //圆圈半径

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            //算出物体间隔角度
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            //利用三角函数求位置
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            //实例化生成物体
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}

