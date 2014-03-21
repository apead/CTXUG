﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Dependencies;
using StructureMap;

namespace Big5ServicesGateway.Resolver
{
    public class StructureMapScope : IDependencyScope
    {
        private readonly IContainer container;

        public StructureMapScope(IContainer container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                return null;
            }

            if (serviceType.IsAbstract || serviceType.IsInterface)
            {
                return this.container.TryGetInstance(serviceType);
            }

            return this.container.GetInstance(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return this.container.GetAllInstances(serviceType).Cast<object>();
        }

        public void Dispose()
        {
            this.container.Dispose();
        }
    }
}