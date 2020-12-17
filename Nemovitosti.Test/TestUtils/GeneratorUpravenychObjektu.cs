using AutoFixture;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Nemovitosti.Test.TestUtils
{
    /// <summary>
    /// Generuje objekty, které se částečně liší od svého vzoru.
    /// (např. pro testy neekvivalence objektů lišících se v 1 vlastnosti)
    /// </summary>
    public class GeneratorUpravenychObjektu
    {
        private readonly Fixture fixture;// { get; set; }
        private readonly bool generovatRekurzivne;
        private readonly bool nahrazovatHodnotouNullCiDefault;

        /// <summary>
        /// Generuje objekty - vždy nový objekt pro každou propertu; Dle nastavení může generovat i podobjekty ve stromě (generovatRekurzivne), případně nahrazovat null či defaultní hodnotou (default pro nonnullable typy)
        /// </summary>
        /// <param name="generovatRekurzivne">pokud měněná property je třída, generuje další objekty pro každou propertu této třídy...analogicky pokračuje stromem dolů</param>
        /// <param name="nahrazovatHodnotouNull">nahrazuje null hodnotou u nullable typů a defaultní hodnotou u nonnullable typů; vygenerovaný list objektů může obsahovat objekty, které jsou shodné s originálním objektem</param>
        public GeneratorUpravenychObjektu(bool generovatRekurzivne = false, bool nahrazovatHodnotouNull = false)
        {
            this.generovatRekurzivne = generovatRekurzivne;
            this.nahrazovatHodnotouNullCiDefault = nahrazovatHodnotouNull;
            fixture = new Fixture();


        }

        /// <summary>
        /// Vygeneruje list objektů vždy s jednou upravenou propertou. 
        /// Pro ověření vygenerování rozdílných hodnot/tříd, by třídy, které jsou vstupním objektem měly mít přepsány equals a gethashcode (i jejich property - pokud jsou to nehodnotové typy). 
        /// Pokud se tak nestane, může občas/náhodně vygenerovat shodný objekt.
        /// </summary>
        /// <param name="originalniObjekt">objekt z něhož budou generovány upravené objekty; pro správnou funkci by měl mít přepsané metody equals a gethascode (i uvnitř)</param>        
        public List<T> VygenerujListUpravenychObjektu<T>(T originalniObjekt)
        {
            return VygenerujListUpravenychObjektu(originalniObjekt, typeof(T));
        }

        /// <summary>
        /// Vygeneruje list objektů vždy s jednou upravenou propertou. 
        /// </summary>
        /// <param name="originalniObjekt">objekt z něhož budou generovány upravené objekty</param>
        /// <param name="typ">typ jehož properties budou generovány</param>
        private List<T> VygenerujListUpravenychObjektu<T>(T originalniObjekt, Type typ)// pro rekurzivní volání je nutné tato signatura metody, protože v případě typu zaboxovaného do objectu není z T schopna detekovat typ
        {
            List<T> upraveneObjekty = new List<T>();
            PropertyInfo[] properties = typeof(T).GetProperties();

            if (typ != null)
                properties = typ.GetProperties();

            foreach (PropertyInfo propertyInfo in properties)
            {
                if (generovatRekurzivne && JeKolekce(propertyInfo))
                    VytvorUpraveneObjektyProKolekci(originalniObjekt, upraveneObjekty, propertyInfo);
                //else if (JeSqlGeography(propertyInfo))
                //VytvorUpravenyObjektProHodnotovyTyp(originalniObjekt, upraveneObjekty, propertyInfo);
                else if (generovatRekurzivne && JeTrida(propertyInfo))
                    VytvorUpravenyObjektProTridu(originalniObjekt, upraveneObjekty, propertyInfo);
                else
                    VytvorUpravenyObjektProHodnotovyTyp(originalniObjekt, upraveneObjekty, propertyInfo);
            }

            return upraveneObjekty;
        }

        private void VytvorUpravenyObjektProHodnotovyTyp<T>(T originalniObjekt, List<T> upraveneObjekty, PropertyInfo propertyInfo)
        {
            T upravenyObjekt = VytvorUpravenyObjekt(originalniObjekt, propertyInfo);
            upraveneObjekty.Add(upravenyObjekt);
        }

        private void VytvorUpravenyObjektProTridu<T>(T originalniObjekt, List<T> upraveneObjekty, PropertyInfo propertyInfo)
        {
            object properta = default(T);

            if (originalniObjekt != null)
                properta = propertyInfo.GetValue(originalniObjekt);

            var noveProperty = new GeneratorUpravenychObjektu(generovatRekurzivne, nahrazovatHodnotouNullCiDefault)
                .VygenerujListUpravenychObjektu(properta, propertyInfo.PropertyType);// properta.GetType());
            foreach (var novaProperta in noveProperty)
            {
                T objektKUpraveni = Kopiruj(originalniObjekt);

                SetValue(propertyInfo, objektKUpraveni, novaProperta);
                upraveneObjekty.Add(objektKUpraveni);
            }

            if (nahrazovatHodnotouNullCiDefault)
                upraveneObjekty.Add(VytvorUpravenyObjekt(originalniObjekt, propertyInfo));
        }

        private void VytvorUpraveneObjektyProKolekci<T>(T originalniObjekt, List<T> upraveneObjekty, PropertyInfo propertyInfo)
        {
            var type = propertyInfo.PropertyType; // propertyInfo.GetValue(originalniObjekt).GetType();

            IList originalniKolekce = null;

            if (originalniObjekt != null)
                originalniKolekce = propertyInfo.GetValue(originalniObjekt) as IList;

            int pocetPolozekVOriginalniKolekci = 0;

            if (originalniKolekce != null)
                foreach (var item in originalniKolekce)
                    pocetPolozekVOriginalniKolekci++;

            for (int i = 0; i < originalniKolekce?.Count; i++)
            {
                var polozkaVOriginalniKolekci = originalniKolekce[i];
                var vygenerovaneZmenenePolozkyZPolozkyVOriginalniKolekci = new GeneratorUpravenychObjektu(generovatRekurzivne, nahrazovatHodnotouNullCiDefault)
                    .VygenerujListUpravenychObjektu(polozkaVOriginalniKolekci, polozkaVOriginalniKolekci.GetType());
                foreach (var vygenerovanaZmenenaPolozkaZPolozkyVOriginalniKolekci in vygenerovaneZmenenePolozkyZPolozkyVOriginalniKolekci)
                {
                    var itemtype = polozkaVOriginalniKolekci.GetType();
                    IList novaKolekce = null;

                    if (type.IsArray)
                    {
                        novaKolekce = Array.CreateInstance(itemtype, pocetPolozekVOriginalniKolekci);

                        for (int k = 0; k < originalniKolekce.Count; k++)
                            novaKolekce[k] = DeepCopyMaker.DeepCopy(originalniKolekce[k]);

                        novaKolekce[i] = vygenerovanaZmenenaPolozkaZPolozkyVOriginalniKolekci;
                    }
                    else
                    {
                        if (type.IsInterface)
                        {
                            var listGenericType = typeof(List<>);
                            type = listGenericType.MakeGenericType(itemtype);
                        }

                        novaKolekce = (IList)Activator.CreateInstance(type);

                        foreach (var polozkaVoriginalniKolekci in originalniKolekce)
                            novaKolekce.Add(DeepCopyMaker.DeepCopy(polozkaVoriginalniKolekci));

                        novaKolekce[i] = vygenerovanaZmenenaPolozkaZPolozkyVOriginalniKolekci;
                    }

                    var objektKUpraveni = DeepCopyMaker.DeepCopy<T>(originalniObjekt);
                    propertyInfo.SetValue(objektKUpraveni, novaKolekce);
                    upraveneObjekty.Add(objektKUpraveni);
                }
            }

            if (nahrazovatHodnotouNullCiDefault)
                upraveneObjekty.Add(VytvorUpravenyObjekt(originalniObjekt, propertyInfo));
        }

        //private static bool JeSqlGeography(PropertyInfo propertyInfo)
        //{
        //    return (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType == typeof(SqlGeography));
        //}

        private static bool JeTrida(PropertyInfo propertyInfo)
        {
            return (propertyInfo.PropertyType.IsClass && propertyInfo.PropertyType != typeof(string));
        }

        private static bool JeKolekce(PropertyInfo propertyInfo)
        {
            return (typeof(IEnumerable).IsAssignableFrom(propertyInfo.PropertyType) && propertyInfo.PropertyType != typeof(string));
        }

        private T VytvorUpravenyObjekt<T>(T originalniObjekt, PropertyInfo propertyInfo)
        {
            T objektKUpraveni = Kopiruj(originalniObjekt);

            MethodInfo method = GetType().GetMethod("FixtureCreate");
            method = method.MakeGenericMethod(new Type[] { propertyInfo.PropertyType });

            if (nahrazovatHodnotouNullCiDefault)
                SetValue(propertyInfo, objektKUpraveni, default(T));
            else
            {
                var zmenenaHodnota = method.Invoke(this, null);
                var puvodniHodnota = propertyInfo.GetValue(objektKUpraveni);
                //kdyby fixture náhodou vygeneroval shodnou hodnotu, prověříme že jsou různé, případně generujeme opakovaně znovu

                //if (propertyInfo.PropertyType == typeof(SqlGeography))
                //{
                //    while (puvodniHodnota != null && ((SqlGeography)puvodniHodnota).STEquals((SqlGeography)zmenenaHodnota))
                //        zmenenaHodnota = method.Invoke(this, null);
                //}
                /*else */
                if (propertyInfo.PropertyType == typeof(string))
                {
                    int? maxDelkaGenerovanehoStringu = propertyInfo.GetCustomAttributes(true).OfType<StringLengthAttribute>().FirstOrDefault()?.MaximumLength;

                    while ((puvodniHodnota != null && puvodniHodnota.Equals(zmenenaHodnota)) ||
                        ((string)zmenenaHodnota).Length > maxDelkaGenerovanehoStringu)
                        zmenenaHodnota = VygenerujZkracenyRetezec(method, maxDelkaGenerovanehoStringu);
                }
                else
                {
                    while (puvodniHodnota != null && puvodniHodnota.Equals(zmenenaHodnota))
                        zmenenaHodnota = method.Invoke(this, null);
                }

                SetValue(propertyInfo, objektKUpraveni, zmenenaHodnota);
            }
            return objektKUpraveni;
        }

        /// <summary>
        /// Vygeneruje řetezec, pokud je maxDelkaGenerovanehoStringu not null, bude délka výsledného řetezce
        /// maximálně ve výši maxDelkaGenerovanehoStringu
        /// </summary>
        /// <param name="method"></param>
        /// <param name="maxDelkaGenerovanehoStringu"></param>
        /// <returns></returns>
        private object VygenerujZkracenyRetezec(MethodInfo method, int? maxDelkaGenerovanehoStringu)
        {
            var zmenenaHodnota = method.Invoke(this, null);

            if (maxDelkaGenerovanehoStringu != null && ((string)zmenenaHodnota).Length > maxDelkaGenerovanehoStringu)
                zmenenaHodnota = ((string)zmenenaHodnota).Substring(0, (int)maxDelkaGenerovanehoStringu);

            return zmenenaHodnota;
        }

        private void SetValue<T>(PropertyInfo propertyInfo, T objektKUpraveni, T zmenenaHodnota)
        {
            try
            {
                propertyInfo.SetValue(objektKUpraveni, zmenenaHodnota);
            }
            catch (Exception)
            {
                objektKUpraveni = default(T);
            }
        }

        private static T Kopiruj<T>(T originalniObjekt)
        {
            T objektKUpraveni = default(T);

            if (originalniObjekt != null)
                objektKUpraveni = DeepCopyMaker.DeepCopy<T>(originalniObjekt);
            return objektKUpraveni;
        }

        public T FixtureCreate<T>()
        {
            return fixture.Create<T>();
        }

        public static T Cast<T>(object o)
        {
            return (T)o;
        }
    }
}
