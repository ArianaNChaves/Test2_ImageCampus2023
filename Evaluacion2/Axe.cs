namespace Evaluacion2;

public class Axe : Weapon
{
    private const float CriticalDamage = 1.5f;
    public Axe(string name, float attack) : base(name, attack)
    {
        criticalDamage = CriticalDamage;
    }
    public override float GetAttackDamage(AttackType attackType, bool isCrit, int dodgeChance)
    {
        Random random = new Random();

        float attackDamage = 0;
        
        // Check if attack will hit
        if (random.Next(1, 101) <= dodgeChance)
        {
            return 0;
        }
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
                attackDamage += attack + attack / 4;
            }
        }

        return attackDamage;
    }
}