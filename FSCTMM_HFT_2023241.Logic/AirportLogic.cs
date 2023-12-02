using FSCTMM_HFT_2023241.Logic.Inetfaces;
using FSCTMM_HFT_2023241.Models;
using FSCTMM_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Logic
{
    public class AirportLogic : IAirportLogic
    {
        Irepository<Airports> repo;

        public AirportLogic(Irepository<Airports> rep)
        {
            repo = rep;
        }
        public void Create(Airports item)
        {
            if (item.TakeOffPlatform == 0)
            {
                throw new ArgumentException("no platforms");
            }
            repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Airports Read(int id)
        {
            return repo.Read(id);
        }

        public IQueryable<Airports> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Airports item)
        {
            repo.Update(item);
        }
    }
}
