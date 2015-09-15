using System;

namespace Blog.RolePlayingGame.Core
{
    public class AttempToBoostCharacteristicOfMoreThanTwoException : Exception
    {
        public AttempToBoostCharacteristicOfMoreThanTwoException(string characteristic) : base("you cannot boost a the " + characteristic + " of more than two") { }
    }

    public class AttempToBoostOverallCharacteristicOfMoreThanToTwoException : Exception { }
}