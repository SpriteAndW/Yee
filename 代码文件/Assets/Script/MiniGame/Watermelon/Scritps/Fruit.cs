using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Plugins.System;
using MiniGame;

public class Fruit : MonoBehaviour
{
    public FruitType FruitType = FruitType.One;

    public bool IsMove = false;

    public FruitState FruitState = FruitState.Ready;


    private void Update()
    {
        if (WatermelonManager.instance.GameState == WatermelonGameState.StanBy && FruitState == FruitState.StanBy)
        {
            if (Input.GetMouseButtonDown(0))
            {
                IsMove = true;
            }

            if (Input.GetMouseButtonUp(0) && IsMove)
            {
                IsMove = false;
                gameObject.GetComponent<Rigidbody2D>().gravityScale = 5;
                FruitState = FruitState.Dropping;
                WatermelonManager.instance.GameState = WatermelonGameState.InProgress;
                WatermelonManager.instance.InvoleCreateFruit(1f);
            }

            if (IsMove)
            {
                Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z)); //屏幕坐标转换成unity世界坐标
                // Vector3 mousePos = GetMouseRayPosition();
                // Debug.Log(mousePos);

                if (mousePos.x > WatermelonManager.instance.RightWall.position.x -1)
                {
                    mousePos.x = WatermelonManager.instance.RightWall.position.x-1;
                }

                if (mousePos.x < WatermelonManager.instance.LeftWall.position.x+1)
                {
                    mousePos.x = WatermelonManager.instance.LeftWall.position.x+1;
                }

                this.gameObject.GetComponent<Transform>().position = new Vector3(mousePos.x,
                    this.gameObject.GetComponent<Transform>().position.y,
                    this.gameObject.GetComponent<Transform>().position.z);
            }
        }
    }
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (FruitState == FruitState.Dropping)
        {
            if ((int)FruitState >= (int)FruitState.Dropping)
            {
                if (collision.gameObject.CompareTag("Ground"))
                {
                    WatermelonManager.instance.GameState = WatermelonGameState.StanBy;
                    FruitState = FruitState.Collision;
                }

                if (collision.gameObject.GetComponent<Fruit>())
                {
                    WatermelonManager.instance.GameState = WatermelonGameState.StanBy;
                    FruitState = FruitState.Collision;
                }
            }
        }

        if ((int)FruitState >= (int)FruitState.Dropping)
        {
            if (collision.gameObject.GetComponent<Fruit>())
            {
                if (FruitType == collision.gameObject.GetComponent<Fruit>().FruitType && FruitType < FruitType.Eight)
                {
                    float thisposxy = this.transform.position.x + this.transform.position.y;
                    float collisionPosxy = collision.transform.position.x + transform.position.y;

                    if (thisposxy > collisionPosxy)
                    {
                        WatermelonManager.instance.CobineNewFruit(FruitType, this.transform.position,
                            collision.transform.position);
                        Destroy(this.gameObject);
                        Destroy(collision.gameObject);
                    }
                }
            }
        }
    }
}