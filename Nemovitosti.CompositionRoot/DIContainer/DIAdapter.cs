using AutoFixture.Kernel;
using DryIoc;
using System;

namespace Nemovitosti.CompositionRoot
{
    /// <summary>
    /// Umožnuje AutoFixture vytáhnout požadováné instance z IoC kontejneru, pokud tam jsou. 
    /// </summary>
    public class DIAdapter : ISpecimenBuilder
    {
        private readonly IContainer iocContainer;

        public DIAdapter(IContainer iocContainer)
        {
            this.iocContainer = iocContainer;
        }

        public object Create(object request, ISpecimenContext context)
        {
            Type requestedType = request as Type;
            if (requestedType == null || !this.iocContainer.IsRegistered(requestedType))
                return new NoSpecimen();
            return iocContainer.Resolve(requestedType);
        }
    }
}
