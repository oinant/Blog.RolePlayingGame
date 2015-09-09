using System.Runtime.InteropServices;

namespace Blog.RolePlayingGame.Core
{
    public interface ITarget
    {
        void ReceivePhysicalAttack(int strength);
        void ReceiveMagicalAttack(int strength);
    }

    public class Hero
    {
        public HeroClass Class { get; private set; }
        public string Name { get; private set; }
        public int Level { get; private set; }
        public int Health { get; private set; }
        public int Strength { get; private set; }
        public int Spirit { get; private set; }
        public int Speed { get; private set; }

        public Hero(HeroClass @class, string name, int level, int health, int strength, int spirit, int speed)
        {
            Class = @class;
            Name = name;
            Level = level;
            Health = health;
            Strength = strength;
            Spirit = spirit;
            Speed = speed;
        }

        public void Hit(ITarget target)
        {
            target.ReceivePhysicalAttack(this.Strength);
        }

        public void Spell(ITarget target)
        {
            target.ReceiveMagicalAttack(this.Spirit);
        }
    }

    public enum HeroClass
    {
        Warrior = 1,
        Wizard = 2,
        Thief = 3
    }
}