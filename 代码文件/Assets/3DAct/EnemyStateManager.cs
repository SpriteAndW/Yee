using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    public StateManager player;

    public int Hp = 5;
    public int HpMax = 5;
    public int Attack = 2;
    public int defend = 1;

    void Awake()
    {
        player = GetComponent<StateManager>();
    }

    public void BeAttacked()
    {
        Hp -= player.Attack-defend;
    }

}
