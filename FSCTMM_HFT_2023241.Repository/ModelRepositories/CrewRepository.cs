using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Repository.ModelRepositories
{
    public class CrewRepository : Repository<Crew>
    {

        public CrewRepository(AirplaneDbContext ctx) : base(ctx)
        {
        }

        public override Crew Read(int id)
        {

            return ctx.crew.FirstOrDefault(x => x.Id == id);
                  
        }


        public override void Update(Crew entity)
        {


            var old = Read(entity.Id);
            
            old.AirportId = entity.AirportId;
            old.AirplaneId = entity.AirplaneId;
            old.Reputation = entity.Reputation;
            old.NumberOfCrew = entity.NumberOfCrew;

            ctx.SaveChanges();
        }
    }
}

