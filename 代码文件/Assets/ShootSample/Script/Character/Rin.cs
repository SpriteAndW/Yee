using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rin : MonoBehaviour
{
    // Start is called before the first frame update
    BulletControl[] bulletControls;
    int i = 0;
    void Start()
    {
        bulletControls = gameObject.GetComponents<BulletControl>();
        StartCoroutine("SC");
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    IEnumerator SC()
    {
        while(i < 11)
        {
            yield return new WaitForSeconds(0.6f);
            i++;
            StartShoot();
       
        }
    }

    void StartShoot()
    {
        for (int i = 0; i < bulletControls.Length; i++)
        {
            bulletControls[i].SelfRotation = RanRotation();
            bulletControls[i].Shoot();
        }
    }

    float RanRotation()
    {
        return Random.Range(-15, 15);
    }
}
