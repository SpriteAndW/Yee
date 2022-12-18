using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    int num;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Ground")
        {
            num++;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Ground")
        {
            num--;
        }
    }
    public bool IsGround()
    {
        if (num > 0) return true;
        else return false;
    }
}
