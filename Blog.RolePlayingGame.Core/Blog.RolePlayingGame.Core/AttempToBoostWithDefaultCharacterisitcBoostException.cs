using System;

namespace Blog.RolePlayingGame.Core
{
    public class AttempToBoostWithDefaultCharacterisitcBoostException : Exception
    {
        public AttempToBoostWithDefaultCharacterisitcBoostException(string characteristic) : base("you cannot boost a the " + characteristic + " characteristic with default(BoostCharacteristics)") { }
    }
}