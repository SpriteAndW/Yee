using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateManager : MonoBehaviour
{
    [Header("attribute")]
    public EnemyStateManager enemy;

    public int Hp=10;
    public int maxHp =10;
    public int Attack =3;
    public int Defend =1;

    public void BeAttacked()
    {
        Hp -= enemy.Attack-Defend;
    }
    public void GetHp(int h)
    {
        Hp += h;
    }
    void Update()
    {
        if (Hp <= 0) SceneManager.LoadScene(1);
    }
}
