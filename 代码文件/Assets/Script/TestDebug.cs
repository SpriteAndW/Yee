using System.Collections.Generic;
using System.Net;
using Assets.Plugins.System;
using Assets.Script.Manager;
using UnityEngine;

public class TestDebug : MonoBehaviour
{
    public TimerV TimeTest;

    public List<string> nmes = new();
    public List<string> des = new();
    // Start is called before the first frame update
    private void Start()
    {
        TimeTest = TimeLineV.Register(2f);
        for (var i = 0; i < GameConfigManager.Instance.GetDescriptionLines(); i++)
        {
            nmes.Add(DataManager.Instance.GetItemNameById(i));
            des.Add(DataManager.Instance.GetItemDescriptionById(i));
        }
    }
}