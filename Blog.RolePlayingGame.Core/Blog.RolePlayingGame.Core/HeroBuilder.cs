using System;

namespace Blog.RolePlayingGame.Core
{
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
            _class = HeroClass.Warrior;
            return this;
        }

        public HeroBuilder OfWizardClass()
        {
            _class = HeroClass.Wizard;
            return this;
        }

        private bool IsClassNotSettled()
        {
            return _class == default(HeroClass);
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

            return new Hero(@class: _class, 
                level:1, 
                health: _health,
                strenght: 0,
                spirit: 0,
                speed: 0);
        }

        public HeroBuilder OfThiefClass()
        {
            _class = HeroClass.Thief;
            return this;
        }

        public class BuildingHeroWithoutClassAttempException : Exception
        {
            public BuildingHeroWithoutClassAttempException()
                : base ("Cannot creating an hero without class")
            {
                
            }
        }
    }

    
}