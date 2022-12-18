using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int maxHp = 100;
    public int curHp;

    public float attackRange;
    public float lastAttackTime;
    private void Start()
    {
        curHp = maxHp;
    }

    private void Update()
    {
        if (curHp<=0)
        {
            Destroy(gameObject);
        }
    }
}
