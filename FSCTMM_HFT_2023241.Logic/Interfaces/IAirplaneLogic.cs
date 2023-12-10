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
        void Create(Airplanes item);
        void Delete(int id);
        Airplanes Read(int id);
        IQueryable<Airplanes> ReadAll();
        void Update(Airplanes item);
    }
}

