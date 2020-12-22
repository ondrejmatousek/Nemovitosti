using AutoFixture;

namespace Nemovitosti.Test.TestUtils
{
    public class DIContainerCustomization : ICustomization
    {
        private readonly CompositionRootTest compositionRootTest;
        public DIContainerCustomization()
        {
            compositionRootTest = new CompositionRootTest();
            compositionRootTest.Compose();
        }

        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new DIAdapter(compositionRootTest.IocContainer));
        }
    }
}
