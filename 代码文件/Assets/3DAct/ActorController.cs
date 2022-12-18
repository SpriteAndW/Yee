using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;

//作业1.模型转向 Vec3.slerp
public class ActorController : MonoBehaviour
{
    private PlayerInput pi;
    private Animator anim;
    private Rigidbody rigid;
    private GroundSensor groundSensor;

    public bool isGround;
    public float runSpeed=50.0f;
    public float walkSpeed =10.0f;
    public float jumpSpeed =8.0f;
    private float move;
    private float mover;
    private float startTime;
    private Vector3 animDeltaPos;
    public GameObject model;

    public float turnspeed = 4;
    float ver = 0;
    float hor = 0;

    private void Awake()
    {
        pi = GetComponent<PlayerInput>();
        anim = GetComponentInChildren<Animator>();
        groundSensor = GetComponentInChildren<GroundSensor>();
        rigid = GetComponent<Rigidbody>();
        startTime = Time.time;
    }
    private void Update()//每个帧的帧数
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");

        anim.SetBool("IsGround",groundSensor.IsGround());
        isGround = groundSensor.IsGround();
        move = Mathf.Abs(pi.signalMove);
        mover = Mathf.Abs(pi.signalMover);

        if (!pi.signalRun)
        {
            move = Mathf.Clamp(move, 0, 0.5f);
            mover = Mathf.Clamp(mover,0,0.5f);
        }
        /*anim.SetFloat("Blend",move);*/
        if (pi.signalUp > 0 || pi.signalDown > 0) 
        anim.SetFloat("Blend", mover);
        else 
        anim.SetFloat("Blend", move);
        //anim.SetFloat("Blend",mover);

        if (pi.signalJump) anim.SetTrigger("Jump");
        if (pi.signalRoll) anim.SetTrigger("RollingBack");
        if (pi.signalDash) anim.SetTrigger("Dash");
        if (pi.signalStep) anim.SetTrigger("StepBack");
        if (pi.signalAttack) anim.SetTrigger("BaseAttack");

        //if (move < -0.1f)
        //{
            //transform.forward = Vector3.Slerp(new Vector3(0, 0, 0), new Vector3(0, 0, pi.signalMove), (Time.time - startTime) / 1.0f);
            //弧线的中心
            //Vector3 center = (sunrise.forward + sunset.forward) * 0.5f;
            //Vector3 centerProject = Vector3.Project(center, sunrise.forward - sunset.forward); // 中心点在两点之间的投影
            //center = Vector3.MoveTowards(center, centerProject, 1f); // 沿着投影方向移动移动距离（距离越大弧度越小）                
            //new Vector3(0,0,pi.signalMove);                                                         //相对于中心在弧线上插值
            //Vector3 riseRelCenter = sunrise.forward - center;
            //Vector3 setRelCenter = sunset.forward - center;
            //model.transform.forward = Vector3.Slerp(riseRelCenter, setRelCenter, Time.time);
            //model.transform.forward += center;
        //}
        //if (move > 0.1f)
        //{
            //Vector3 center = (sunrise.forward + sunset.forward) * 0.5f;
            //Vector3 centerProject = Vector3.Project(center, sunset.forward - sunrise.forward);
            //center = Vector3.MoveTowards(centerProject, center, 1f);           
            //Vector3 riseRelCenter = sunrise.forward - center;
            //Vector3 setRelCenter = sunset.forward - center;
            //model.transform.forward = Vector3.Slerp(setRelCenter, riseRelCenter, Time.time);
            //model.transform.forward += center;
        //}
            
    }
    private void Rotating(float hor,float ver)
    {
        Vector3 dir = new Vector3(hor, 0, ver);
        Quaternion quaDir = Quaternion.LookRotation(dir,Vector3.up);
        model.transform.rotation = Quaternion.Slerp(model.transform.rotation,quaDir,Time.fixedDeltaTime*turnspeed);
        
    }
    private void FixedUpdate()
    {

        if (hor!=0||ver!=0)
        {
           Rotating(hor,ver);
        }
        
        //Quaternion TargetRotation = Quaternion.LookRotation(right.transform.position - model.transform.position, Vector3.up);
        //model.transform.rotation = Quaternion.Slerp(model.transform.rotation, TargetRotation, Time.deltaTime * turnspeed);
        
        if (pi.signalJump)
        {
            if (isGround)
            {
                rigid.velocity += new Vector3(0, 1, 0);
                rigid.AddForce(Vector3.up * jumpSpeed);
                isGround = false;
            }
        }
        if (move>0)
        {
            
            if (pi.signalRun)
            {
                rigid.position += new Vector3(pi.signalMove * runSpeed * Time.fixedDeltaTime, 0, 0);
            }
            else
            {
                rigid.position += new Vector3(pi.signalMove * walkSpeed * Time.fixedDeltaTime, 0, 0);
            }
        }
        if(mover>0)
        {
              //Debug.Log("1");
           if (pi.signalRun)
           {
               rigid.position += new Vector3(0, 0, pi.signalMover * runSpeed * Time.fixedDeltaTime);
           }
            else
           {
                rigid.position += new Vector3(0, 0, pi.signalMover * walkSpeed * Time.fixedDeltaTime);
           }
         }
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, Vector3.up); 
        rigid.position += animDeltaPos;
        animDeltaPos = Vector3.zero;
    }
    public void ApplyAnimDeltaPos(object deltaPos)
    {
        animDeltaPos = (Vector3)deltaPos;
    }
    public void canMove()
    {
        pi.inputEnabled = true;
    }
    public void cantMove()
    {
        pi.inputEnabled = false;
        pi.signalMove = 0.0f;
        pi.signalMover = 0.0f;
        //if (pi.signalJump) pi.signalJump = false;
        if (pi.signalRoll) pi.signalRoll = false;
        if (pi.signalDash) pi.signalDash = false;
        if (pi.signalStep) pi.signalStep = false;
        //if (pi.signalAttack) pi.signalAttack = false;
    }
}
