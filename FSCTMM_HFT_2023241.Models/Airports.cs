using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Models
{
    public class Airports
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public string Name { get; set; }

        public int TakeOffPlatform { get; set; }


        [NotMapped]
        public virtual ICollection<Airlpanes> Airlpanes { get; set; }




    }
}
