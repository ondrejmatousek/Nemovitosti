using AutoFixture.Xunit2;
using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Xunit;

namespace Nemovitosti.Test.DataAccessLayerTests
{
    public class BytDaoTest
    {
        private readonly IBytDao bytDao;

        public BytDaoTest(IBytDao bytDao)
        {
            this.bytDao = bytDao;
        }

        [Theory]
        [AutoData]
        public void UlozANactiTest(Byt byt)
        {
            bytDao.Insert(byt);
            var bytZDb = bytDao.GetById(byt.IdByt);
            Assert.Equal(byt, bytZDb);
        }
    }
}
