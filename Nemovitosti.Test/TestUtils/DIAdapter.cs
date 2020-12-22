using AutoFixture.Kernel;
using DryIoc;
using System;

namespace Nemovitosti.Test.TestUtils
{
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
