using DryIoc;
using Nemovitosti.CompositionRoot;
using System.Configuration;

internal class CompositionRootTest : CompositionRootBase
{
    //Zajistit čtení ConnectionStringu z appsettings.json v projektu Nemovitosti.Web
    private readonly string ConnectionStringTest = "Server=LAPTOP-LN53KKBQ\\SQLEXPRESS;Database=Nemovitosti;Trusted_Connection=True;";

    public override void Compose()
    {
        var compositionRoot = new CompRoot();
        compositionRoot.Compose();
        //příprava pro AutoDataDryIocAttribute
        IocContainer = compositionRoot.IocContainer;


        ConnectionStringSettings connString = new ConnectionStringSettings();
        connString.ConnectionString = ConnectionStringTest;

        IocContainer.UseInstance(connString);
    }

    public new void Validate()
    {
        IocContainer.Validate();
    }

}
