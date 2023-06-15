namespace Evaluacion2;
public class Sword : Weapon
{
    private const float CriticalDamage = 2.5f;
    public Sword(string name, float attack) : base(name, attack)
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
                attackDamage = 3 * (attack * criticalDamage);
            }
            else
            {
                attackDamage = attack;
            }
        }
        return attackDamage;
    }
}