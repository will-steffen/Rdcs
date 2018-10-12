using Rdcs.Core.Context;
using Rdcs.Core.Base;
using Rdcs.Models;

namespace Rdcs.Repositories
{
    public class TodoItemRepository : BaseModelRepository<TodoItem>
    {

        public string Name() 
        {
            return "Nome";
        }

        public void Create(string name) 
        {
            Save(new TodoItem { Name = name });
        }

    }
}
