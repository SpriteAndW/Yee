using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Manager;
using Assets.Script.Skill;

public class ThunderPalm : ThunderBase
{
    private void Awake()
    {
        Id = 0;
    }
    private void Update()
    {
        ForwardMove();
    }
}
