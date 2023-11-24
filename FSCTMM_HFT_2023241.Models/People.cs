﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSCTMM_HFT_2023241.Models
{
    public class People
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int Name { get; set; }

        public string Gender { get; set; }



        [NotMapped]
        public virtual ICollection<Airlpanes> Airlpanes { get; set; }
    }
}
