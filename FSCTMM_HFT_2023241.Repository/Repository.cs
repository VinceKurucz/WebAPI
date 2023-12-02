using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Repository
{
    public abstract class Repository<T> : Irepository<T>where T : class
    {

        public AirplaneDbContext ctx;

        public Repository(AirplaneDbContext ctx)
        {
            this.ctx = ctx;
        }
        public void Create(T entity)
        {
            ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
        }

        public void Delete(int id)
        {
            ctx.Set<T>().Remove(Read(id));
        }

        public abstract T Read(int id);


        public IQueryable<T> ReadAll()
        {
           return ctx.Set<T>();
        }

        public abstract void Update(T entity);

    }
}
