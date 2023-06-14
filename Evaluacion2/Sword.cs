namespace Evaluacion2;
public class Sword : Weapon
{
    private const float CriticalDamage = 1.5f;
    public Sword(string name, float attack) : base(name, attack)
    {
        criticalDamage = CriticalDamage;
    }
    public override float GetAttackDamage(AttackType attackType, bool isCrit)
    {
        float attackDamage = 0;
        if (attackType == AttackType.Slashing)
        {
            if (isCrit)
            {
                attackDamage = (attack + attack * 0.8f) * criticalDamage;
            }
            else
            {
                attackDamage = attack + attack * 0.8f;
            }
        }
        if (attackType == AttackType.Piercing)
        {
            if (isCrit)
            {
                attackDamage = attack * criticalDamage;
            }
            else
            {
                attackDamage = attack;
            }
        }
        return attackDamage;
    }
}