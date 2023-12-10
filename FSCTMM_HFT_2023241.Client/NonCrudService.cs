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

        public void BigCrewPlanes()
        {
            var items = rest.Get<Airplane>("Custom/BigCrewPlanes");
            foreach (var item in items)
            {
                Console.WriteLine("Repülő aminek nagy a személyzete: "+item.Id);
            }
            Console.ReadLine();
        }

        public void CrewWithBigPlaneSpeed()
        {
            var items = rest.Get<Crew>("Custom/CrewWithBigPlaneSpeed");
            foreach (var item in items)
            {
                Console.WriteLine("Személyzet aminek gyors a repülője: "+item.Id);
            }
            Console.ReadLine();
        }

        public void AirportWithBestCrew()
        {
            var items = rest.Get<Airports>("Custom/AirportWithBestCrew");
            foreach (var item in items)
            {
                Console.WriteLine("Reülőtér ahol jó a személyzet: "+item.Name);
            }
            Console.ReadLine();
        }

        public void BigAndGoodPlanesAirports()
        {
            var items = rest.Get<Airports>("Custom/BigAndGoodPlanesAirports");
            foreach (var item in items)
            {
                Console.WriteLine("Reülőtér ahol jó a személyzet és a repülők nagyok: " + item.Name);
            }
            Console.ReadLine();
        }


        public void BigAirportsFastPlanes()
        {
            var items = rest.Get<Airplane>("Custom/BigAirportsFastPlanes");
            foreach (var item in items)
            {
                Console.WriteLine("Nagy kapacitásű, gyors repülőgépek: : "+item.Id);
            }
            Console.ReadLine();
        }



    }
}
