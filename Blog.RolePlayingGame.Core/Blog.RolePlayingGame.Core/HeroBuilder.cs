using System;

namespace Blog.RolePlayingGame.Core
{
    public class HeroBuilder
    {
        private HeroClass _class;
        private int _level;
        private int _health;
        private int _strength;
        private int _spirit;
        private int _speed;
        private string _name;

        private CharacteristicsModificator _modificator;

        private bool _dolevelComputation = true;

        public HeroBuilder()
        {
            _level = 1;
        }

        public HeroBuilder OfWarriorClass()
        {
            _class = HeroClass.Warrior;
            _modificator = new CharacteristicsModificator(strength: 2, spirit: -2);
            return this;
        }

        public HeroBuilder OfWizardClass()
        {
            _class = HeroClass.Wizard;
            _modificator = new CharacteristicsModificator(strength: -2, spirit: 2);
            return this;
        }

        public HeroBuilder OfThiefClass()
        {
            _class = HeroClass.Thief;
            _modificator = CharacteristicsModificator.Void;
            return this;
        }

        public HeroBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        public HeroBuilder WithLevel(int level)
        {
            _level = level;
            _health = _level * 10;
            _strength = _level * 5;
            _spirit = _level * 5;
            _speed = _level * 3;

            _dolevelComputation = false;
            return this;
        }

        public Hero Create()
        {
            if (IsClassNotSettled())
                throw new BuildingHeroWithoutClassAttempException();

            if (IsNameNotSettled())
                throw new BuildingHeroWithoutNameAttempException();

            if (_dolevelComputation)
                WithLevel(1);

            ApplyModificator();

            return new Hero(@class: _class,
                name: _name,
                level: _level,
                health: _health,
                strength: _strength,
                spirit: _spirit,
                speed: _speed);
        }

        private void ApplyModificator()
        {
            _strength += _modificator.Strength;
            _spirit += _modificator.Spirit;
        }

        private bool IsClassNotSettled()
        {
            return _class == default(HeroClass);
        }

        private bool IsNameNotSettled()
        {
            return string.IsNullOrWhiteSpace(_name);
        }

        public class BuildingHeroWithoutClassAttempException : Exception
        {
            public BuildingHeroWithoutClassAttempException() : base("Cannot creating an hero without class") { }
        }

        public class BuildingHeroWithoutNameAttempException : Exception
        {
            public BuildingHeroWithoutNameAttempException() : base("Cannot creating an hero without name") { }
        }



    }

    public struct CharacteristicsModificator
    {
        public int Strength;
        public int Spirit;

        public CharacteristicsModificator(int strength, int spirit)
        {
            Strength = strength;
            Spirit = spirit;
        }

        public static CharacteristicsModificator Void { get { return new CharacteristicsModificator(0, 0); } }
    }
}