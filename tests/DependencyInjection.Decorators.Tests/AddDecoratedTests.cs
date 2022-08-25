using Microsoft.Extensions.DependencyInjection;
using DependencyInjection.Decorators.Tests.TestTypes;

namespace DependencyInjection.Decorators.Tests
{
    public class AddDecoratedTests
    {
        private readonly ServiceCollection _services = new();
        private readonly Type[] _serviceDecorators = new[] { typeof(Decorator2), typeof(Decorator1), typeof(OriginalImpl) };
        private readonly Type _serviceType = typeof(IServiceToDecorate);

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void Should_Throw_ForNullServices(ServiceLifetime lifetime)
        {
            Assert.Throws<ArgumentNullException>(() =>
                ServiceCollectionExtensions.AddDecorated(null, lifetime, _serviceType, _serviceDecorators));

        }

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void Should_Throw_ForNullServiceType(ServiceLifetime lifetime)
        {
            Assert.Throws<ArgumentNullException>(() =>
                _services.AddDecorated(lifetime, null, _serviceDecorators));
        }

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void Should_Throw_ForNullDecoratorTypes(ServiceLifetime lifetime)
        {
            Assert.Throws<ArgumentNullException>(() =>
                _services.AddDecorated(lifetime, _serviceType, null));
        }

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void Should_Throw_ForEmptyDecoratorTypes(ServiceLifetime lifetime)
        {
            Assert.Throws<ArgumentException>(() =>
                _services.AddDecorated(lifetime, _serviceType, Array.Empty<Type>()));
        }

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void Should_Register_TypesIndividually(ServiceLifetime lifetime)
        {
            _services.AddDecorated(lifetime, _serviceType, _serviceDecorators);

            Assert.Collection(_services,
                descriptor =>
                {
                    Assert.Equal(lifetime, descriptor.Lifetime);
                    Assert.Equal(typeof(Decorator2), descriptor.ServiceType);
                    Assert.Equal(typeof(Decorator2), descriptor.ImplementationType);
                },
                descriptor =>
                {
                    Assert.Equal(lifetime, descriptor.Lifetime);
                    Assert.Equal(typeof(Decorator1), descriptor.ServiceType);
                    Assert.Equal(typeof(Decorator1), descriptor.ImplementationType);
                },
                descriptor =>
                {
                    Assert.Equal(lifetime, descriptor.Lifetime);
                    Assert.Equal(typeof(OriginalImpl), descriptor.ServiceType);
                    Assert.Equal(typeof(OriginalImpl), descriptor.ImplementationType);
                },
                descriptor =>
                {
                    Assert.Equal(lifetime, descriptor.Lifetime);
                    Assert.Equal(typeof(IServiceToDecorate), descriptor.ServiceType);
                    Assert.NotNull(descriptor.ImplementationFactory);
                });
        }

        [Theory]
        [InlineData(ServiceLifetime.Transient)]
        [InlineData(ServiceLifetime.Scoped)]
        [InlineData(ServiceLifetime.Singleton)]
        public void Should_Resolve_Decorated(ServiceLifetime lifetime)
        {
            const string expected = "Decorator2 > Decorator1 > OriginalImpl";

            using var serviceProvider = _services.AddDecorated(lifetime, _serviceType, _serviceDecorators)
                .BuildServiceProvider();

            var actual = serviceProvider.GetService(_serviceType);

            Assert.NotNull(actual);
            Assert.IsType<Decorator2>(actual);
            Assert.Equal(expected, ((IServiceToDecorate)actual).CallToAction());
        }
    }
}