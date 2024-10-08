﻿using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Repository.ModelRepositories
{
    public class AirplaneRepository : Repository<Airplane>
    {

        public AirplaneRepository(AirplaneDbContext ctx) : base(ctx)
        {
        }

        public override Airplane Read(int id)
        {
            return ctx.planes.FirstOrDefault(x => x.Id == id);
        }


        public override void Update(Airplane entity)
        {

            var old = Read(entity.Id);

            old.Capacity = entity.Capacity;
            old.Speed = entity.Speed;
            old.AirportId = entity.AirportId;


            ctx.SaveChanges();
        }
    }
}
