using AutoFixture;
using AutoFixture.Xunit2;

namespace Nemovitosti.Test.TestUtils
{
    public class AutoDataDIAttribute : AutoDataAttribute
    {
        public AutoDataDIAttribute() : base(() => new Fixture()
            .Customize(new DIContainerCustomization()))
        {

        }
    }
}
