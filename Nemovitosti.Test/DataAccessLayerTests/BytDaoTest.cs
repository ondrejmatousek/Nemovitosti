using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.Test.TestUtils;
using Xunit;

namespace Nemovitosti.Test.DataAccessLayerTests
{
    [AutoRollback]
    public class BytDaoTest
    {
        [Theory]
        [AutoDataDI]
        public void UlozANactiTest(Byt byt, IBytDao bytDao)
        {
            bytDao.Insert(byt);
            var bytZDb = bytDao.GetById(byt.IdByt);
            Assert.Equal(byt, bytZDb);
        }
    }
}
