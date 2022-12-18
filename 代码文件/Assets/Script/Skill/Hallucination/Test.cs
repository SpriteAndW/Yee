using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Manager;
using MiniGame;
using RootLibrary;

public class Test : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0)) PlayerManager.Instance.IllusionBlinding();
        if (Input.GetMouseButtonDown(1)) PlayerManager.Instance.RemoveIB();
    }
    public IEnumerator aaa()
    {
        int i = 0;
        while (i < 10)
        {
            i++;
            yield return new WaitForSeconds(1f);
        }
        CoroutineManager.Instance.Kill(0);
        
    }

    /*//设置渐变的时间
    public GameObject t;
    public GameObject b;
    private void Update()
    {
        //按鼠标左键开始渐变
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject a = Instantiate(t);
            StartCoroutine(LibV.BulletFollowing(a.transform, b.transform, -85, 85));
        }
    }*/
}