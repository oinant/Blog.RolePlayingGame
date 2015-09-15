using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Fixie;

namespace Blog.RolePlayingGame.Core.Tests.Infrastucture
{
    public class CustomConvention : Convention
    {

        public CustomConvention()
        {
            Classes
                .NameEndsWith("Tests");

            Methods
                .Where(method => method.IsVoid());

            Parameters
                .Add<FromCharacteristicsFixtureAttribute>();
        }


        class FromCharacteristicsFixtureAttribute : ParameterSource
        {
            public IEnumerable<object[]> GetParameters(MethodInfo method)
            {
                return method
                          .GetCustomAttributes<CharacteristicsFixtureAttribute>(true)
                          .Select(input => input.Paramemters);
            }
        }
    }
}