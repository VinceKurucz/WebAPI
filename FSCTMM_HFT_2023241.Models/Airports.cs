using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace FSCTMM_HFT_2023241.Models
{
    public class Airports
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }


        [Required]
        [StringLength(100)]
        public string Name { get; set; }


        public int TakeOffPlatform { get; set; }


        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Crew> Crews { get; set; }

        public Airports()
        {
            Crews = new HashSet<Crew>();
        }

    }
}
