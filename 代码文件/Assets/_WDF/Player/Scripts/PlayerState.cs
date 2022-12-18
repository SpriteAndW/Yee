using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    
    [Header("基本属性")]
    public float moveSpeed = 10;
    public int playerMaxHp = 6;
    public int playerCurHp;

    [Header("符箓相关")]
    [Range(0,1)]
    public float fuluSucRate = 1/6; //画符成功率
    public float fuluEffectRadius = 15; //符箓影响范围

    [Header("Buff")]
    public bool isStayShenTan; //是否在神坛里

    [Header("DeBuff")] 
    public bool isHanDuing; //是否中了寒毒

    private void Start()
    {
        playerCurHp = playerMaxHp;
    }
    
    /// <summary>
    /// 符箓影响范围可视化
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,  fuluEffectRadius);
    }
}
