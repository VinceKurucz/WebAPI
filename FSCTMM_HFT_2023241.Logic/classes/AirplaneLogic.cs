using FSCTMM_HFT_2023241.Logic.Inetfaces;
using FSCTMM_HFT_2023241.Models;
using FSCTMM_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Logic.classes
{
    public class AirplaneLogic : IAirplaneLogic
    {
        Irepository<Airplanes> repo;

        public AirplaneLogic(Irepository<Airplanes> rep)
        {
            repo = rep;
        }
        public void Create(Airplanes item)
        {
            if (item.Capacity < 30)
            {
                throw new ArgumentException("too few seats");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Airplanes Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Airplanes> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Airplanes item)
        {
            repo.Update(item);
        }
    }
}
