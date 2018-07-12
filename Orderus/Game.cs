using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orderus
{
    class Game
    {
        private Hero hero;
        private Beast beast;

        public Game()
        {
            hero = new Hero("Orderus");
            beast = new Beast("Evil Beast");
        }

        public bool SetAttacker()
        {
            return hero.HaveWorseSpeed(beast) || (hero.HaveEqualSpeed(beast) && hero.HaveWorseLuck(beast));
        }

        public bool CheckForWinner()
        {
            if(hero.isAlive() == false)
            {
                Logger.AddToLog(hero.myBeast.name + " died, " + beast.name + " won the battle!");
                return true;
            }
            else if(beast.isAlive() == false)
            {
                Logger.AddToLog(beast.name + " died, " + hero.myBeast.name + " won the battle!");
                return true;
            }
            return false;
        }

        public void BeastAttack()
        {
            int damage = beast.Attack(hero.myBeast);
            hero.getDamage(damage);
        }

        public void HeroAttack()
        {
            int damage = hero.Attack(beast);
            beast.getDamage(damage);
        }

        public void Play()
        {
            int cycles = 0;
            bool flag = SetAttacker();

            hero.ShowStats();
            beast.ShowStats();

            Console.WriteLine("\t\t Battle Starts!!!");

            do
            {
                cycles++;
                Logger.AddToLog("Turn " + cycles + ":");
                if (flag == true)
                {
                    BeastAttack();
                    flag = false;
                }
                else
                {
                    HeroAttack();
                    flag = true;
                }
            } while (cycles <= 20 && CheckForWinner() == false);

            if (cycles > 20)
            {
                Logger.AddToLog("Battle ended after " + cycles + " turns, no winner!");
            }
        }
    }
}
