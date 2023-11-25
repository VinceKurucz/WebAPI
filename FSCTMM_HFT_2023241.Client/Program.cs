using Microsoft.EntityFrameworkCore;
using System;
using FSCTMM_HFT_2023241.Repository;
using System.Linq;

namespace FSCTMM_HFT_2023241.Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AirplaneDbContext db = new AirplaneDbContext();

            //teszt
            var egy = db.Airport.Select(t => t.TakeOffPlatform);

            ;

        }
    }
}
