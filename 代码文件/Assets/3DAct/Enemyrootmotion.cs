using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyrootmotion : MonoBehaviour
{
    private Rigidbody rigid;
    private Vector3 animDeltaPos;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        rigid.position += animDeltaPos;
        animDeltaPos = Vector3.zero;
    }
    public void ApplyAnimDeltaPos(object deltaPos)
    {
        animDeltaPos = (Vector3)deltaPos;
    }
}
