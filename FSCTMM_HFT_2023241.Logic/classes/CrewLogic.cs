using FSCTMM_HFT_2023241.Logic.Inetfaces;
using FSCTMM_HFT_2023241.Models;
using FSCTMM_HFT_2023241.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Logic.classes
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
            if (item.NumberOfCrew < 3)
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

        //gépek ahol crew > 8
        public IEnumerable<Airlpanes> avgseats()
        {
            var one = from Crew in repo.ReadAll()
                      where Crew.NumberOfCrew > 8
                      select Crew.Airlpanes;
            return one.Distinct();
        }

        //Crew ahhol a repülőgép sebessége nagyobb mint 
        public IEnumerable<Crew> CrewWithBigPlaneSpeed()
        {
            var two = from Crew in repo.ReadAll()
                      where Crew.Airlpanes.Speed > 600
                      select Crew;
            return two.Distinct().Distinct();
        }

        //Reoülőterek ahhol az ott megforduló gépeken lévő Crew értékelése "Good"
        public IEnumerable<Airports> AirportWithBestCrew()
        {
            var three = from Crew in repo.ReadAll()
                        where Crew.Reputation == "Good"
                        select Crew.Airlpanes.Airports;
            return three.Distinct();
        }

        // A nagy és jó Crew-al rendelkező repűlőgépek repűlőterei
        public IEnumerable<Airports> BigAndGoodPlanesAirports()
        {
            var four = from Crew in repo.ReadAll()
                       where Crew.Reputation == "Good" && Crew.Airlpanes.Capacity > 100
                       select Crew.Airlpanes.Airports;
            return four.Distinct();
        }

        //A nagykapacitású repterek gyors repülőgépei
        public IEnumerable<Airlpanes> BigAirportsFastPlanes()
        {
            var five = from Crew in repo.ReadAll()
                       where Crew.Airlpanes.Speed > 600 && Crew.Airlpanes.Airports.TakeOffPlatform > 1
                       select Crew.Airlpanes;
            return five.Distinct();
        }
    }
}
