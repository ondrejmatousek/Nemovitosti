using AutoFixture.Xunit2;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Xunit;

namespace Nemovitosti.Test.DataAccessLayerTests
{
    public class BytDaoTest
    {
        [Theory]
        [AutoData]
        public void UlozANactiTest(Byt byt, IBytDao bytDao)
        {
            bytDao.Insert(byt);
            var bytZDb = bytDao.GetById(byt.IdByt);
            Assert.Equal(byt, bytZDb);
        }
    }
}
