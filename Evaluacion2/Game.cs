using System.Diagnostics.Tracing;
using System.Runtime.Intrinsics.Arm;

namespace Evaluacion2;
using static Utils;

public enum DayNightCycle
{
    Day,
    Night
}

public struct PlayerOriginalStats
{
    private float damage;
    private float defense;
    public PlayerOriginalStats(Warrior warrior)
    {
        this.damage = warrior.Weapon.Attack;
        this.defense = warrior.Armor.Defense;
    }

    public float Damage => damage;

    public float Defense => defense;
}

public enum Event
{
    Heatwave,
    Rain,
    Sandstorm,
    FullMoon,
    SoftBreeze,
    Hailstorm
}
public class Game
{
    private const int DayDodgeChance = 10;
    private const int NightDodgeChance = 20;
    
    private int rounds;
    private int dodgeChance;
    private Warrior player1;
    private Warrior player2;
    private DayNightCycle day;
    private Random random;
    private PlayerOriginalStats player1Stats;
    private PlayerOriginalStats player2Stats;
    public Game(Warrior player1, Warrior player2)
    {
        this.player1 = player1;
        this.player2 = player2;
        dodgeChance = DayDodgeChance;
        rounds = 0;
        day = DayNightCycle.Day;
        random = new Random();
        player1Stats = new PlayerOriginalStats(player1);
        player2Stats = new PlayerOriginalStats(player2);
    }
    public void Play()
    {
        while (player1.IsAlive() && player2.IsAlive())
        {
            Console.Clear();
            ResetStats();   
            rounds++;

            // 45% de que haya un evento cada ronda
            if (random.Next(101) <= 45)
            {
                TriggerEvent();
            }

            // Ciclo dia / noche cada 6 rondas
            if (rounds % 6 == 0)
            {
                switch (day)
                {
                    case DayNightCycle.Day:
                        Console.WriteLine("The day is ending. Both of you lose some vision (+Dodge chance)");
                        dodgeChance += 10;
                        Console.WriteLine("New dodge chance is " + dodgeChance);
                        day = DayNightCycle.Night;
                        break;
                    case DayNightCycle.Night:
                        Console.WriteLine("The sun starts to rise. You recover vision on the enemy (Original dodge chance)");
                        Console.WriteLine("New dodge chance is " + dodgeChance);
                        day = DayNightCycle.Day;
                        break;
                }
            }

            Console.WriteLine("Round's dodge chance: " + dodgeChance);
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

            int firstAttack = random.Next(1,3);

            Console.Clear();
            switch (firstAttack)
            {
                case 1:
                    PlayRound(player1, player2,player1Option);
                    if (!player2.IsAlive())
                    {
                        Console.WriteLine(player2.Name + " died from the attack!");
                        break;
                    }
                    PlayRound(player2, player1,player2Option);
                    break;
                case 2:
                    PlayRound(player2, player1,player2Option);
                    if (!player1.IsAlive())
                    {
                        Console.WriteLine(player1.Name + " died from the attack!");
                        break;
                    }
                    PlayRound(player1, player2,player1Option);
                    break;
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        if (player1.IsAlive())
        {
            Console.Clear();
            Console.WriteLine(player1.Name + " won the battle after " + rounds + " rounds");
        }
        else
        {
            Console.Clear();
            Console.WriteLine(player2.Name + " won the battle after " + rounds + " rounds"); 
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
                damage = first.Attack(second, Weapon.AttackType.Slashing, isCritic1, dodgeChance);
                if (isCritic1 && damage != 0)
                {
                    Console.WriteLine(first.Name + " dealt " + damage + " damage to " + second.Name + " with a critical strike using a Slaying Attack!");
                }
                else if (damage == 0)
                {
                    Console.WriteLine(first.Name + " missed the attack!");
                }
                else
                {
                    Console.WriteLine(first.Name + " dealt " + damage + " damage to " + second.Name + " using a Slaying Attack!"); 
                }
                
                Console.WriteLine(second.Name + " has " + second.CurrentHealth + " health points left");
                Console.WriteLine();
                break;
            case 2:
                // piercing attack
                damage = first.Attack(second, Weapon.AttackType.Piercing, isCritic2, dodgeChance);
                if (isCritic2 && damage != 0)
                {
                    Console.WriteLine(first.Name + " dealt " + damage + " damage to " + second.Name + " with a critical strike using a Piercing Attack!");
                }
                else if (damage == 0)
                {
                    Console.WriteLine(first.Name + " missed the attack!");
                }
                else
                {
                    Console.WriteLine(first.Name + " dealt " + damage + " damage to " + second.Name + " using a Piercing Attack!!"); 
                }
                
                Console.WriteLine(second.Name + " has " + second.CurrentHealth + " health points left");
                Console.WriteLine();
                break;
        }
    }

    private void TriggerEvent()
    {
        Array values = Enum.GetValues(typeof(Event));
        Event[] events = (Event[])values;
        Event randomEvent = events[random.Next(events.Length)];

        switch (randomEvent)
        {
            case Event.Heatwave:
                Console.WriteLine("Heatwave event occurred. (Both drop their armors)");
                player1.Armor.Defense = 0;
                player2.Armor.Defense = 0;
                break;
            case Event.Rain:
                Console.WriteLine("Rain event occurred. (Both weapons slips off)");
                player1.Weapon.Attack *= 0.4f;
                player2.Weapon.Attack *= 0.4f;
                break;
            case Event.Sandstorm:
                Console.WriteLine("Sandstorm event occurred. (You can't see each other. More dodge chance)");
                dodgeChance = 50;
                break;
            case Event.FullMoon:
                Console.WriteLine("Full Moon event occurred. (Both heal a % of missing health)");
                float recoveryPercentage = 0.30f;
                player1.RecoverMissingHealth(recoveryPercentage);
                player2.RecoverMissingHealth(recoveryPercentage);
                break;
            case Event.SoftBreeze:
                Console.WriteLine("Soft Breeze event occurred. (Both deal more damage)");
                player1.Weapon.Attack *= 1.2f;
                player2.Weapon.Attack *= 1.2f;
                break;
            case Event.Hailstorm:
                Console.WriteLine("Hailstorm event occurred. (Both take some damage)");
                player1.CurrentHealth -= 50;
                player2.CurrentHealth -= 50;
                break;
            default:
                Console.WriteLine("Unknown event occurred.");
                break;
        }
        Console.WriteLine();
    }

    private void ResetStats()
    {
        dodgeChance = day is DayNightCycle.Day ? DayDodgeChance : NightDodgeChance;
        player1.Weapon.Attack = player1Stats.Damage;
        player1.Armor.Defense = player1Stats.Defense;
        player2.Weapon.Attack = player2Stats.Damage;
        player2.Armor.Defense = player2Stats.Defense;
    }
    
}