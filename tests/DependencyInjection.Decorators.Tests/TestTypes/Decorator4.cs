namespace DependencyInjection.Decorators.Tests.TestTypes
{
    public class Decorator4 : IServiceToDecorate
    {
        private readonly IServiceToDecorate service;

        public Decorator4(IServiceToDecorate service)
        {
            this.service = service;
        }

        public string CallToAction()
        {
            var result = service.CallToAction();

            return $"{nameof(Decorator4)} > {result}";
        }
    }
}
