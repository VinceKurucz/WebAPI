using FSCTMM_HFT_2023241.Logic.Inetfaces;
using FSCTMM_HFT_2023241.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FSCTMM_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]/Action")]
    [ApiController]
    public class CrewController : ControllerBase
    {
        ICrewLogic logic;

        public CrewController(ICrewLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Crew> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Crew Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Crew value)
        {
            this.logic.Create(value);
        }


        [HttpPut]
        public void Update([FromBody] Crew value)
        {
            this.logic.Update(value);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
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
        public IEnumerable<Airlpanes> avgseats()
        {
            return logic.avgseats();
        }

        [HttpGet]
        public IEnumerable<Airports> BigAndGoodPlanesAirports()
        {
            return logic.BigAndGoodPlanesAirports();
        }

        [HttpGet]
        public IEnumerable<Airlpanes> BigAirportsFastPlanes()
        {
            return logic.BigAirportsFastPlanes();
        }

    }
}
