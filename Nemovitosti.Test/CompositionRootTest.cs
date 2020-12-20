using DryIoc;
using Nemovitosti.CompositionRoot;

public class CompositionRootTST : CompositionRootBase
{
    public override void Compose()
    {
        var compositionRoot = new CompRoot();
        compositionRoot.Compose();
        IocContainer = compositionRoot.IocContainer;
    }

    public new void Validate()
    {
        IocContainer.Validate();
    }
}
