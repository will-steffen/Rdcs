using Rdcs.Core.Base;

namespace Rdcs.Services.External.SomeIntegration
{
    public class SomeIntegrationService : ISomeIntegrationService
    {
        public string Name()
        {
            return "Service exemple with mock";
        }
    }
}