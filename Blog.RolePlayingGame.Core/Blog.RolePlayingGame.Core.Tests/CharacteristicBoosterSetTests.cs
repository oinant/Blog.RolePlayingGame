using System;
using Shouldly;

namespace Blog.RolePlayingGame.Core.Tests
{
    public class CharacteristicBoosterSetTests
    {
        private static CharacteristicBoosterSet GetSUT()
        {
            return new CharacteristicBoosterSet();
        }

        public void a_boosterSet_can_boost_strength_by_1()
        {
            var actual = GetSUT();
            actual.BoostStrength();

            actual.StrengthBoost.ShouldBe(1);
        }

        public void a_boosterSet_can_boost_strength_by_2()
        {
            var actual = GetSUT();
            actual.BoostStrength(BoostCharacteristics.OfTwo);

            actual.StrengthBoost.ShouldBe(2);
        }

        public void a_boosterSet_cannot_boost_strength_by_more_than_2()
        {
            Action attemptToBoostOf3 = () =>
            {
                var actual = GetSUT();
                actual.BoostStrength(BoostCharacteristics.OfTwo);
                actual.BoostStrength(BoostCharacteristics.OfOne);
            };

            attemptToBoostOf3.ShouldThrow<Exception>();
        }

        public void a_boosterSet_can_boost_spirit_by_1()
        {
            var actual = GetSUT();
            actual.BoostSpirit();

            actual.SpiritBoost.ShouldBe(1);
        }

        public void a_boosterSet_can_boost_spirit_by_2()
        {
            var actual = GetSUT();
            actual.BoostSpirit(BoostCharacteristics.OfTwo);

            actual.SpiritBoost.ShouldBe(2);
        }

        public void a_boosterSet_cannot_boost_spirit_by_more_than_2()
        {
            Action attemptToBoostOf3 = () =>
            {
                var actual = GetSUT();
                actual.BoostSpirit(BoostCharacteristics.OfTwo);
                actual.BoostSpirit(BoostCharacteristics.OfOne);
            };

            attemptToBoostOf3.ShouldThrow<Exception>();
        }

        public void a_boosterSet_can_boost_strength_and_spirit_by_1()
        {
            var actual = GetSUT();
            actual.BoostStrength();
            actual.BoostSpirit();

            actual.SpiritBoost.ShouldBe(1);
            actual.StrengthBoost.ShouldBe(1);

        }

        public void a_boosterSet_can_boost_more_than_2_on_overall()
        {
            var actual = GetSUT();
            actual.BoostStrength();
            actual.BoostSpirit();

            Action attemptToBoostOf3 = () =>
            {
                actual.BoostSpirit();
            };

            attemptToBoostOf3.ShouldThrow<AttempToBoostOverallCharacteristicOfMoreThanToTwoException>();
        }
    }
}