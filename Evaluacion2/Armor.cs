namespace Evaluacion2;

public class Armor
{
    private string name;
    private float defense;
    private float weight;

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

    public float MitigateDamage(float damage)
    {
        float mitigateDamage = defense + weight * 0.2f - damage;
        if (mitigateDamage >= 0)
        {
            mitigateDamage = 0;
        }
        else
        {
            mitigateDamage = Math.Abs(mitigateDamage);
        }

        return mitigateDamage;
    }
}