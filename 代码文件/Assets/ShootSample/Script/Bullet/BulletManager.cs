using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BulletManager : MonoBehaviour
{
    public static BulletManager Instance;
    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
       // Function();
    }



    public void ShootConfig(BulletData bulletData, BaseGameObjectPool pool)
    {
        int num = bulletData.Count / 2; 
        for (int i = 0; i < bulletData.Count; i++)
        {
            GameObject go = pool.Get(bulletData.Position, bulletData.LifeTime); //从对象池中获取
            Bullet bullet = go.GetComponent<Bullet>();
            var render = go.GetComponent<Renderer>();
            if (render!=null)
            {
                go.GetComponent<Renderer>().material?.SetColor("_EmissionColor", bulletData.color);
            }
            bullet.BulletSpeed = bulletData.Speed;
            bullet.DelayTime = bulletData.DelayTime;

            if (bulletData.Count % 2 == 1)
            {
                go.transform.rotation = bulletData.direction * Quaternion.Euler(0, bulletData.Angle * num, 0);
                go.transform.position = go.transform.position + go.transform.right * num * bulletData.Distance;
                num--;
            }
            else
            {
                go.transform.rotation = bulletData.direction * Quaternion.Euler(0, bulletData.Angle / 2 + bulletData.Angle * (num - 1), 0);
                go.transform.position = go.transform.position + go.transform.right * ((num - 1) * bulletData.Distance + bulletData.Distance / 2);
                num--;
            }
            go.transform.position = go.transform.position + go.transform.forward * bulletData.CenterDis;
        }
    }

    //public float[] y;
    //void Function()
    //{
    //    y = new float[62];
    //    for (int i = 0; i < y.Length; i++)
    //    {
    //        float t = (float)i / 10;
    //        y[i] = Mathf.Cos(t);
    //    }
    //}

}
