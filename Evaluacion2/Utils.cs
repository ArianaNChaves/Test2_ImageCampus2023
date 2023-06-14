namespace Evaluacion2;

public class Utils
{
    public static bool IsCritic(float chance, Warrior warrior)
    {
        Random random = new Random();
        Armor armor = warrior.Armor;

        switch (armor)
        {
            case LightArmor:
                chance *= 1.5f;
                break;
            case MediumArmor:
                chance *= 1.0f;
                break;
            case HeavyArmor:
                chance *= 0.5f;
                break;
            default:
                Console.WriteLine("Error");
                break;
        }
        return random.Next(1,101) <= chance;
    }

    
    
}