using System;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Activation;
using Blog.RolePlayingGame.Core.Tests.Infrastucture;
using Shouldly;


namespace Blog.RolePlayingGame.Core.Tests
{
    public class HeroBuilderTests
    {
        public void An_HeroBuilder_can_build_a_warrior()
        {
            Hero actual = new HeroBuilder()
                                 .OfWarriorClass()
                                 .FillFromName()
                                 .Create();

            actual.Class.ShouldBe(HeroClass.Warrior);
        }

        public void An_HeroBuilder_can_build_a_wizard()
        {
            Hero actual = new HeroBuilder()
                                 .OfWizardClass()
                                 .FillFromName()
                                 .Create();

            actual.Class.ShouldBe(HeroClass.Wizard);
        }

        public void An_HeroBuilder_can_build_a_thief()
        {
            Hero actual = new HeroBuilder()
                                 .OfThiefClass()
                                 .FillFromName()
                                 .Create();

            actual.Class.ShouldBe(HeroClass.Thief);
        }

        public void An_HeroBuilder_cannot_build_a_hero_without_class()
        {
            Action tryToBuildAHeroWithoutClass = () => new HeroBuilder().Create();
            tryToBuildAHeroWithoutClass.ShouldThrow<HeroBuilder.BuildingHeroWithoutClassAttempException>();
        }

        public void An_Hero_should_have_a_name()
        {
            var name = "The Mitghty Radgar";
            Hero actualHero = null;

            Action buildWithAName = () => actualHero = new HeroBuilder().OfWarriorClass().WithName("The Mitghty Radgar").FillAfterName().Create();
            buildWithAName.ShouldNotThrow();
            actualHero.Name.ShouldBe(name);

            Action buildWithoutAName = () => new HeroBuilder().OfWarriorClass().Create();
            buildWithoutAName.ShouldThrow<HeroBuilder.BuildingHeroWithoutNameAttempException>();
        }

        public void When_built_thehero_level_is_one_by_default()
        {
            Hero actual = new HeroBuilder()
                                 .FillBeforeLevel()
                                 .FillAfterLevel()
                                 .Create();

            actual.Level.ShouldBe(1);
        }

        public void WhenBuilt_a_level3_hero_is_level_3()
        {
            Hero actual = new HeroBuilder()
                                 .FillBeforeLevel()
                                 .WithLevel(3)
                                 .Create();

            actual.Level.ShouldBe(3);
        }

        [CharacteristicsFixture("thief", 1, 10, 5, 5, 3)]
        [CharacteristicsFixture("thief", 2, 20, 10, 10, 6)]
        [CharacteristicsFixture("warrior", 1, 10, 7, 3, 3)]
        [CharacteristicsFixture("warrior", 2, 20, 12, 8, 6)]
        [CharacteristicsFixture("wizard", 1, 10, 3, 7, 3)]
        [CharacteristicsFixture("wizard", 2, 20, 8, 12, 6)]
        public void a_hero_with_class_and_level_has_given_charateristics(string @class, int level, int expectedHealth, int expectedStrength, int expectedSpirit, int expectedSpeed)
        {
            Hero actual = new HeroBuilder()
                .WithStringClass(@class)
                .WithName("the name")
                .WithLevel(level)
                .Create();

            actual.Level.ShouldBe(level);
            actual.Health.ShouldBe(expectedHealth);
            actual.Strength.ShouldBe(expectedStrength);
            actual.Spirit.ShouldBe(expectedSpirit);
            actual.Speed.ShouldBe(expectedSpeed);
        }


    }

    internal static class HeroBuilderTestExtensions
    {
        internal static HeroBuilder WithStringClass(this HeroBuilder heroBuilder, string @class)
        {
            if (@class.Equals("warrior", StringComparison.OrdinalIgnoreCase))
                heroBuilder.OfWarriorClass();
            if (@class.Equals("thief", StringComparison.OrdinalIgnoreCase))
                heroBuilder.OfThiefClass();
            if (@class.Equals("wizard", StringComparison.OrdinalIgnoreCase))
                heroBuilder.OfWizardClass();

            return heroBuilder;
        }

        internal static HeroBuilder FillFromName(this HeroBuilder builder)
        {
            return builder.WithName("theName").FillFromLevel();
        }

        internal static HeroBuilder FillAfterName(this HeroBuilder builder)
        {
            return builder.FillFromLevel();
        }

        internal static HeroBuilder FillFromLevel(this HeroBuilder builder)
        {
            return builder.WithLevel(1).FillAfterLevel();
        }

        internal static HeroBuilder FillBeforeLevel(this HeroBuilder builder)
        {
            return builder.OfWarriorClass().WithName("theName");
        }

        internal static HeroBuilder FillAfterLevel(this HeroBuilder builder)
        {
            return builder;
        }
    }
}
