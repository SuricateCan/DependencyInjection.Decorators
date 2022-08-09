namespace NetStandard.DependencyInjection.Decorators.Tests.TestTypes
{
    public class OriginalImpl : IServiceToDecorate
    {
        public string CallToAction()
        {
            return $"{nameof(OriginalImpl)}";
        }
    }
}
