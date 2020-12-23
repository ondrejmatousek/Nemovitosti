using Nemovitosti.DataAccessLayer.Interface;
using Nemovitosti.DomainModel.Model;
using Nemovitosti.Test.TestUtils;
using Xunit;

namespace Nemovitosti.Test.DataAccessLayerTests
{
    [AutoRollback]
    public class DumDaoTest
    {
        [Theory]
        [AutoDataDI]
        public void UlozNactiAPorovnej(Dum dum, IDumDao dumDao)
        {
            dumDao.Insert(dum);
            Dum dumZDb = dumDao.GetById(dum.IdDum);
            Assert.Equal(dum, dumZDb);
        }
    }
}
