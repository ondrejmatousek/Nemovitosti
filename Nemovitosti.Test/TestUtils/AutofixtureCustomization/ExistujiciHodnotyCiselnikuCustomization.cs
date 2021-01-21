using AutoFixture;
using Nemovitosti.DomainModel.Model.Ciselniky;

namespace Nemovitosti.Test.TestUtils.AutofixtureCustomization
{
    /// <summary>
    /// Zajistí, že instance číselníkových objektů budou z množiny skutečně existující v databázi.
    /// </summary>
    public class ExistujiciHodnotyCiselnikuCustomization : ICustomization
    {
        void ICustomization.Customize(IFixture fixture)
        {
            CiselnikTypPozemku ciselnikTypPozemku = new CiselnikTypPozemku()
            {
                Id = 1,
                Nazev = "Stavební"
            };
            fixture.Customizations.Add(new ElementsBuilder<CiselnikTypPozemku>(ciselnikTypPozemku)
            );

            CiselnikProdejNeboPronajem ciselnikProdejNeboPronajem = new CiselnikProdejNeboPronajem()
            {
                Id = 1,
                Nazev = "Prodej"
            };
            fixture.Customizations.Add(new ElementsBuilder<CiselnikProdejNeboPronajem>(ciselnikProdejNeboPronajem)
            );

        }
    }
}
