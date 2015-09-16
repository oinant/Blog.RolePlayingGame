namespace Blog.RolePlayingGame.Core
{
    public class CharacteristicBooster
    {
        private readonly string _name;

        public int BoostValue { get; private set; }

        public CharacteristicBooster(string name)
        {
            _name = name;
        }

        public void Boost(BoostCharacteristics boost = BoostCharacteristics.OfOne)
        {
            if (boost == default(BoostCharacteristics))
                throw new AttempToBoostWithDefaultCharacterisitcBoostException(_name);

            var castedBoost = (int)boost;
            var resultingBoost = BoostValue + castedBoost;

            if (resultingBoost > 2)
                throw new AttempToBoostCharacteristicOfMoreThanTwoException(_name);

            BoostValue = resultingBoost;
        }
    }
}