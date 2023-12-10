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
        Irepository<Airplane> repo;

        public AirplaneLogic(Irepository<Airplane> rep)
        {
            repo = rep;
        }
        public void Create(Airplane item)
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

        public Airplane Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Airplane> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Airplane item)
        {
            repo.Update(item);
        }
    }
}
