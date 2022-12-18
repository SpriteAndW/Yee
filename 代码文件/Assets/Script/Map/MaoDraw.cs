using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaoDraw : MonoBehaviour {

    public GameObject prefab;//Ԥ����
    public int numberOfObjects = 20; //��������
    public float radius = 5f; //ԲȦ�뾶

    void Start()
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            //����������Ƕ�
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            //�������Ǻ�����λ��
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            //ʵ������������
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
}

