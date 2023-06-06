namespace Evaluacion2;
/*
 * Que ataque dos veces y el segundo ataque sea la mitad del primero, ademas que solo el segundo ataque puede aplicar critico y solo aplica el daño base del arma
 */
public class Spear : Weapon
{
 public Spear(string name, float attack) : base(name, attack)
 {
 }

 public override float GetAttackDamage(AttackType attackType, bool isCrit)
 { 
   float attackDamage = 0;
   float totalDamage = 0;
   
   
   if (attackType == AttackType.Slashing)
   {
       
       if (isCrit)
       {
           Console.WriteLine("Critical Attack");
           attackDamage = attack + attack * 0.8f;
           totalDamage = attackDamage + (attack / 2) * 2;
       }
       else
       {
           attackDamage = attack + attack * 0.8f;
       }
   }
   

   return attackDamage;
 }
}