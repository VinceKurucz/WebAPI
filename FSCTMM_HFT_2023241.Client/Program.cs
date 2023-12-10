using ConsoleTools;
using FSCTMM_HFT_2023241.Models;
using System;
using System.Linq;
using System.Net;

namespace FSCTMM_HFT_2023241.Client
{
     class Program
    {
        static void Main(string[] args)
        {


           // ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true; //Ezt az SSL exceptionok miatt



            RestService rest = new RestService("http://localhost:18364/");
            CrudServices crud = new CrudServices(rest);
            NonCrudService nonCrud = new NonCrudService(rest);






            var AirplanesMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => crud.List<Airplane>())
               .Add("Create", () => crud.Create<Airplane>())
               .Add("Update", () => crud.Update<Airplane>())
               .Add("Delete", () => crud.Delete<Airplane>())
               .Add("Exit", ConsoleMenu.Close);
          
            var CrewMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => crud.List<Crew>())
               .Add("Create", () => crud.Create<Crew>())
               .Add("Update", () => crud.Update<Crew>())
               .Add("Delete", () => crud.Delete<Crew>())
               .Add("Exit", ConsoleMenu.Close);

            var AirportMenu = new ConsoleMenu(args, level: 1)
               .Add("List", () => crud.List<Airports>())
               .Add("Create", () => crud.Create<Airports>())
               .Add("Update", () => crud.Update<Airports>())
               .Add("Delete", () => crud.Delete<Airports>())
               .Add("Exit", ConsoleMenu.Close);

            var StatsSubMenu = new ConsoleMenu(args, level: 1)
                .Add("Averege seats", () => nonCrud.avgseats())
                .Add("CrewWithBigPlaneSpeed", () => nonCrud.CrewWithBigPlaneSpeed())
                .Add("AirportWithBestCrew", () => nonCrud.AirportWithBestCrew())
                .Add("BigAndGoodPlanesAirports", () => nonCrud.BigAndGoodPlanesAirports())
                .Add("BigAirportsFastPlanes", () => nonCrud.BigAirportsFastPlanes())
                .Add("Exit", ConsoleMenu.Close);

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Airplane", () => AirplanesMenu.Show())
                .Add("Crew", () => CrewMenu.Show())
                .Add("Airport", () => AirportMenu.Show())
                .Add("NonCrud", () => StatsSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

            Console.WriteLine("asd");
        }
    }
}
