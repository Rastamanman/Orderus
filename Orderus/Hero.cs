using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderus
{
    class Hero
    {
        public Beast myBeast;

        public Hero(string name)
        {
            Random rnd = new Random();
            myBeast = new Beast(name, rnd.Next(70, 100), rnd.Next(70, 80), rnd.Next(45, 55), rnd.Next(40, 50), rnd.Next(10, 30));
        }

        public Hero(string name, int hp, int str, int def, int speed, int luck)
        {
            myBeast = new Beast(name, hp, str, def, speed, luck);
        }

        public bool isAlive()
        {
            return myBeast.isAlive();
        }

        public int ComputeChance()
        {
            return myBeast.ComputeChance();
        }

        public void RapidStrike(Beast enemy)
        {
            if (ComputeChance() <= 10)
            {
                Logger.AddToLog("\t" + myBeast.name + " used Rapid Strike.");
                enemy.getDamage(myBeast.Attack(enemy));
            }
        }

        public int MagicShield(int damage)
        {
            if(ComputeChance() <= 20)
            {
                Logger.AddToLog("\t" + myBeast.name + " used Magic Shield.");
                damage /= 2;
            }
            return damage;
        }

        public int Attack(Beast enemy)
        {
            RapidStrike(enemy);
            return myBeast.Attack(enemy);
        }

        public void getDamage(int damage)
        {
            myBeast.getDamage(MagicShield(damage));
        }

        public bool HaveWorseSpeed(Beast other)
        {
            return myBeast.HaveWorseSpeed(other);
        }

        public bool HaveEqualSpeed(Beast other)
        {
            return myBeast.HaveEqualSpeed(other);
        }

        public bool HaveWorseLuck(Beast other)
        {
            return myBeast.HaveWorseLuck(other);
        }

        public void ShowStats()
        {
            myBeast.ShowStats();
        }
    }
}
