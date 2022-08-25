using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.Decorators.Tests.TestTypes;

namespace DependencyInjection.Decorators.Tests
{
    public class AddDecoratedSingletonTests
    {
        private readonly ServiceCollection _services = new();
        private readonly Type[] _serviceDecorators = new[] { typeof(Decorator2), typeof(Decorator1), typeof(OriginalImpl) };
        private readonly Type _serviceType = typeof(IServiceToDecorate);

        [Fact]
        public void Should_Throw_ForNullServices()
        {
            Assert.Throws<ArgumentNullException>(() =>
                ServiceCollectionExtensions.AddDecoratedSingleton(null, _serviceType, _serviceDecorators));

        }

        [Fact]
        public void Should_Throw_ForNullServiceType()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _services.AddDecoratedSingleton(null, _serviceDecorators));
        }

        [Fact]
        public void Should_Throw_ForNullDecoratorTypes()
        {
            Assert.Throws<ArgumentNullException>(() =>
                _services.AddDecoratedSingleton(_serviceType, null));
        }

        [Fact]
        public void Should_Throw_ForEmptyDecoratorTypes()
        {
            Assert.Throws<ArgumentException>(() =>
                _services.AddDecoratedSingleton(_serviceType, Array.Empty<Type>()));
        }

        [Fact]
        public void Should_Register_TypesIndividually()
        {
            _services.AddDecoratedSingleton(_serviceType, _serviceDecorators);

            Assert.Collection(_services,
                descriptor =>
                {
                    Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
                    Assert.Equal(typeof(Decorator2), descriptor.ServiceType);
                    Assert.Equal(typeof(Decorator2), descriptor.ImplementationType);
                },
                descriptor =>
                {
                    Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
                    Assert.Equal(typeof(Decorator1), descriptor.ServiceType);
                    Assert.Equal(typeof(Decorator1), descriptor.ImplementationType);
                },
                descriptor =>
                {
                    Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
                    Assert.Equal(typeof(OriginalImpl), descriptor.ServiceType);
                    Assert.Equal(typeof(OriginalImpl), descriptor.ImplementationType);
                },
                descriptor =>
                {
                    Assert.Equal(ServiceLifetime.Singleton, descriptor.Lifetime);
                    Assert.Equal(typeof(IServiceToDecorate), descriptor.ServiceType);
                    Assert.NotNull(descriptor.ImplementationFactory);
                });
        }

        [Fact]
        public void Should_Resolve_Decorated()
        {
            const string expected = "Decorator2 > Decorator1 > OriginalImpl";

            using var serviceProvider = _services.AddDecoratedSingleton(_serviceType, _serviceDecorators)
                .BuildServiceProvider();

            var actual = serviceProvider.GetService(_serviceType);

            Assert.NotNull(actual);
            Assert.IsType<Decorator2>(actual);
            Assert.Equal(expected, ((IServiceToDecorate)actual).CallToAction());
        }

        [Fact]
        public void Should_Resolve_TypedWith1Decorators()
        {
            const string expected = "Decorator1 > OriginalImpl";

            using var serviceProvider = _services.AddDecoratedSingleton<IServiceToDecorate, Decorator1, OriginalImpl>()
                .BuildServiceProvider();

            var actual = serviceProvider.GetService(_serviceType);

            Assert.NotNull(actual);
            Assert.IsType<Decorator1>(actual);
            Assert.Equal(expected, ((IServiceToDecorate)actual).CallToAction());
        }

        [Fact]
        public void Should_Resolve_TypedWith2Decorators()
        {
            const string expected = "Decorator2 > Decorator1 > OriginalImpl";

            using var serviceProvider = _services.AddDecoratedSingleton<IServiceToDecorate, Decorator2, Decorator1, OriginalImpl>()
                .BuildServiceProvider();

            var actual = serviceProvider.GetService(_serviceType);

            Assert.NotNull(actual);
            Assert.IsType<Decorator2>(actual);
            Assert.Equal(expected, ((IServiceToDecorate)actual).CallToAction());
        }

        [Fact]
        public void Should_Resolve_TypedWith3Decorators()
        {
            const string expected = "Decorator3 > Decorator2 > Decorator1 > OriginalImpl";

            using var serviceProvider = _services.AddDecoratedSingleton<IServiceToDecorate, Decorator3, Decorator2, Decorator1, OriginalImpl>()
                .BuildServiceProvider();

            var actual = serviceProvider.GetService(_serviceType);

            Assert.NotNull(actual);
            Assert.IsType<Decorator3>(actual);
            Assert.Equal(expected, ((IServiceToDecorate)actual).CallToAction());
        }

        [Fact]
        public void Should_Resolve_TypedWith4Decorators()
        {
            const string expected = "Decorator4 > Decorator3 > Decorator2 > Decorator1 > OriginalImpl";

            using var serviceProvider = _services.AddDecoratedSingleton<IServiceToDecorate, Decorator4, Decorator3, Decorator2, Decorator1, OriginalImpl>()
                .BuildServiceProvider();

            var actual = serviceProvider.GetService(_serviceType);

            Assert.NotNull(actual);
            Assert.IsType<Decorator4>(actual);
            Assert.Equal(expected, ((IServiceToDecorate)actual).CallToAction());
        }

        [Fact]
        public void Should_Resolve_TypedWith5Decorators()
        {
            const string expected = "Decorator5 > Decorator4 > Decorator3 > Decorator2 > Decorator1 > OriginalImpl";

            using var serviceProvider = _services.AddDecoratedSingleton<IServiceToDecorate, Decorator5, Decorator4, Decorator3, Decorator2, Decorator1, OriginalImpl>()
                .BuildServiceProvider();

            var actual = serviceProvider.GetService(_serviceType);

            Assert.NotNull(actual);
            Assert.IsType<Decorator5>(actual);
            Assert.Equal(expected, ((IServiceToDecorate)actual).CallToAction());
        }
    }
}