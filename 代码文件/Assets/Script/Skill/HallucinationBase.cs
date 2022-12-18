using Assets.Script.Manager;

namespace Assets.Script.Skill
{
    public class HallucinationBase : SkillBase
    {
        override public void OnEnable()
        {
            base.OnEnable();
            if (gameObject != null) SkillManager.Instance.AddObj(Id, gameObject);
            if(Id==4) StartCoroutine(SkillManager.Instance.BeConfused(gameObject));
        }
    }
}