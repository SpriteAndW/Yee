using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Camara : MonoBehaviour
{
    private Vector3 offset;
    public Transform player; 
    void Start()
    {
        offset = player.position - transform.position;
        //transform.position = player.position;
   }
 
     void Update()
    {
        //transform.position = Vector3.Lerp(transform.position, player.position - offset,Time.deltaTime*5);
        transform.position = Vector3.Lerp(transform.position, player.position - offset, 1);
    }

}
