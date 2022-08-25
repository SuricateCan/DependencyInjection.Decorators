namespace DependencyInjection.Decorators.Tests.TestTypes
{
    public class Decorator1 : IServiceToDecorate
    {
        private readonly IServiceToDecorate service;

        public Decorator1(IServiceToDecorate service)
        {
            this.service = service;
        }

        public string CallToAction()
        {
            var result = service.CallToAction();

            return $"{nameof(Decorator1)} > {result}";
        }
    }
}
