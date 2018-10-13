using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Rdcs.Context;

namespace Rdcs.BaseEntities
{
    public class RdcsDataAccess<T> where T : RdcsModel
    {
        protected readonly RdcsContext Context;

        public virtual T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public virtual void Save(T model)
        {
            DbSet<T> set = Context.Set<T>();
            // ValidateSaveModel(set, model);

            if (model.Id == 0)
            {
                set.Add(model);
            }
            else
            {
                var attached = set.Local.FirstOrDefault(x => x.Id == model.Id);
                if (attached != null)
                {
                    Context.Detach(attached);
                }
                set.Attach(model);
                Context.Entry(model).State = EntityState.Modified;
            }
            Context.SaveChanges();
        }

        public virtual void Delete(T model)
        {
            Context.Set<T>().Remove(model);
        }

        public IEnumerable<T> List()
        {
            return Context.Set<T>();
        }
    }
}
