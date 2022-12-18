using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update、
    public float BulletSpeed = 30;
    bool Shoot;
    public float DelayTime = 0;
    int DelayI;
    void FixedUpdate()
    {
        if (Shoot)
        {
            Shooting();
        }
        else if(DelayI > DelayTime * 50)
        {
            Shoot = true;
        }
        else
        {
            DelayI++;
        }
    }

    public void Shooting()
    {
        Vector3 p = transform.position;
        transform.position = transform.position + transform.forward * BulletSpeed * Time.fixedDeltaTime;
    }

    private void OnEnable()
    {
        DelayI = 0;
        Shoot = false;
    }





}
