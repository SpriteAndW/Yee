using Assets.Plugins.Script.BaseClass.Hide;
using UnityEngine;

namespace Assets.Script.Manager
{
    public class AnimatorManager : HideActor<AnimatorManager>
    {
        public void SetAnimatiorTrigger(Animator ator, string name)
        {
            ator.SetTrigger(name);
        }

        public void SetAnimatorBool(Animator ator, string name, bool b)
        {
            ator.SetBool(name, b);
        }

        public void SetAnimatorInt(Animator ator, string name, int i)
        {
            ator.SetInteger(name, i);
        }

        public void SetAnimatorInt(Animator ator, string name, float f)
        {
            ator.SetFloat(name, f);
        }

        public void ResetAnimartorTrigger(Animator ator, string name)
        {
            ator.ResetTrigger(name);
        }
    }
}