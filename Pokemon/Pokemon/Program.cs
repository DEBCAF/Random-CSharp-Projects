using System;
class Pokemon
{
    protected string Name;
    protected int Health;
    protected int AttackPower;
    protected bool fainted = false;
    protected bool isParalyzed = false;
    protected bool isFlaming = false;

    public Pokemon(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
    }

    public virtual void Attack(Pokemon target)
    {
        if (isParalyzed)
        {
            Console.WriteLine($"{Name} is paralyzed and cannot move!");
            isParalyzed = false; 
            return;
        }

        Random rnd = new Random();
        if (!fainted)
        {
            if (rnd.NextDouble() < 0.7) 
            {
                int damage = rnd.Next(1, AttackPower);
                Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
                target.TakeDamage(damage);
            }
            else
            {
                Console.WriteLine($"{Name}'s attack missed!");
            }
        }
        else
        {
            Console.WriteLine($"{Name} has fainted, it cannot attack!");
        }
    }

    public void TakeDamage(int damage)
    {
        if (isFlaming)
        {
            Console.WriteLine($"{Name} is flaming! {Name} takes 10 more damage!");
            Health -= damage;
            Health -= 10;
            isFlaming = false;
            Console.WriteLine($"{Name} takes {damage+10} damage and now has {Health} health remaining.");
        }
        else
        {
            Health -= damage;
            Console.WriteLine($"{Name} takes {damage} damage and now has {Health} health remaining.");
        }

        if (Health <= 0)
        {
            Console.WriteLine($"{Name} has fainted!");
            fainted = true;
        }
    }

    public int GetHealth()
    {
        return Health;
    }

    public void Die()
    {
        if (Health <= 0)
        {
            Console.WriteLine($"{Name} has been defeated!");
        }
    }
    public void SetParalyzed(bool status)
    {
        isParalyzed = status;
    }

    public void SetFlaming(bool status)
    {
        isFlaming = status;
    }

    public string GetName()
    {
        return Name;
    }
}
class ElectricPokemon : Pokemon
{
    public ElectricPokemon(string name, int health, int attackPower) : base(name, health, attackPower) { }
    public override void Attack(Pokemon target)
    {
        Console.WriteLine($"Choose attack for {Name}: 1. Basic Attack 2. Thunder Shock (Special)");
        string choice = Console.ReadLine();
        Random rnd = new Random();
        if (choice == "2")
        {
            if (rnd.NextDouble() < 0.5)
            {
                Console.WriteLine($"{Name} uses Thunder Shock!");
                target.SetParalyzed(true);
                Console.WriteLine($"{target.GetName()} is paralyzed!");
            }
            else
            {
                Console.WriteLine($"{Name} missed the special attack!");
            }
        }
        base.Attack(target);
    }
}
class FirePokemon : Pokemon
{
    public FirePokemon(string name, int health, int attackPower) : base(name, health, attackPower) { }

    public override void Attack(Pokemon target)
    {
        Console.WriteLine($"Choose attack for {Name}: 1. Basic Attack 2. Ember (Special)");
        string choice = Console.ReadLine();
        Random rnd = new Random();
        if (choice == "2")
        {
            if (rnd.NextDouble() < 0.5)
            {
                Console.WriteLine($"{Name} uses Ember!");
                target.SetFlaming(true);
                Console.WriteLine($"{target.GetName()} is flaming!");
            }
            else
            {
                Console.WriteLine($"{Name} missed the special attack!");
            }
        }
        base.Attack(target);
    }
}
class Program
{
    static void Main(string[] args)
    {
        Pokemon pikachu = new ElectricPokemon("Pikachu", 100, 20);
        Pokemon charmander = new FirePokemon("Charmander", 80, 15);

        while (pikachu.GetHealth() > 0 && charmander.GetHealth() > 0)
        {
            pikachu.Attack(charmander);
            Console.ReadLine();
            charmander.Attack(pikachu);
            Console.ReadLine();
        }

        if (pikachu.GetHealth() <= 0)
        {
            pikachu.Die();
        }
        else if (charmander.GetHealth() <= 0)
        {
            charmander.Die();
        }
    }
}