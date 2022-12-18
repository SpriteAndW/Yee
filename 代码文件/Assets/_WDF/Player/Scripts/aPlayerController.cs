using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class aPlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerState playerState;
    // private PlayerUseFulu playerUseFulu;
    private Vector3 movePos;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        playerState = GetComponent<PlayerState>();
        // playerUseFulu = GetComponent<PlayerUseFulu>();

        movePos = Vector3.zero;
    }

    private void Update()
    {
        PlayerMoveSlimple();

        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     // playerUseFulu.isUse = true;
        // }

    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector3(movePos.x * playerState.moveSpeed, rb.velocity.y, movePos.z * playerState.moveSpeed);
    }

    /// <summary>
    /// 玩家简易移动
    /// </summary>
    private void PlayerMoveSlimple()
    {
        if (Input.GetKey(KeyCode.W))
        {
            movePos.z = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            movePos.z = -1;
        }
        else
        {
            movePos.z = 0;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movePos.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movePos.x = 1;
        }
        else
        {
            movePos.x = 0;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.GetComponent<FuluTrigger>())
        {
            playerState.isStayShenTan = true;
            //TODO:获得一个庇护buff,有这个buff才能画出成功的符箓

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<FuluTrigger>())
        {
            playerState.isStayShenTan = false;
        }
    }
}