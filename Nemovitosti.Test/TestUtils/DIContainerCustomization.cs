using AutoFixture;

namespace Nemovitosti.Test.TestUtils
{
    public class DIContainerCustomization : ICustomization
    {
        public DIContainerCustomization()
        {
        }

        public void Customize(IFixture fixture)
        {
            //fixture.Customizations.Add(new DryIocAdapter(Startup.IocContainer));
        }
    }
}
