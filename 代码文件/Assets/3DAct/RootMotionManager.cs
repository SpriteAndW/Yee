using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RootMotionManager : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnAnimatorMove()
    {
        SendMessageUpwards("ApplyAnimDeltaPos",anim.deltaPosition);
    }
}
