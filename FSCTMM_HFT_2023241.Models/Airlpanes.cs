using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Models
{
    public class Airlpanes
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int Id { get; set; }

        public int Capacity { get; set; }

        public int Speed { get; set;}


        [NotMapped]
        public virtual ICollection<Airports> Airports { get; set; }


        [NotMapped]
        public virtual ICollection<People> People { get; set; }

    }
}
