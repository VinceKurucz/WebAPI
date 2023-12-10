using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Models
{
    public class Airplanes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Capacity { get; set; }

        public int AirportId { get; set; }

        public int Speed { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Crew> Crews { get; set; }


        public Airplanes()
        {

        }

    }
}
