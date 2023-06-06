
namespace Evaluacion2;
/*
 * Preguntar si le puedo sacar el ref al metodo "GetAttackDamage" porque es HINCHA WEBOS
 * Arreglar main
 * Cambiar los getter y setters a forma normal
 */
class Program
{
    
    static void Main()
    {
        
        Sword sword = new Sword("Bridge", 30);
        Console.WriteLine(sword.GetAttackDamage(Weapon.AttackType.Slashing,  IsCritic(50)));
        
    }
    
    //todo Functions
    static bool IsCritic(int chance)
    {
        Random random = new Random();
        //todo Cambiar la variable show por random.Next..
        int show = random.Next(100);
        Console.WriteLine("random number: " + show);
        return show <= chance ? true : false;
    }
    
}