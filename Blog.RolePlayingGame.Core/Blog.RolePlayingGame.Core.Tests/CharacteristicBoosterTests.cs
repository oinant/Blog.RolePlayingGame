using System;
using Shouldly;

namespace Blog.RolePlayingGame.Core.Tests
{
    public class CharacteristicBoosterTests
    {
        private static CharacteristicBooster GetSUT()
        {
            return new CharacteristicBooster("STRENGTH");
        }

        public void a_booster_has_default_value_of_0()
        {
            var actual = GetSUT();
            actual.BoostValue.ShouldBe(0);
        }

        public void a_booster_cannot_be_boosted_of_a_null_boost()
        {
            var actual = GetSUT();
            
            Action attemptToBoostWithDefault = () => actual.Boost(default(BoostCharacteristics));

            attemptToBoostWithDefault.ShouldThrow<AttempToBoostWithDefaultCharacterisitcBoostException>();
        }

        public void a_booster_boosted_ofOne_has_value_of_1()
        {
            var actual = GetSUT(); 
            actual.Boost(BoostCharacteristics.OfOne);

            actual.BoostValue.ShouldBe(1);
        }

        public void a_booster_boosted__ofTwo_has_value_of_2()
        {
            var actual = GetSUT(); 
            actual.Boost(BoostCharacteristics.OfTwo);

            actual.BoostValue.ShouldBe(2);
        }

        public void a_booster_cannot_be_boosted_of_more_than_two()
        {
            Action attempToBoostOfMoreThanTwo = () =>
            {
                var actual = GetSUT(); 
                actual.Boost(BoostCharacteristics.OfTwo);
                actual.Boost();
            };

            attempToBoostOfMoreThanTwo.ShouldThrow<AttempToBoostCharacteristicOfMoreThanTwoException>();

            Action attempToBoostOfMoreThanTwo_2 = () =>
            {
                var actual = GetSUT();
                actual.Boost();

                actual.Boost(BoostCharacteristics.OfTwo);
            };

            attempToBoostOfMoreThanTwo_2.ShouldThrow<AttempToBoostCharacteristicOfMoreThanTwoException>();
        }
    }
}