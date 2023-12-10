using FSCTMM_HFT_2023241.Logic.Inetfaces;
using FSCTMM_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FSCTMM_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class CustomController : ControllerBase
    {

        ICrewLogic logic;

        public CustomController(ICrewLogic logic)
        {
                this.logic = logic;
        }


        [HttpGet]
        public IEnumerable<Airports> AirportWithBestCrew()
        {
            return logic.AirportWithBestCrew();
        }


        [HttpGet]
        public IEnumerable<Crew> CrewWithBigPlaneSpeed()
        {
            return logic.CrewWithBigPlaneSpeed();
        }

        [HttpGet]
        public IEnumerable<Airplane> BigCrewPlanes()
        {
            return logic.BigCrewPlanes();
        }

        [HttpGet]
        public IEnumerable<Airports> BigAndGoodPlanesAirports()
        {
            return logic.BigAndGoodPlanesAirports();
        }

        [HttpGet]
        public IEnumerable<Airplane> BigAirportsFastPlanes()
        {
            return logic.BigAirportsFastPlanes();
        }


    }
}
