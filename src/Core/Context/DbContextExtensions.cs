using Microsoft.EntityFrameworkCore;

namespace Rdcs.Core.Context
{
    public static class DbContextExtensions
    {
        public static void Detach(this DbContext context, object entity)
        {
            //((IObjectContextAdapter)context).ObjectContext.Detach(entity);
        }
    }
}

