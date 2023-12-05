using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Models
{
    public class Crew
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int NumberOfCrew { get; set; }

        public string Reputation { get; set; }

        [ForeignKey("AirplaneId")]
        public int AirplaneId { get; set; }


        [NotMapped]
        public virtual Airlpanes Airlpanes { get; set; }
    }
}
