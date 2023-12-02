using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Logic.Inetfaces
{
    public interface IAirportLogic
    {
        void Create(Airports item);
        void Delete(int id);
        Airports Read(int id);
        IQueryable<Airports> ReadAll();
        void Update(Airports item);
    }
}
