using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script.Skill;
using Assets.Script.Manager;
using RootLibrary;
using UnityEngine.Rendering.PostProcessing;

public class BeConfused : HallucinationBase
{
    private LensDistortion _vLens;
    float target = 1;
    float changeSpeed = 3f;
    float PN;//¼ÇÂ¼targetµÄ·ûºÅ

    public void Awake()
    {
        Id = 4;       
        _vLens = gameObject.GetComponent<PostProcessVolume>().profile.GetSetting<LensDistortion>();
    }

    private void Update()
    {
        PN =MathV.Abs(target) /target;
        

        if (MathV.Abs(_vLens.intensity.value - target) > 1f)
        {
            if (target < 0)
            {
                if (_vLens.intensity.value > target) _vLens.intensity.value += Time.deltaTime * changeSpeed * PN;
                else _vLens.intensity.value += Time.deltaTime * changeSpeed *(-PN);
            }
            else
            {
                if (_vLens.intensity.value > target) _vLens.intensity.value += Time.deltaTime * changeSpeed * (-PN);
                else _vLens.intensity.value += Time.deltaTime * changeSpeed * PN;
            }          
        }
        else
        {
            if(MathV.RandomV.NextDouble()<0.5) target = MathV.Next(30 , 64);
            else target= MathV.Next(-64,-30);
        }
    }
}
