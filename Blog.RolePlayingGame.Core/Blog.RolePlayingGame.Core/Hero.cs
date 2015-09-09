namespace Blog.RolePlayingGame.Core
{
    public interface ITarget
    {
        void ReceivePhysicalAttack(int strength);
        void ReceiveMagicalAttack(int strength);
    }

    public class Hero
    {
        private HeroClass _class;
        private int _level;
        private int _health;
        private int _strenght;
        private int _spirit;
        private int _speed;

        public Hero(HeroClass @class, int level, int health, int strenght, int spirit, int speed)
        {
            _speed = speed;
            _spirit = spirit;
            _strenght = strenght;
            _health = health;
            _level = level;
            _class = @class;
        }

        public void Hit(ITarget target)
        {
            target.ReceivePhysicalAttack(this._strenght);
        }

        public void Spell(ITarget target)
        {
            target.ReceiveMagicalAttack(this._spirit);
        }

        public HeroClass GetClass()
        {
            return _class;
        }

        public object GetHealth()
        {
            return _health;
        }
    }

    public enum HeroClass
    {
        Warrior = 1,
        Wizard = 2,
        Thief = 3
    }

    public class HeroBuilder
    {
        private HeroClass _class;
        private int _level;
        private int _health;

        public HeroBuilder()
        {
            _level = 1;
        }

        public HeroBuilder OfWarriorClass()
        {
            this._class = HeroClass.Warrior;
            return this;
        }

        public HeroBuilder WithLevel(int level)
        {
            this._level = level;
            this._health = level*10;
            return this;
        }

        public Hero Create()
        {
            return new Hero(@class: _class, 
                            level:1, 
                            health: _health,
                            strenght: 0,
                            spirit: 0,
                            speed: 0);
        }

    }
}