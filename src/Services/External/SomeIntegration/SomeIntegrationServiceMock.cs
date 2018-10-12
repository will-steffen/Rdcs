using Rdcs.Core.Base;

namespace Rdcs.Services.External.SomeIntegration
{
    public class SomeIntegrationServiceMock : ISomeIntegrationService
    {
        public string Name()
        {
            return "Service Mock exemple with another mock";
        }
    }
}
