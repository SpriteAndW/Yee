using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Skill;
using Assets.Script.Manager;
using Assets.Plugins.System;

public class ThunderRing : ThunderBase
{
    private Dictionary<string, int> _attackedList = new();

    private void Awake()
    {
        Id = 1;
        if (!SkillManager.Instance.SkillRangeElement.ContainsKey(Id))
        {         
            SkillManager.Instance.SkillRangeElement.Add(Id, new());
        }
        else SkillManager.Instance.SkillRangeElement[Id] = new();
    }

    override public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Character")) return;
        var t = other.GetComponent<IFight>();
        if (t == null) return;

        if (!_attackedList.ContainsKey(other.name))
        {
            _attackedList.Add(other.name, 1);
            SkillManager.Instance.SkillRangeElement[Id].Add(other.gameObject);
            if (_attackedList.Count == 1) StartCoroutine(SkillManager.Instance.ThunderRing(Id));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_attackedList.ContainsKey(other.name))
        {      
            _attackedList.Remove(other.name);
            SkillManager.Instance.SkillRangeElement[Id].Remove(other.gameObject);
        }
    }

    private void OnDisable()
    {
        _attackedList.Clear();
        SkillManager.Instance.SkillRangeElement[Id].Clear();
    }
}
