namespace Evaluacion2;

public class Axe : Weapon
{
    public Axe(string name, float attack) : base(name, attack)
    {
    }

    public override float GetAttackDamage(AttackType attackType, bool isCrit)
    {
        float attackDamage = 0;
        if (attackType == AttackType.Slashing)
        {
            if (isCrit)
            {
                attackDamage += (attack + attack / 2) * 3;

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
                attackDamage += attack * 2 + attack * 2;
            }
            else
            {
                attackDamage += attack * 2 + attack;
            }
        }

        return attackDamage;
    }
}