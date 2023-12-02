using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Repository.ModelRepositories
{
    public class AirplaneRepository : Repository<Airlpanes>, Irepository<Airlpanes>
    {

        public AirplaneRepository(AirplaneDbContext ctx) : base(ctx)
        {
        }

        public override Airlpanes Read(int id)
        {
            return ctx.planes.FirstOrDefault(x => x.Id == id);
        }


        public override void Update(Airlpanes entity)
        {

            var old = Read(entity.Id);

            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(entity));
            }

            ctx.SaveChanges();
        }
    }
}
