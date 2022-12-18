using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public StateManager player;
    public EnemyStateManager enemy;


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            player.BeAttacked();
            //Invoke("player.BeAttacked",(float)0.3);
        }
        if(other.gameObject.tag=="Enemy")
        {
            enemy.BeAttacked();
        }
    }
}
