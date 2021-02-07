using AutoFixture.Xunit2;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.Test.TestUtils;
using Xunit;

namespace Nemovitosti.Test.ModelTests
{
    public class UzivatelTest
    {
        [Theory]
        [AutoData]
        public void EqualsTest(Uzivatel instace)
        {
            var kopie = DeepCopyMaker.DeepCopy<Uzivatel>(instace);
            Assert.Equal(instace, kopie);
        }

        [Theory]
        [AutoData]
        public void NotEquals(Uzivatel instace)
        {
            var generator = new GeneratorUpravenychObjektu(true);
            var upravene = generator.VygenerujListUpravenychObjektu(instace);

            foreach (var upraveny in upravene)
                Assert.NotEqual(instace, upraveny);
        }

        [Theory]
        [AutoData]
        public void NotEquals_NepadneNaNull(Uzivatel instace)
        {
            var generator = new GeneratorUpravenychObjektu(true, true);
            var upravene = generator.VygenerujListUpravenychObjektu(instace);

            foreach (var upraveny in upravene)
                instace.Equals(upraveny);
        }

    }
}
