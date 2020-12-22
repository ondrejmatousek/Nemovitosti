using AutoFixture.Xunit2;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.Test.TestUtils;
using Xunit;

namespace Nemovitosti.Test.ModelTests
{
    public class BytTest
    {
        [Theory]
        [AutoData]
        public void EqualsTest(Byt byt)
        {
            var kopie = DeepCopyMaker.DeepCopy(byt);
            Assert.Equal(byt, kopie);
        }

        [Theory]
        [AutoData]
        public void NotEqualsTest(Byt byt)
        {
            var generator = new GeneratorUpravenychObjektu(true);
            var upravene = generator.VygenerujListUpravenychObjektu(byt);
            foreach (var upraveny in upravene)
            {
                Assert.NotEqual(upraveny, byt);
            }

        }

        [Theory]
        [AutoData]
        public void NotEquals_NepadneNaNull(Byt byt)
        {
            var generator = new GeneratorUpravenychObjektu(true, true);
            var upravene = generator.VygenerujListUpravenychObjektu(byt);

            foreach (var upraveny in upravene)
                byt.Equals(upraveny);
        }

    }
}
