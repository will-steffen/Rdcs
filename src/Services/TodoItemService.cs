using Rdcs.Core.Context;
using Rdcs.Core.Attributes;
using Rdcs.Core.Base;
using Rdcs.Models;
using Rdcs.Repositories;

namespace Rdcs.Services
{
    public class TodoItemService : BaseService
    {
        [Autowired] TodoItemRepository todoItemRepository;
        [Autowired] OtherService otherService;

        public string Name()
        {
            return todoItemRepository.Name();
        }
        
    }
}
