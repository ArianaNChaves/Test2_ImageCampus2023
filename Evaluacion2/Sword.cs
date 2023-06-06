namespace Evaluacion2;
public class Sword : Weapon
{
    public Sword(string name, float attack) : base(name, attack)
    {
    }
    public override float GetAttackDamage(AttackType attackType, bool isCrit)
    {
        float attackDamage = 0;
        if (attackType == AttackType.Slashing)
        {
            if (isCrit)
            {
                Console.WriteLine("Critical Attack");
                attackDamage = (attack + attack * 0.8f) * 2;
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
                Console.WriteLine("Critical Attack");
                attackDamage = attack * 6;
            }
            else
            {
                attackDamage = attack;
            }
        }
        return attackDamage;
    }
}