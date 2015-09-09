using Blog.RolePlayingGame.Core;
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

        public void WhenBuilt_a_level1_hero_has_10_health()
        {
            Hero expected = new HeroBuilder()
                                 .WithLevel(1)
                                 .Create();

            expected.GetHealth().ShouldBe(10);
        }

        public void WhenBuilt_a_level2_hero_has_20_health()
        {
            Hero expected = new HeroBuilder()
                                 .WithLevel(2)
                                 .Create();

            expected.GetHealth().ShouldBe(20);
        }
    }
}
