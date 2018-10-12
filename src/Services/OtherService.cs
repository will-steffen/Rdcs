using Rdcs.Core.Context;
using Rdcs.Core.Attributes;
using Rdcs.Core.Base;
using Rdcs.Models;
using Rdcs.Repositories;

namespace Rdcs.Services
{
    public class OtherService : BaseService
    {
        [Autowired] TodoItemService todoItemService;

        public string Name()
        {
            return todoItemService.Name();
        }
        
    }
}