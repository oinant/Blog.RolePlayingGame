using System;

namespace Blog.RolePlayingGame.Core
{
    public class HeroBuilder
    {
        private HeroClass _class;
        private int _level;
        private int _health;
        private string _name;

        public HeroBuilder()
        {
            _level = 1;
        }

        public HeroBuilder OfWarriorClass()
        {
            _class = HeroClass.Warrior;
            return this;
        }

        public HeroBuilder OfWizardClass()
        {
            _class = HeroClass.Wizard;
            return this;
        }

        public HeroBuilder OfThiefClass()
        {
            _class = HeroClass.Thief;
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
            _health = _level*10;
            return this;
        }

        public Hero Create()
        {
            if( IsClassNotSettled())
                throw new BuildingHeroWithoutClassAttempException();

            if(IsNameNotSettled())
                throw new BuildingHeroWithoutNameAttempException();

            return new Hero(@class: _class, 
                name: _name ,
                level:1, 
                health: _health,
                strength: 0,
                spirit: 0,
                speed: 0);
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
            public BuildingHeroWithoutClassAttempException() : base ("Cannot creating an hero without class") { }
        }

        public class BuildingHeroWithoutNameAttempException : Exception
        {
            public BuildingHeroWithoutNameAttempException() : base("Cannot creating an hero without name") { }
        }
    }

    
}