using System.ComponentModel.Design.Serialization;
using static Evaluacion2.Weapon;

namespace Evaluacion2;
public class Warrior
{
    private string name;
    private Weapon weapon;
    private Armor armor;
    private float maxHealth;
    private float currentHealth;
    public Warrior(string name, float maxHealth)
    {
        this.name = name;
        this.maxHealth = maxHealth;
        currentHealth = this.maxHealth;
    }
    public string Name
    {
        get => name;
        set => name = value ?? throw new ArgumentNullException(nameof(value));
    }
    public Weapon Weapon
    {
        get => weapon;
        set => weapon = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Armor Armor
    {
        get => armor;
        set => armor = value ?? throw new ArgumentNullException(nameof(value));
    }

    public float MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public float CurrentHealth
    {
        get => currentHealth;
        set => currentHealth = value;
    }
    public void SetWeapon(Weapon weapon)
    {
        this.weapon = weapon;
    }
    public void SetArmor(Armor armor)
    {
        this.armor = armor;
    }
    public string GetName()
    {
        return name;
    }
    public float ReceiveDamage(float damage)
    {
        float trueDamage = armor.MitigateDamage(damage);
        currentHealth -= trueDamage;
        return trueDamage;
    }

    public float Attack(Warrior warrior, AttackType attackType, bool isCrit, int dodgeChance)
    {
        return warrior.ReceiveDamage(weapon.GetAttackDamage(attackType, isCrit, dodgeChance));
        
    }
    public float GetCurrentHealth()
    {
        return currentHealth;
    }
    public bool IsAlive()
    {
        return currentHealth > 0;
    }
    
    public void RecoverMissingHealth(float percentage)
    {
        float missingHealth = maxHealth - currentHealth;
        int recoveryAmount = (int)(missingHealth * percentage);
        currentHealth += recoveryAmount;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
    }
}