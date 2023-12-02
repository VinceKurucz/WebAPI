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
        void Create(Airlpanes item);
        void Delete(int id);
        Airlpanes Read(int id);
        IQueryable<Airlpanes> ReadAll();
        void Update(Airlpanes item);
    }
}

