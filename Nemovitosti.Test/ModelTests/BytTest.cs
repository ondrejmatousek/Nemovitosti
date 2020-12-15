using AutoFixture.Xunit2;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.Test.TestUtils;
using Xunit;

namespace Nemovitosti.Test.ModelTests
{
    public class BytTest
    {
        [Theory, AutoData]
        public void EqualsTest(Byt byt)
        {
            var kopie = DeepCopyMaker.DeepCopy(byt);
            Assert.Equal(byt, kopie);
        }

    }
}
