﻿using System.Collections.Generic;
using System.Linq;

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

            BoostValue += resultingBoost;
        }
    }


    public class CharacteristicBoosterSet
    {
        readonly object _strengthKey = new object();
        readonly object _spiritKey = new object();

        private readonly Dictionary<object, CharacteristicBooster> _set;

        public CharacteristicBoosterSet()
        {
            _set = new Dictionary<object, CharacteristicBooster>()
            {
                {_strengthKey, new CharacteristicBooster("Strength")},
                {_spiritKey, new CharacteristicBooster("Spirit")}
            };
        }

        public int StrengthBoost { get { return _set[_strengthKey].BoostValue; } }
        public int SpiritBoost { get { return _set[_spiritKey].BoostValue; } }
        
        public void BoostStrength(BoostCharacteristics boost = BoostCharacteristics.OfOne)
        {
            CheckOverallBoost(boost);
            _set[_strengthKey].Boost(boost);
        }

        public void BoostSpirit(BoostCharacteristics boost = BoostCharacteristics.OfOne)
        {
            CheckOverallBoost(boost);
            _set[_spiritKey].Boost(boost);
        }

        private void CheckOverallBoost(BoostCharacteristics boostAttempt)
        {
            var currentOverallBoost = _set.Sum(b => b.Value.BoostValue);
            
            if( currentOverallBoost +  (int)boostAttempt > 2 )
                throw new AttempToBoostOverallCharacteristicOfMoreThanToTwoException();
        }
    }
}