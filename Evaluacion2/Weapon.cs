namespace Evaluacion2;

public abstract class Weapon
{
    protected string name;
    protected float attack;
    protected float criticalDamage;

    public enum  AttackType //todo pasar a ingles xd
    {
        Piercing, //ignora mas o toda la defensa tiene menos chance de critico
        Slashing, // el normal
        
    }

    protected Weapon(string name, float attack)
    {
        this.name = name;
        this.attack = attack;
        this.criticalDamage = 0;
    }

    public abstract float GetAttackDamage(AttackType attackType, bool isCrit);

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public float Attack
    {
        get => attack;
        set => attack = value;
    }
    
}