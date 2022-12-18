using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [Header("Keys")]
    public string keyLeft;
    public string keyRight;
    public string keyUp;
    public string keyDown;
    public string keyRun;
    public string keyJump;
    public string keyRoll;
    public string keyDash;
    public string keyStep;
    public string keyAttack;

    [Header("Signals")]
    public float signalLeft;
    public float signalRight;
    public float signalUp;
    public float signalDown;
    public bool signalRun;
    public bool signalJump;
    public bool signalRoll;
    public bool signalStep;
    public bool signalDash;
    public bool signalAttack;
    public float signalMove;
    public float signalMover;

    public bool inputEnabled=true;

    [Header("Other")]
    private float target,targetver;
    private float currentHor = 1.0f;
    private float currentVelocity = 1.0f;
    private float maxValue = 0.5f;

    // Update is called once per frame
    private void Update()
    {
        if (inputEnabled)
        {
            signalRun = Input.GetKey(keyRun);
            if (signalRun) maxValue = 1.0f;
            else maxValue = 0.5f;

            signalLeft = Input.GetKey(keyLeft) ? maxValue : 0;
            signalRight = Input.GetKey(keyRight) ? maxValue : 0;
            signalUp = Input.GetKey(keyUp) ? maxValue : 0;
            signalDown = Input.GetKey(keyDown) ? maxValue : 0;
            target = signalRight - signalLeft;
            targetver = signalUp - signalDown;
            signalMove = Mathf.SmoothDamp(signalMove, target, ref currentVelocity, 0.3f);
            signalMover = Mathf.SmoothDamp(signalMover, targetver, ref currentHor, 0.3f);//上下移动

            signalJump = Input.GetKeyDown(keyJump);
            signalRoll = Input.GetKeyDown(keyRoll);
            signalDash = Input.GetKeyDown(keyDash);
            signalStep = Input.GetKeyDown(keyStep);
            signalAttack = Input.GetKeyDown(keyAttack);
        }
    }
}
