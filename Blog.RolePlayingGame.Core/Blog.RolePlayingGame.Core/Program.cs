using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.RolePlayingGame.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            var myHero = new HeroBuilder()
                                .OfWarriorClass()
                                .WithName("Mighty Hall-Dard")
                                .WithLevel(2)
                                .BoostStrength()
                                .BoostSpirit()
                                .Create();

            var enemy = new Monster();

            myHero.Hit(enemy);
        }
     }

    class Monster : ITarget
    {
        private int health = 15;
        private int _strength = 3;
        private int _spirit = 3;

        public void ReceivePhysicalAttack(int incomingStrength)
        {
            health -= Math.Max(0, (incomingStrength - _strength));
        }

        public void ReceiveMagicalAttack(int strength)
        {
            throw new NotImplementedException();
        }
    }
}
