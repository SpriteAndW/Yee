using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Skill;
using Assets.Script.Manager;
using Assets.Plugins.System;

public class HallucinationBead : HallucinationBase
{
    private void Update()
    {
        ForwardMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Character")) return;

        if (Id == 5) SkillManager.Instance.WoodBead(other.gameObject);//Ä¾»ÃÖé
        else if (Id == 7) SkillManager.Instance.GourdBead(other.gameObject);//ºùÂ«»ÃÖé
        SkillManager.Instance.FinishSkill(Id, gameObject);
    }
}
