using System;

namespace wizards_ninjas_samurais
{
    class Program
    {
        static void Main(string[] args)
        {
            Human bob = new Human("Bobby");
            Wizard robert = new Wizard("Robert");
            Ninja naz = new Ninja("Nazzy");
            Samurai jack = new Samurai("Jack");
            
            bob.Attack(naz);
            naz.Attack(bob);
        }
    }
    class Human
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }
        }
        public Human(string name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 100;
        }
        public Human(string name, int str, int inteli, int dex, int hp)
        {
            Name = name;
            Strength = str;
            Intelligence = inteli;
            Dexterity = dex;
            health = hp;
        }
        public virtual int Attack(Human target)
        {
            int damage = Strength * 3;
            target.health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            if(target.Health < 0)
            {
                target.Health = 0;
                System.Console.WriteLine($"{target.Name}'s health has reached 0! {target.Name} has died!");
            }
            return target.health;
        }
    }
    class Wizard: Human
    {
        public Wizard(string name) : base (name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 25;
            Dexterity = 3;
            health = 50;
        }
        public override int Attack(Human target)
        {
            int damage = Intelligence * 5;
            target.Health -= damage;
            Console.WriteLine($"{Name}, the Wizard, attacked {target.Name} for {damage} damage!");
            health += damage;
            if(health > 50)
            {
                health = 50;
                System.Console.WriteLine($"{Name}, the Wizard, is now at full health!");
            }
            else
            {
                System.Console.WriteLine($"{Name}, the Wizard, has restored {damage} health!");
            }
            if(target.Health < 0)
            {
                target.Health = 0;
                System.Console.WriteLine($"{target.Name}'s health has reached 0! {target.Name} has died!");
            }
            return target.Health;
        }
        public int Heal(Human target)
        {
            int health_restored = 10 * Intelligence;
            target.Health += health_restored;
            System.Console.WriteLine($"{target.Name} been healed for {health_restored} health!");
            if(target.Health < 0)
            {
                target.Health = 0;
                System.Console.WriteLine($"{target.Name}'s health has reached 0! {target.Name} has died!");
            }
            return target.Health;
        }
    }
    class Ninja: Human
    {
        public Ninja(string name) : base (name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 175;
            health = 100;
        }
        public override int Attack(Human target)
        {
            int damage = 5 * Dexterity;
            target.Health -= damage;
            Console.WriteLine($"{Name} attacked {target.Name} for {damage} damage!");
            
            Random rand = new Random();
            if(rand.Next(0,101) <= 20)
            {
                target.Health -= 10;
                Console.WriteLine($"{Name} attacked {target.Name} for an addittional {damage} damage!");
            }
            if(target.Health < 0)
            {
                target.Health = 0;
                System.Console.WriteLine($"{target.Name}'s health has reached 0! {target.Name} has died!");
            }
            return target.Health;
        }
        public int Steal(Human target)
        {
            target.Health -= 5;
            System.Console.WriteLine($"{Name} has stolen 5 health from {target.Name}!");
            health += 5;
            System.Console.WriteLine($"And {Name} has gained 5 bonus health!");
            if(target.Health < 0)
            {
                target.Health = 0;
                System.Console.WriteLine($"{target.Name}'s health has reached 0! {target.Name} has died!");
            }
            return target.Health;
        }
    }
    class Samurai: Human
    {
        public Samurai(string name) : base (name)
        {
            Name = name;
            Strength = 3;
            Intelligence = 3;
            Dexterity = 3;
            health = 200;
        }
        public override int Attack(Human target)
        {
            base.Attack(target);
            if(target.Health < 50)
            {
                target.Health = 0;
                System.Console.WriteLine($"{Name} being a the Samurai, has executed {target.Name}!");
            }
            if(target.Health < 0)
            {
                target.Health = 0;
                System.Console.WriteLine($"{target.Name}'s health has reached 0! {target.Name} has died!");
            }
            return target.Health;
        }
        public int Meditate()
        {
            health = 200;
            System.Console.WriteLine($"{Name}, the Samurai, has meditated and recovered to full health!");
            return Health;
        }
    }
}
