using FSCTMM_HFT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Text.RegularExpressions;
using FSCTMM_HFT_2023241.Models;
using FSCTMM_HFT_2023241.Logic.classes;
using System.Collections.Generic;
using System.Linq;

namespace FSCTMM_2023241.Test
{

    [TestFixture]
    public class Tests
    {
        Airlpanes TestAirlpanes1;
        Airlpanes TestAirlpanes2;
        AirplaneLogic AirplaneLogic1;
        Mock<Irepository<Airlpanes>> MockAirplaneRepo;

        Crew TestCrew1;
        Crew TestCrew2;
        CrewLogic CrewLogic1;
        Mock<Irepository<Crew>> MockCrewRepo;


        Airports TestAirports1;
        Airports TestAirports2;
        AirportLogic AirportLogic1;
        Mock<Irepository<Airports>> MockAirportRepo;


        [SetUp]
        public void Initial()
        {
            MockAirplaneRepo = new Mock<Irepository<Airlpanes>>();
            MockCrewRepo = new Mock<Irepository<Crew>> ();
            MockAirportRepo = new Mock<Irepository<Airports>>();



            TestAirports1 = new Airports();
            TestAirports1.Id = 1;
            TestAirports1.TakeOffPlatform = 2;
            TestAirports1.Name = "Osaka";

            TestAirports2 = new Airports();
            TestAirports2.Id = 2;
            TestAirports2.TakeOffPlatform = 4;
            TestAirports2.Name = "Singapore";



            TestAirlpanes1 = new Airlpanes();
            TestAirlpanes1.Id = 1;
            TestAirlpanes1.AirportId = 1;
            TestAirlpanes1.Capacity = 150;
            TestAirlpanes1.Speed = 600;
            TestAirlpanes1.Airports = TestAirports1;

            TestAirlpanes2 = new Airlpanes();
            TestAirlpanes2.Id = 2;
            TestAirlpanes2.AirportId = 2;
            TestAirlpanes2.Capacity = 120;
            TestAirlpanes2.Speed = 300;
            TestAirlpanes2.Airports = TestAirports2;


            TestCrew1 = new Crew();
            TestCrew1.Id = 1;
            TestCrew1.AirplaneId = 1;
            TestCrew1.Airlpanes = TestAirlpanes1;
            TestCrew1.Reputation = "Good";
            TestCrew1.NumberOfCrew = 9;

            TestCrew2 = new Crew();
            TestCrew2.Id = 2;
            TestCrew2.AirplaneId = 2;
            TestCrew2.Airlpanes = TestAirlpanes2;
            TestCrew2.Reputation = "Bad";
            TestCrew2.NumberOfCrew = 5;



            var Airplanes = new List<Airlpanes>() { TestAirlpanes1, TestAirlpanes2 }.AsQueryable();
           
            MockAirplaneRepo.Setup(k => k.ReadAll()).Returns(Airplanes);
            AirplaneLogic1 = new AirplaneLogic(MockAirplaneRepo.Object);


            var Airports = new List<Airports>() { TestAirports1, TestAirports2 }.AsQueryable();

            MockAirportRepo.Setup(k => k.ReadAll()).Returns(Airports);
            AirportLogic1 = new AirportLogic(MockAirportRepo.Object);


            var Crew = new List<Crew>() { TestCrew1, TestCrew1 }.AsQueryable();

            MockCrewRepo.Setup(k => k.ReadAll()).Returns(Crew);
            CrewLogic1 = new CrewLogic(MockCrewRepo.Object);

        }


        


        [Test]
        public void CreateAirplane()
        {
            var plane = new Airlpanes();

            plane.Capacity = 350 ;

            AirplaneLogic1.Create(plane);

            MockAirplaneRepo.Verify(c => c.Create(plane), Times.Once);          
        }

        [Test]
        public void CreateTooSmallAirplane()
        {
            var plane = new Airlpanes();

            plane.Capacity = 10;

            try
            {
                AirplaneLogic1.Create(plane);
            }
            catch
            {

            }
            MockAirplaneRepo.Verify(c => c.Create(plane), Times.Never);
        }

        [Test]
        public void CreateCrew()
        {
            var crew = new Crew();

            crew.NumberOfCrew = 10;

            CrewLogic1.Create(crew);

            MockCrewRepo.Verify(c => c.Create(crew), Times.Once);
        }

        [Test]
        public void CreateTooSmallCrew()
        {
            var crew = new Crew();

            crew.NumberOfCrew = 1;

            try
            {
                CrewLogic1.Create(crew);
            }
            catch
            {

            }

            MockCrewRepo.Verify(c => c.Create(crew), Times.Never);
        }

        [Test]
        public void CreateAirporto()
        {
            var Airport = new Airports();

            Airport.TakeOffPlatform = 5;

            AirportLogic1.Create(Airport);

            MockAirportRepo.Verify(c => c.Create(Airport), Times.Once);
        }
        [Test]
        public void CreateTooSmallAirport()
        {
            var Airport = new Airports();

            Airport.TakeOffPlatform = 0;

            try
            {
                AirportLogic1.Create(Airport);
            }
            catch { 
            }

            MockAirportRepo.Verify(c => c.Create(Airport), Times.Never);
        }

    }
}
