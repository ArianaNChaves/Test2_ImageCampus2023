namespace Evaluacion2;
public class Spear : Weapon
{
    private const float CriticalDamage = 1.5f;
 public Spear(string name, float attack) : base(name, attack)
 {
     criticalDamage = CriticalDamage;
 }
 public override float GetAttackDamage(AttackType attackType, bool isCrit)
 { 
   float attackDamage = 0;
   int hitAgain = 50, limit = 0, hitChance = 80;
   
   Random random = new Random();
   
   if (attackType == AttackType.Slashing)
   {
       int plusAttack = isCrit ? 4 : 3;

       for (int i = 0; i < plusAttack; i++)
       {
           attackDamage += attack;
       }
       
       while (random.Next(1,101) <= hitAgain && limit <= 10)
       {
           attackDamage += attack;
           limit++;
       }
   }
   if (attackType == AttackType.Piercing)
   {
       for (int i = 0; i < 3; i++)
       {
           if (isCrit)
           {
               attackDamage += attack * 2;
               hitChance -= 20;
           }
           else
           {
               attackDamage += attack;
               hitChance += 15;
           }
           if (random.Next(1,101) <= hitChance)
           {
               isCrit = true;
           }
           else
           {
               isCrit = false;
           }
       }
   }
   return attackDamage;
 }
}