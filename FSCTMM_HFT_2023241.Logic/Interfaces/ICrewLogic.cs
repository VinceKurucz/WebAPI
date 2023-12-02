using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Logic.Inetfaces
{
    public interface ICrewLogic
    {
        void Create(Crew item);
        void Delete(int id);
        Crew Read(int id);
        IQueryable<Crew> ReadAll();
        void Update(Crew item);

    }
}
