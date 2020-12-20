using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Reflection;

namespace Nemovitosti.Test.TestUtils.TestyCustomizace
{
    public class AutoDataCustomizable : AutoDataAttribute
    {
        /// <summary>
        /// AutoData atribut, který aplikuje na svůj Fixture objekt všechna vyjmenovaná přizpůsobení/customization.
        /// </summary>
        /// <param name="anyCustomizations"></param>
        // AutoFixture, ze zatím neznámého důvodu, pro aplikaci přizpůsobení podporuje jen dělání potomků AutoData, takže dochází k explozi podtříd (jedna pro každou 
        // potřebnou kombinaci customizací). Možná jen pro to, že v unit testech to nevadí a integrační jsou Popelka. Tohle je snad fungující řešení.
        public AutoDataCustomizable(params Type[] anyCustomizations) : base()
        {
            foreach (Type anyCustomization in anyCustomizations)
            {
                //ohlasit, ze typ neni ICustomization bychom meli drive, nez si zacneme stezovat na nexistenci bezparam. konstruktoru
                if (!typeof(ICustomization).IsAssignableFrom(anyCustomization))
                {
                    throw new ArgumentException($"Typ {anyCustomization} není {typeof(ICustomization).FullName}");
                }

                ConstructorInfo paramlessCtrorInfo = anyCustomization.GetConstructor(new Type[0]);
                if (paramlessCtrorInfo == null)
                {
                    throw new ArgumentException($"Typ {anyCustomization} nemá bezparametrický konstruktor.");
                }

                object customizationObject = paramlessCtrorInfo.Invoke(new object[0]);
                ICustomization customization = customizationObject as ICustomization;
                //TODO depracated od verze 4, udelat tovarnu, ktera bude brat ten seznam customizaci a vyrobi patricnou fixture
                //tenhle postup vede k tomu, ze se fixture vytvori tolikrat, kolikrat je atribut nalezeny spoustecem testu
                // a to i v pripadech,ze spoustime jediny test
                //https://github.com/AutoFixture/AutoFixture/issues/843
                this.Fixture.Customize(customization);
            }
        }
    }
}
