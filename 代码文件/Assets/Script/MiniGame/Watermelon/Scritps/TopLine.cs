using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Plugins.System;
using MiniGame;
using UnityEngine;

public class TopLine : MonoBehaviour
{
    public bool isGameOver = false;

    public float speed = 0.001f;

    private WatermelonManager _watermelonManager;


    private void Awake()
    {
        _watermelonManager = transform.GetComponentInParent<WatermelonManager>();
    }

    void Update()
    {
        if (isGameOver)
        {
            if (transform.position.y > -5.55f)
            {
                this.gameObject.transform.Translate(Vector3.down * speed);
            }
            else
            {
                isGameOver = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((int)_watermelonManager.GameState < (int)WatermelonGameState.GameOver)
        {
            if (collision.transform.GetComponent<Fruit>())
            {
                if (collision.gameObject.GetComponent<Fruit>().FruitState == FruitState.Collision)
                {
                    _watermelonManager.GameState = WatermelonGameState.GameOver;
                    //游戏失败清楚所有球体
                    ChangeGameOverState();
                }
            }
        }

        if ((int)_watermelonManager.GameState >= (int)WatermelonGameState.CalculateScore)
        {
            Destroy(collision.gameObject);
        }
    }

    void ChangeGameOverState()
    {
        isGameOver = true;

        _watermelonManager.GameState = WatermelonGameState.CalculateScore;
    }
}