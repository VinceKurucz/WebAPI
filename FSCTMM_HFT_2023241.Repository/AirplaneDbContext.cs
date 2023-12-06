using FSCTMM_HFT_2023241.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FSCTMM_HFT_2023241.Repository
{
    public class AirplaneDbContext : DbContext
    {
       public DbSet<Airlpanes> planes { get; set;}
       public DbSet<Crew> crew { get; set; }
       public DbSet<Airports> Airport { get; set; }

        public AirplaneDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("AirplaneDB");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<Airlpanes>()
                .HasOne(a => a.Airports)
                .WithMany(airports => airports.Airlpanes)
                .HasForeignKey(a => a.AirportId);

            modelBuilder.Entity<Airlpanes>()
                .HasMany(a => a.Crew)
                .WithOne(crew => crew.Airlpanes)
                .HasForeignKey(crew => crew.AirplaneId);

            modelBuilder.Entity<Airports>()
                .HasMany(airports => airports.Airlpanes)
                .WithOne(airplane => airplane.Airports)
                .HasForeignKey(airplane => airplane.AirportId);



            ////Airplane->Airport kapcsolat
            //modelBuilder.Entity<Airlpanes>(entity => entity
            //    .HasOne(t => t.Airports)
            //    .WithMany(z => z.Airlpanes)
            //    .HasForeignKey(c => c.AirportId)
            //);


            ////crew->Airplane kapcsolat
            //modelBuilder.Entity<Crew>(entity => entity
            //    .HasOne(t => t.Airlpanes)
            //    .WithMany(z => z.Crew)
            //    .HasForeignKey(c => c.AirplaneId)
            //);



            modelBuilder.Entity<Airports>().HasData(new Airports[]
                {
                    new Airports() { Id = 1, Name ="Budapest Liszt Ferenc", TakeOffPlatform = 1},
                    new Airports() { Id = 2, Name ="Tokyo Haneda", TakeOffPlatform = 3},
                    new Airports() { Id = 3, Name ="Qatar Doha", TakeOffPlatform = 2},
                }
            );
            modelBuilder.Entity<Airlpanes>().HasData(new Airlpanes[]
                {
                    new Airlpanes() { Id = 1, Capacity = 150, AirportId = 2, Speed = 540},
                    new Airlpanes() { Id = 2, Capacity = 10, AirportId = 1, Speed = 630},
                    new Airlpanes() { Id = 3, Capacity = 300, AirportId = 3, Speed = 610},
                    new Airlpanes() { Id = 4, Capacity = 170, AirportId = 2, Speed = 680},
                 }
            );  
            
            modelBuilder.Entity<Crew>().HasData(new Crew[]
                {
                    new Crew(){Id = 1, NumberOfCrew = 8, Reputation = "Good", AirplaneId = 1 },
                    new Crew(){Id = 2, NumberOfCrew = 7, Reputation = "Bad", AirplaneId = 2 },
                    new Crew(){Id = 3, NumberOfCrew = 9, Reputation = "Good", AirplaneId = 3 },
                    new Crew(){Id = 4, NumberOfCrew = 8, Reputation = "Good", AirplaneId = 4 },
                 }
            );




            base.OnModelCreating(modelBuilder);
        }
    }
}
