using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WallClone : MonoBehaviour
{
    public Vector3 targetScale = new Vector3(30, 10, 1);

    private void Start()
    {
        StartCoroutine(ToBiGToSmall(targetScale));
    }

    private void ScaleChangeToTarget(Vector3 target)
    {
        transform.DOScale(target, 1);
        transform.DOMoveY(target.y / 2, 1);
    }


    private IEnumerator ToBiGToSmall(Vector3 target)
    {
        ScaleChangeToTarget(target);
        yield return new WaitForSeconds(4);
        ScaleChangeToTarget(Vector3.zero);
    }
}