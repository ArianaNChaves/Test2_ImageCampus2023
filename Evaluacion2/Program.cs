using static Evaluacion2.Utils;
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

}