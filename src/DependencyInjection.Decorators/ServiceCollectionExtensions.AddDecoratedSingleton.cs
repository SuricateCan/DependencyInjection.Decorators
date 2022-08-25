using Microsoft.Extensions.DependencyInjection;
using System;

namespace DependencyInjection.Decorators
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDecoratedSingleton(this IServiceCollection services, Type serviceType, params Type[] decoratorTypes) =>
            services.AddDecorated(ServiceLifetime.Singleton, serviceType, decoratorTypes);

        public static IServiceCollection AddDecoratedSingleton<TServiceType, TDecorator, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedSingleton(typeof(TServiceType), typeof(TDecorator), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedSingleton<TServiceType, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedSingleton(typeof(TServiceType), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedSingleton<TServiceType, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedSingleton(typeof(TServiceType), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedSingleton<TServiceType, TDecorator4, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedSingleton(typeof(TServiceType), typeof(TDecorator4), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedSingleton<TServiceType, TDecorator5, TDecorator4, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedSingleton(typeof(TServiceType), typeof(TDecorator5), typeof(TDecorator4), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));
    }
}
