using System.Collections;
using Assets.Plugins.Script.BaseClass.Active;
using Assets.Script.Manager;
using RootLibrary;
using UnityEngine;

namespace Assets.Script.FootStep
{
    public class FootStepBase : Actor
    {
        public float FootHeight;
        public int Id;
        public bool IsWalking;
        public float StepDeltaTime;

        public void DoPlay()
        {
            if (IsWalking) return;
            IsWalking = true;
            CancelInvoke();
            StartCoroutine(CheckFootSteps());
            StartCoroutine(PlayFootSteps());
        }

        public void DoStop()
        {
            StopStep();
        }

        public void StopStep()
        {
            IsWalking = false;
            StopAllCoroutines();
        }

        public IEnumerator CheckFootSteps()
        {
            while (IsWalking)
            {
                Id = transform.GetIdInFootSteps(FootHeight);
                yield return new WaitForSeconds(0.1f);
            }
        }

        public IEnumerator PlayFootSteps()
        {
            while (IsWalking)
            {
                if (!IsWalking) yield break;
                var iPortal = transform.GetIPortal(FootHeight);
                iPortal?.OnTriggerAction(transform);
                var iTrap = transform.GetITrap(FootHeight);
                iTrap?.OnTriggerAction();
                if (Id != -1) AudioSource.PlayClipAtPoint(DataManager.Instance.AudioClioDic[Id], transform.position);
                yield return new WaitForSeconds(StepDeltaTime);
            }
        }
    }
}