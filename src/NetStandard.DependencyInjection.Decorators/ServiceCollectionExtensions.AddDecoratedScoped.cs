using Microsoft.Extensions.DependencyInjection;
using System;

namespace NetStandard.DependencyInjection.Decorators
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDecoratedScoped(this IServiceCollection services, Type serviceType, params Type[] decoratorTypes) =>
            services.AddDecorated(ServiceLifetime.Scoped, serviceType, decoratorTypes);

        public static IServiceCollection AddDecoratedScoped<TServiceType, TDecorator, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedScoped(typeof(TServiceType), typeof(TDecorator), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedScoped<TServiceType, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedScoped(typeof(TServiceType), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedScoped<TServiceType, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedScoped(typeof(TServiceType), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedScoped<TServiceType, TDecorator4, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedScoped(typeof(TServiceType), typeof(TDecorator4), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));

        public static IServiceCollection AddDecoratedScoped<TServiceType, TDecorator5, TDecorator4, TDecorator3, TDecorator2, TDecorator1, TOriginalImpl>(this IServiceCollection services) =>
            services.AddDecoratedScoped(typeof(TServiceType), typeof(TDecorator5), typeof(TDecorator4), typeof(TDecorator3), typeof(TDecorator2), typeof(TDecorator1), typeof(TOriginalImpl));
    }
}
