using Rdcs.Core.Base;

namespace Rdcs.Services.External.SomeIntegration
{
    public class SomeIntegrationBusiness : BaseService
    {
        ISomeIntegrationService service;

        public SomeIntegrationBusiness() 
        {
            this.service = new SomeIntegrationService();
        }

        public string Name()
        {
            return service.Name();
        }
    }
}