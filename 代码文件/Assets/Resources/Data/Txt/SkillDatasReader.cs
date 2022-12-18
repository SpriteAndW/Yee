using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Data;
using Assets.Plugins.System;
using System;

public class SkillDatasReader : MonoBehaviour
{
    public bool isRead;
    public SkillDatas SkillData;

    // Update is called once per frame
    void Update()
    {
        if (isRead)
        {
            isRead = false;
            Read();
        }
    }

    private void Read()
    {
        SkillData.SkillsDatas.Clear();
        var t = Resources.Load<TextAsset>("Data/Txt/¼¼ÄÜ");

        var data = new GameConfigData(t.text);
        var length = data.GetLines();
        for (var i = 0; i < length; i++)
        {
            var _tString = ReadNeeded(data.GetOneById(i.ToString())["ObjList"]);
            var _newData = new SkillData
            {
                Id = Convert.ToInt32(data.GetOneById(i.ToString())["Id"]),
                name = data.GetOneById(i.ToString())["Name"],
                Type = (SkillType)Enum.Parse(typeof(SkillType), data.GetOneById(i.ToString())["Type"]),
                SkillIndictortype = (SkillIndictorType)Enum.Parse(typeof(SkillIndictorType), data.GetOneById(i.ToString())["SkillIndictorType"]),
                NeededObjId = _tString,
                InstantType = (SkillInstateType)Enum.Parse(typeof(SkillInstateType), data.GetOneById(i.ToString())["SkillIndictorType"]),
                SkillPrefab = new GameObject(),
                SkillCD = Convert.ToInt32(data.GetOneById(i.ToString())["SkillCD"]),
                Drain = Convert.ToInt32(data.GetOneById(i.ToString())["Drain"]),
                Speed = (float)Convert.ToDouble(data.GetOneById(i.ToString())["Speed"]),
                Damage = (float)Convert.ToDouble(data.GetOneById(i.ToString())["Damage"]),
                Force = (float)Convert.ToDouble(data.GetOneById(i.ToString())["Force"]),
                Duration = (float)Convert.ToDouble(data.GetOneById(i.ToString())["Duration"]),
                image = null,
                Effects = new GameObject[Convert.ToInt32(data.GetOneById(i.ToString())["EffectNum"])],
                introduction= data.GetOneById(i.ToString())["Introduction"]
            };
            SkillData.SkillsDatas.Add(_newData);
        }
    }

    private string[] ReadNeeded(string target)
    {
        string[] t;
        t = target.Split(",");
        return t;
    }
}
