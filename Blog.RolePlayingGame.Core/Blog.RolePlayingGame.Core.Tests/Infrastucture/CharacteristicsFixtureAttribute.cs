using System;

namespace Blog.RolePlayingGame.Core.Tests.Infrastucture
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class CharacteristicsFixtureAttribute : Attribute
    {
        public object[] Paramemters { get; private set; }

        public CharacteristicsFixtureAttribute(params object[] paramemters)
        {
            Paramemters = paramemters;
        }
    }
}
