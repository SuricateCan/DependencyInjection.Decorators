namespace DependencyInjection.Decorators.Tests.TestTypes
{
    public class Decorator3 : IServiceToDecorate
    {
        private readonly IServiceToDecorate service;

        public Decorator3(IServiceToDecorate service)
        {
            this.service = service;
        }

        public string CallToAction()
        {
            var result = service.CallToAction();

            return $"{nameof(Decorator3)} > {result}";
        }
    }
}
