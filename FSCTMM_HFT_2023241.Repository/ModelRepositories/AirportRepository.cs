using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Repository.ModelRepositories
{
    public class AirportRepository : Repository<Airports> //Irepository<Airports>
    {
        public AirportRepository(AirplaneDbContext ctx) : base(ctx)
        {
        }

        public override Airports Read(int id)
        {
            return ctx.Airport.FirstOrDefault(x => x.Id == id);
        }

        public override void Update(Airports entity)
        {

            var old = Read(entity.Id);

            old.TakeOffPlatform = entity.TakeOffPlatform;

            old.Name = entity.Name;

            ctx.SaveChanges();
        }
    }
}
