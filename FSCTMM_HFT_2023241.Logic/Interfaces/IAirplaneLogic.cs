using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Logic.Inetfaces
{
    public interface IAirplaneLogic
    {
        void Create(Airplane item);
        void Delete(int id);
        Airplane Read(int id);
        IQueryable<Airplane> ReadAll();
        void Update(Airplane item);
    }
}

