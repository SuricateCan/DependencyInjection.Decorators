using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection.Decorators
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDecoratedTransient(this IServiceCollection services, Type serviceType, params Type[] decoratorTypes) =>
            services.AddDecorated(ServiceLifetime.Transient, serviceType, decoratorTypes);

        public static IServiceCollection AddDecoratedTransient<TServiceType, TDecorator, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedTransient(typeof(TServiceType), typeof(TDecorator), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedTransient<TServiceType, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedTransient(typeof(TServiceType), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedTransient<TServiceType, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedTransient(typeof(TServiceType), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedTransient<TServiceType, TDecorator4, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedTransient(typeof(TServiceType), typeof(TDecorator4), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedTransient<TServiceType, TDecorator5, TDecorator4, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedTransient(typeof(TServiceType), typeof(TDecorator5), typeof(TDecorator4), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));
    }
}
