using AutoFixture;
using AutoFixture.Kernel;
using Nemovitosti.DataAccessLayer.Implementation;
using Nemovitosti.DataAccessLayer.Interface;

namespace Nemovitosti.Test.TestUtils.TestyCustomizace
{
    public class TvorbaInterfaceCustomizace : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new TypeRelay(
                typeof(IBytDao),
                typeof(BytDao)));
        }
    }
}
