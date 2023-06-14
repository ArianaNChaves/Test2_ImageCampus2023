namespace Evaluacion2;

public class Axe : Weapon
{
    private const float CriticalDamage = 1.5f;
    public Axe(string name, float attack) : base(name, attack)
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
                attackDamage += (attack + attack / 2) * criticalDamage;

            }
            else
            {
                attackDamage += attack + attack / 2;
            }
        }

        if (attackType == AttackType.Piercing)
        {
            if (isCrit)
            {
                attackDamage += attack * criticalDamage + attack * criticalDamage;
            }
            else
            {
                attackDamage += attack * criticalDamage + attack;
            }
        }

        return attackDamage;
    }
}