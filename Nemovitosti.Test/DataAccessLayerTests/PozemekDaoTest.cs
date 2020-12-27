using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.Test.TestUtils;
using Xunit;

namespace Nemovitosti.Test.DataAccessLayerTests
{
    [AutoRollback]
    public class PozemekDaoTest
    {
        [Theory]
        [AutoDataDI]
        public void UlozANactiTest(Pozemek pozemek, IPozemekDao pozemekDao)
        {
            pozemekDao.Insert(pozemek);
            var bytZDb = pozemekDao.GetById(pozemek.IdPozemek);
            Assert.Equal(pozemek, bytZDb);
        }

    }
}
