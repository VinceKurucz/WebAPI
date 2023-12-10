using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json.Serialization;

namespace FSCTMM_HFT_2023241.Models
{
    public class Crew
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }


        [StringLength(120)]
        public string Reputation { get; set; }


        public int NumberOfCrew { get; set; }


        [JsonIgnore]
        [NotMapped]
        public virtual Airplanes Airplanes { get; set; }
        [JsonIgnore]
        [NotMapped]

        public virtual Airports Airports { get; set; }
        [ForeignKey("AirplaneId")]
        public int AirplaneId { get; set; }

        [ForeignKey("AirportId")]
        public int AirportId { get; set; }

        public Crew()
        {

        }
    }
}
