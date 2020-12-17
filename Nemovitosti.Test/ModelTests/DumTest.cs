using AutoFixture.Xunit2;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.Test.TestUtils;
using Xunit;

namespace Nemovitosti.Test.ModelTests
{
    public class DumTest
    {
        [Theory]
        [AutoData]
        public void EqualsTest(Dum instace)
        {
            var kopie = DeepCopyMaker.DeepCopy<Dum>(instace);
            Assert.Equal(instace, kopie);
        }

        [Theory]
        [AutoData]
        public void NotEquals(Dum instace)
        {
            var generator = new GeneratorUpravenychObjektu(true);
            var upravene = generator.VygenerujListUpravenychObjektu(instace);

            foreach (var upraveny in upravene)
                Assert.NotEqual(instace, upraveny);
        }

        [Theory]
        [AutoData]
        public void NotEquals_NepadneNaNull(Dum instace)
        {
            var generator = new GeneratorUpravenychObjektu(true, true);
            var upravene = generator.VygenerujListUpravenychObjektu(instace);

            foreach (var upraveny in upravene)
                instace.Equals(upraveny);
        }

    }
}
