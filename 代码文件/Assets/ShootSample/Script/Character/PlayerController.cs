using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerCharacter playerCharacter;
    int i;
    void Start()
    {
        playerCharacter = GetComponent<PlayerCharacter>();
    }

    void Update()
    {
        CheakInput();
    }

    private void FixedUpdate()
    {
    }

    //检测按键输入

    void CheakInput()
    {
        playerCharacter.Move(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //GetAxisRaw无加速过程，想要有可以用GetAxis

        if (Input.GetKey(KeyCode.LeftShift))
        {
            playerCharacter.Speed = playerCharacter.slowSpeed;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            playerCharacter.Speed = playerCharacter.fastSpeed;
        }
        if (Input.GetButtonDown("Fire1") && i <15)
        {
            playerCharacter.Shoot(i);
        }
        if (Input.GetButton("Fire1"))
        {
            i++;
            playerCharacter.Shoot(i);
        }
        if (Input.GetButtonUp("Fire1"))
        {
            i = 0;
            playerCharacter.Shoot(i);
        }

    }
}
