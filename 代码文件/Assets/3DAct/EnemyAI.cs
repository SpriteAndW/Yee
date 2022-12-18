using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//状态
public enum EnemyState
{
    idle,
    run,
    attack
}

public class EnemyAI : MonoBehaviour
{
    public int Hp = 5;
    public int HpMax = 5;
    public int att = 1;
    public int defend = 0;

    public EnemyState CurrentState = EnemyState.idle;
    private Animator ani;
    private Transform player;
    private NavMeshAgent agent;

    private void Start()
    {
        ani = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        switch (CurrentState)
        {
            case EnemyState.idle:

                if (distance > 1 && distance <= 10)
                {
                    CurrentState = EnemyState.run;
                }
                idle();
                break;
            case EnemyState.run:

                if (distance >= 0 && distance <= 1)
                {
                    CurrentState = EnemyState.attack;
                }
                if (distance > 6)
                {
                    CurrentState = EnemyState.idle;
                }
                run();
                break;
            case EnemyState.attack:

                if (distance > 1)
                {
                    CurrentState = EnemyState.run;
                }
                attack();
                break;
        }
        void idle()
        {
            ani.SetBool("idel", true);
            ani.SetBool("run", false);
            agent.isStopped = true;
        }
        void run()
        {
            ani.SetBool("idel", false);
            ani.SetBool("run", true);
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        void attack()
        {
            ani.SetBool("idel", false);
            ani.SetTrigger("attack");
            ani.SetBool("run", false);
            agent.isStopped = true;
        }
    }

}
