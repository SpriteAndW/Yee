using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetController : MonoBehaviour
{
    public int maxHp = 100;
    public int curHp;

    private void Start()
    {
        curHp = maxHp;
    }
}
