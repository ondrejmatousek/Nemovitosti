using DryIoc;
using System;
using System.Collections.Generic;

namespace Nemovitosti.CompositionRoot
{
    /// <summary>
    /// Potomci třídy slouží pro složení komponent do aplikace, tj. nakonfigurování DI-IoC kontejneru.
    /// Tato abstraktní třída poskytuje metody pro ověření správnosti konfigurace.
    /// </summary>
    public abstract class CompositionRootBase
    {
        public IContainer IocContainer { get; protected set; }

        /// <summary>
        /// Odpovídá za nakonfigurování DI kontejneru
        /// </summary>
        public abstract void Compose();

        /// <summary>
        /// Vrátí informace k registracím, při jejichž resolvování by došlo k výjimce. 
        /// </summary>
        /// <returns>Pole problematických registrací</returns>
        public KeyValuePair<ServiceInfo, ContainerException>[] GetResolutionValidationExceptions()
        {
            return IocContainer.Validate();
        }

        /// <summary>
        /// Vyhodí výjimku obsahující informaci o typech, které jsou registrované ale nelze je při současné konfiguraci instanciovat
        /// </summary>
        public void Validate()
        {
            KeyValuePair<ServiceInfo, ContainerException>[] vyjimky = GetResolutionValidationExceptions();
            if (vyjimky.Length > 0)
            {
                throw new Exception($"Chybná konfigurace aplikace. Některé služby nelze instanciovat, protože nejsou k dispozici všechny jejich závislosti: {String.Join(",", vyjimky)}");
            }
        }

        /// <summary>
        /// Varianta DryIoc UseInstance, která nepřijímá null.
        /// Parametry jsou předány beze změny metodě <see cref="DryIoc.Registrator.UseInstance"/>
        /// 
        /// (Protože DryIoc UseInstance null akceptuje a k výjimce dojde až při řešení požadvku, 
        /// kdy DryIoc najde null dependency, což považuje (správně) za chybu. 
        /// Výsledná výjimka je navíc poněkud nečitelná
        /// https://bitbucket.org/dadhi/dryioc/issues/565/option-for-null-checking-of-injected
        /// )
        /// 
        /// </summary>
        /// <exception cref="ArgumentNullException"> pokud je <paramref name="instance"/> null</exception> 
        /// 
        public void UseInstanceWNullGuard<TService>(TService instance, bool preventDisposal = false,
            bool weaklyReferenced = false, object serviceKey = null)
            where TService : class
        {
            if (instance == null)
            {
                throw new ArgumentNullException(nameof(instance));
            }
            IocContainer.UseInstance(typeof(TService), instance, IfAlreadyRegistered.Replace, preventDisposal, weaklyReferenced, serviceKey);
        }

    }
}
