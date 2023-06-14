namespace Evaluacion2;
using static Utils;

public class Game
{
    private int rounds;
    private Warrior player1;
    private Warrior player2;
    
    public Game(Warrior player1, Warrior player2)
    {
        this.player1 = player1;
        this.player2 = player2;
        rounds = 0;
    }

    public void Play()
    {//guardar las estadisticas de los players para poder resetearlas
        while (player1.IsAlive() && player2.IsAlive())
        {
            rounds++;
            Console.WriteLine("----------------|| ROUND: " + rounds + " ||----------------");
            Console.WriteLine(player1.Name + ": Health: " + player1.GetCurrentHealth());
            Console.WriteLine(player2.Name + ": Health: " + player2.GetCurrentHealth());
            Console.WriteLine("=================|| CHOICE " + player1.Name + " ||=================");

            Console.WriteLine("1. Slaying Attack");
            Console.WriteLine("2. Piercing Attack");
            int player1Option = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("=================|| CHOICE " + player2.Name + " ||=================");
            Console.WriteLine("1. Slaying Attack");
            Console.WriteLine("2. Piercing Attack");
            int player2Option = Convert.ToInt32(Console.ReadLine());

            Random random = new Random();
            int firstAttack = random.Next(1,3);

            switch (firstAttack)
            {
                case 1:
                    PlayRound(player1, player2,player1Option);
                    PlayRound(player2, player1,player2Option);
                    break;
                case 2:
                    PlayRound(player2, player1,player2Option);
                    PlayRound(player1, player2,player1Option);
                    break;
            }

        }

        if (player1.IsAlive())
        {
            Console.WriteLine("Gano " + player1.Name);
        }
        else
        {
            Console.WriteLine("Gano " + player2.Name); 
        }
    }
    
    private void PlayRound(Warrior first, Warrior second, int option)
    {
        bool isCritic1 = IsCritic(50, first);
        bool isCritic2 = IsCritic(80, first);
        float damage = 0;
        switch (option)
        {  
            case 1:
                // slaying attack
                damage = first.Attack(second, Weapon.AttackType.Slashing, isCritic1);
                if (isCritic1)
                {
                    Console.WriteLine(first.Name + " hizo un daño critico de " + damage + " a " + second.Name + "!!");
                }
                else
                {
                    Console.WriteLine(first.Name + " hizo un daño de " + damage + " a " + second.Name + "!!"); 
                }
                
                Console.WriteLine("a " + second.Name + " le queda " + second.CurrentHealth + " puntos de vida");
                break;
            case 2:
                // piercing attack
                damage = first.Attack(second, Weapon.AttackType.Piercing, isCritic2);
                if (isCritic2)
                {
                    Console.WriteLine(first.Name + " hizo un daño critico de " + damage + " a " + second.Name + "!!");
                }
                else
                {
                    Console.WriteLine(first.Name + " hizo un daño de " + damage + " a " + second.Name + "!!"); 
                }
                
                Console.WriteLine("a " + second.Name + " le queda " + second.CurrentHealth + " puntos de vida");
                break;
        }

    }
    
}