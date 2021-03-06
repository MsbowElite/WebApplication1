﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Item")]
        public int StateId { get; set; }

        public long CPF { get; set; }

        public long BirthDate { get; set; }

        public State State { get; set; }
    }
}
