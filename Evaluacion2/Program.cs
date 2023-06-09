
namespace Evaluacion2;
/*
 * Arreglar main
 * Cambiar los getter y setters a forma normal
 */
class Program
{
    
    static void Main()
    {
        
        Spear spear = new Spear("Bridge", 1);
        Console.WriteLine(spear.GetAttackDamage(Weapon.AttackType.Piercing,  IsCritic(80)));
        
    }
    
    //todo Functions
    static bool IsCritic(int chance)
    {
        Random random = new Random();
        //todo Cambiar la variable show por random.Next..
        int show = random.Next(100);
        Console.WriteLine("random number: " + show);
        return show <= chance;
    }
    
}