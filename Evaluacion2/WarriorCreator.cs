namespace Evaluacion2;

public class WarriorCreator
{
    private static Warrior warrior;
    private static Weapon weapon;
    private static Armor armor;
    
    public static Warrior CreateWarrior()
    {
        string name;
        Console.WriteLine("Write the warrior name");
            name = Console.ReadLine()!;

            Console.WriteLine("Choice a weapon type: ");
            Console.WriteLine("1. Spear");
            Console.WriteLine("2. Sword");
            Console.WriteLine("3. Axe");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    weapon = new Spear("Spear",30);
                    break;
                case 2:
                    weapon = new Sword("Sword", 50);
                    break;
                case 3:
                    weapon = new Axe("Axe", 70);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }
            
            Console.WriteLine("Choice a armor type: ");
            Console.WriteLine("1. Light");
            Console.WriteLine("2. Medium");
            Console.WriteLine("3. Heavy");
            option = Convert.ToInt32(Console.ReadLine());
            switch (option)
            {
                case 1:
                    armor = new LightArmor("LightArmor",20,10);
                    break;
                case 2:
                    armor = new MediumArmor("MediumArmor",40,25);
                    break;
                case 3:
                    armor = new HeavyArmor("HeavyArmor",60,50);
                    break;
                default:
                    Console.WriteLine("Error");
                    break;
            }

            warrior = new Warrior(name, 500);
            warrior.SetWeapon(weapon);
            warrior.SetArmor(armor);

            return warrior;
    }
}