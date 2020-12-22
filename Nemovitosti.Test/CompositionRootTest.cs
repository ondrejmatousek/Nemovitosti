using DryIoc;
using Nemovitosti.CompositionRoot;
using System.Configuration;

internal class CompositionRootTest : CompositionRootBase
{
    public override void Compose()
    {
        var compositionRoot = new CompRoot();
        compositionRoot.Compose();
        //příprava pro AutoDataDryIocAttribute
        IocContainer = compositionRoot.IocContainer;

        ConnectionStringSettings connString = new ConnectionStringSettings("Connection", "Server=LAPTOP-LN53KKBQ\\SQLEXPRESS;Database=Nemovitosti;Trusted_Connection=True;");

        IocContainer.UseInstance(connString);
    }

    public new void Validate()
    {
        IocContainer.Validate();
    }

}
