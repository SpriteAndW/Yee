using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Script.Manager;
using UnityEngine;

public class SphereLaunch : MonoBehaviour
{
    private Rigidbody rb;

    public float force = 15;

    private GameObject target;
    private Vector3 direction;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindWithTag("Player");
        rb.velocity = Vector3.one;
    }

    private void Start()
    {
        FlyToTarget();
    }

    private void FlyToTarget()
    {
        direction = (target.transform.position - transform.position + Vector3.up).normalized;
        rb.AddForce(direction * force, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<Collider>().gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.IllusionBlinding();
            PlayerManager.Instance.BeConfused();

            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerManager.Instance.IllusionBlinding();
            PlayerManager.Instance.BeConfused();


            Destroy(this.gameObject);
        }
    
        if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        
    }
}