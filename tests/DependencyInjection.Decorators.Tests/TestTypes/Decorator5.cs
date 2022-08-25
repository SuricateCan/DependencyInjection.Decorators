namespace DependencyInjection.Decorators.Tests.TestTypes
{
    public class Decorator5 : IServiceToDecorate
    {
        private readonly IServiceToDecorate service;

        public Decorator5(IServiceToDecorate service)
        {
            this.service = service;
        }

        public string CallToAction()
        {
            var result = service.CallToAction();

            return $"{nameof(Decorator5)} > {result}";
        }
    }
}
