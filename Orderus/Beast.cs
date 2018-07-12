using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderus
{
    class Beast
    {
        public string name;
        private int health;
        private int strength;
        private int defense;
        public int speed;
        public int luck;
        public Random rnd;

        public Beast(string name)
        {
            this.name = name;
            rnd = new Random();
            health = rnd.Next(60, 90);
            strength = rnd.Next(60, 90);
            defense = rnd.Next(40, 60);
            speed = rnd.Next(40, 60);
            luck = rnd.Next(25, 40);
        }

        public Beast(string name, int hp, int str, int def, int speed, int luck)
        {
            this.name = name;
            this.health = hp;
            this.strength = str;
            this.defense = def;
            this.speed = speed;
            this.luck = luck;
            rnd = new Random();
        }

        public bool isAlive()
        {
            return health > 0;
        }

        public bool getLucky()
        {
            if (rnd.Next(100) <= luck)
                return true;
            return false;
        }

        public int ComputeChance()
        {
            return rnd.Next(100);
        }

        public void getDamage(int damage)
        {
            damage -= defense;
            if (damage < 0)
                damage = 0;
            if (getLucky())
                Logger.AddToLog("\t" + this.name + " got lucky, enemy missed their attack.");
            else
            {
                Logger.AddToLog("\t" + this.name + " got hit for " + damage + " damage.");
                health -= damage;
                Logger.AddToLog("\t" + this.name + " have " + health + " health left.");
            }
        }

        public int Attack(Beast enemy)
        {
            Logger.AddToLog("\t" + this.name + " attacked " + enemy.name + " for " + strength + " damage.");
            return strength;
        }

        public bool HaveWorseSpeed(Beast other)
        {
            return speed < other.speed;
        }

        public bool HaveEqualSpeed(Beast other)
        {
            return speed == other.speed;
        }

        public bool HaveWorseLuck(Beast other)
        {
            return luck < other.luck;
        }

        public void ShowStats()
        {
            Console.WriteLine("Name: " + name + "\n\tHealth: " + health + "\n\tDefense: " + defense + "\n\tStrength: " + strength + "\n\tSpeed: " + speed + "\n\tLuck: " + luck);
        }
    }
}
