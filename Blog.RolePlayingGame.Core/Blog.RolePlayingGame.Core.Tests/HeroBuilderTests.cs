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
                                 .Create();

            expected.GetClass().ShouldBe(HeroClass.Warrior);
        }

        public void An_HeroBuilder_can_build_a_wizard()
        {
            Hero expected = new HeroBuilder()
                                 .OfWizardClass()
                                 .Create();

            expected.GetClass().ShouldBe(HeroClass.Wizard);
        }

        public void An_HeroBuilder_can_build_a_thief()
        {
            Hero expected = new HeroBuilder()
                                 .OfThiefClass()
                                 .Create();

            expected.GetClass().ShouldBe(HeroClass.Thief);
        }

        public void An_HeroBuilder_cannot_build_a_hero_without_class()
        {
            Action tryToBuildAHeroWithoutClass = () => new HeroBuilder().Create();
            tryToBuildAHeroWithoutClass.ShouldThrow<HeroBuilder.BuildingHeroWithoutClassAttempException>();
        }

        public void WhenBuilt_a_level1_hero_has_10_health()
        {
            Hero expected = new HeroBuilder()
                                 .OfWarriorClass()
                                 .WithLevel(1)
                                 .Create();

            expected.GetHealth().ShouldBe(10);
        }

        public void WhenBuilt_a_level2_hero_has_20_health()
        {
            Hero expected = new HeroBuilder()
                                 .OfWarriorClass()
                                 .WithLevel(2)
                                 .Create();

            expected.GetHealth().ShouldBe(20);
        }
    }
}
