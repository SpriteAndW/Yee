using Assets.Plugins.System;

namespace Assets.Script.Characters
{
    public class NeutralBase : OtherRole
    {
        public override void Awake()
        {
            base.Awake();
            RoleOfType = RoleType.Neutral;
        }

        public override void ApplyDamage(float damage)
        {
            base.ApplyDamage(damage);
            RoleOfType = RoleType.Enemy;
        }
    }
}