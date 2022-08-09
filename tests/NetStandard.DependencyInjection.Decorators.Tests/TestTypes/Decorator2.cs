namespace NetStandard.DependencyInjection.Decorators.Tests.TestTypes
{
    public class Decorator2 : IServiceToDecorate
    {
        private readonly IServiceToDecorate service;

        public Decorator2(IServiceToDecorate service)
        {
            this.service = service;
        }

        public string CallToAction()
        {
            var result = service.CallToAction();

            return $"{nameof(Decorator2)} > {result}";
        }
    }
}
