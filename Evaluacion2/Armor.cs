namespace Evaluacion2;

public abstract class Armor
{
    protected string name;
    protected float defense;
    protected float weight;
    
    public Armor(string name, float defense, float weight)
    {
        this.name = name;
        this.defense = defense;
        this.weight = weight;
    }

    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }

    public float Defense
    {
        get => defense;
        set => defense = value;
    }

    public float Weight
    {
        get => weight;
        set => weight = value;
    }

    public abstract float MitigateDamage(float damage);
}