namespace Evaluacion2;

public class Axe : Weapon
{
    public Axe(string name, float attack) : base(name, attack)
    {
    }

    public override float GetAttackDamage(AttackType attackType, bool isCrit)
    {
        throw new NotImplementedException();
    }
}