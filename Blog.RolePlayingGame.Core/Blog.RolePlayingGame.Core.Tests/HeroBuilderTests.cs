using System;
using Shouldly;


namespace Blog.RolePlayingGame.Core.Tests
{
    public class HeroBuilderTests
    {
        public void An_HeroBuilder_can_build_a_warrior()
        {
            Hero expected =  new HeroBuilder()
                                 .OfWarriorClass()
                                 .FillFromName()
                                 .Create();

            expected.Class.ShouldBe(HeroClass.Warrior);
        }

        public void An_HeroBuilder_can_build_a_wizard()
        {
            Hero expected = new HeroBuilder()
                                 .OfWizardClass()
                                 .FillFromName()
                                 .Create();

            expected.Class.ShouldBe(HeroClass.Wizard);
        }

        public void An_HeroBuilder_can_build_a_thief()
        {
            Hero expected = new HeroBuilder()
                                 .OfThiefClass()
                                 .FillFromName()
                                 .Create();

            expected.Class.ShouldBe(HeroClass.Thief);
        }

        public void An_HeroBuilder_cannot_build_a_hero_without_class()
        {
            Action tryToBuildAHeroWithoutClass = () => new HeroBuilder().Create();
            tryToBuildAHeroWithoutClass.ShouldThrow<HeroBuilder.BuildingHeroWithoutClassAttempException>();
        }

        public void An_Hero_should_have_a_name()
        {
            var name = "The Mitghty Radgar";
            Hero expectedHero = null;
            
            Action buildWithAName = () => expectedHero = new HeroBuilder().OfWarriorClass().WithName("The Mitghty Radgar").FillAfterName().Create();
            buildWithAName.ShouldNotThrow();
            expectedHero.Name.ShouldBe(name);

            Action buildWithoutAName = () => new HeroBuilder().OfWarriorClass().Create();
            buildWithoutAName.ShouldThrow<HeroBuilder.BuildingHeroWithoutNameAttempException>();
        }

        public void When_built_thehero_level_is_one_by_default()
        {
            Hero expected = new HeroBuilder()
                                 .FillBeforeLevel()
                                 .FillAfterLevel()
                                 .Create();

            expected.Level.ShouldBe(1);
        }

        public void WhenBuilt_a_level1_hero_has_10_health()
        {
            Hero expected = new HeroBuilder()
                                 .FillBeforeLevel()
                                 .WithLevel(1)
                                 .Create();

            expected.Health.ShouldBe(10);
        }

        public void WhenBuilt_a_level2_hero_has_20_health()
        {
            Hero expected = new HeroBuilder()
                                 .FillBeforeLevel()
                                 .WithLevel(2)
                                 .Create();

            expected.Health.ShouldBe(20);
        }
    }

    internal static class HeroBuilderTestExtensions
    {
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
