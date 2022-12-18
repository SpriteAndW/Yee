using Assets.Script.Manager;
using Assets.Script.Characters;
using UnityEngine;

public class PlayerInfo : YiChingPlayer
{
    private new void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerManager.Instance.ThunderPalm();
        }
        if (Input.GetMouseButtonDown(1))
        {
        }
        if (Input.GetMouseButtonDown(2)) PlayerManager.Instance.ThunderPalm();
    }
}