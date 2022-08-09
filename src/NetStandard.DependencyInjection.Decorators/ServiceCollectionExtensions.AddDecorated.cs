using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetStandard.DependencyInjection.Decorators
{
    public static partial class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds the <paramref name="serviceType"/> to the collection decorated with <paramref name="decoratorTypes"/>.
        /// </summary>
        /// <param name="services">Service Collection</param>
        /// <param name="lifetime">The lifetime for all service decorators</param>
        /// <param name="serviceType">The type of the service being decorated. Usually an interface.</param>
        /// <param name="decoratorTypes">A list of all decorator types, like follows: [OuterDecorator, InnerDecorator, OriginalService]</param>
        /// <returns>The service collection</returns>
        public static IServiceCollection AddDecorated(this IServiceCollection services, ServiceLifetime lifetime, Type serviceType, params Type[] decoratorTypes)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (serviceType == null) throw new ArgumentNullException(nameof(serviceType));
            if (decoratorTypes == null) throw new ArgumentNullException(nameof(decoratorTypes));
            if (decoratorTypes.Length == 0) throw new ArgumentException("List of decorators cannot be empty", nameof(decoratorTypes));

            foreach (var decoratorType in decoratorTypes)
            {
                services.Add(new ServiceDescriptor(decoratorType, decoratorType, lifetime));
            }

            services.Add(new ServiceDescriptor(serviceType, CreateServiceFactory(decoratorTypes), lifetime));
            
            return services;
        }

        /// <summary>
        /// Create the service factory for decorated services
        /// </summary>
        /// <param name="decoratorTypes">All types in the chain, from the outer most to the inner most</param>
        /// <returns>Service factory to provide for the service descriptor</returns>
        private static Func<IServiceProvider, object> CreateServiceFactory(Type[] decoratorTypes)
        {
            return sp =>
            {
                var nextType = decoratorTypes[decoratorTypes.Length - 1];
                var nextObject = sp.GetService(nextType);
                if (nextObject == null) throw new InvalidOperationException($"Could not resolve inner most service {nextType.FullName}");

                for (int i = decoratorTypes.Length - 2; i >= 0; i--)
                {
                    nextType = decoratorTypes[i];
                    nextObject = ActivatorUtilities.CreateInstance(sp, nextType, nextObject);
                    if(nextObject == null) throw new InvalidOperationException($"Could not resolve service decorator {nextType.FullName}");
                }

                return nextObject;
            };
        }
    }
}
