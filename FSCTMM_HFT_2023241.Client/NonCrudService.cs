using FSCTMM_HFT_2023241.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Client
{
     class NonCrudService
    {
        private RestService rest;
        public NonCrudService(RestService rest)
        {
            this.rest = rest;
        }

        public void avgseats()
        {
            var items = rest.Get<Airplanes>("Stat/avgseats");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void CrewWithBigPlaneSpeed()
        {
            var items = rest.Get<Crew>("Stat/CrewWithBigPlaneSpeed");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void AirportWithBestCrew()
        {
            var items = rest.Get<Airports>("Stat/AirportWithBestCrew");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        public void BigAndGoodPlanesAirports()
        {
            var items = rest.Get<Airports>("Stat/BigAndGoodPlanesAirports");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }


        public void BigAirportsFastPlanes()
        {
            var items = rest.Get<Airplanes>("Stat/BigAirportsFastPlanes");
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }



    }
}
