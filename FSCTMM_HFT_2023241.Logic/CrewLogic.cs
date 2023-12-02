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
    public class CrewLogic : ICrewLogic
    {
        Irepository<Crew> repo;

        public CrewLogic(Irepository<Crew> rep)
        {
                repo = rep;
        }
        public void Create(Crew item)
        {
            if(item.NumberOfCrew < 3) 
            {
                throw new ArgumentException("too few crew");
            }
           repo.Create(item);
        }

        public void Delete(int id)
        {
            repo.Delete(id);
        }

        public Crew Read(int id)
        {
           return repo.Read(id);
        }

        public IQueryable<Crew> ReadAll()
        {
            return repo.ReadAll();
        }

        public void Update(Crew item)
        {
            repo.Update(item);
        }
    }
}
