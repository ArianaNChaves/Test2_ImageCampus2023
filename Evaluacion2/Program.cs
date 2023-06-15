using static Evaluacion2.Utils;
using static Evaluacion2.WarriorCreator;
namespace Evaluacion2;
class Program
{
    
    static void Main()
    { 
        Warrior player1 = CreateWarrior();
        Warrior player2 = CreateWarrior();
      
        Game game = new Game(player1, player2);
        game.Play();
    }

}