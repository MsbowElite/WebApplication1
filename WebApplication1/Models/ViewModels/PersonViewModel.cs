using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModels
{
    public class PersonViewModel
    {

        public string Name { get; set; }
        [Display(Name = "UF")]
        public string StateName { get; set; }
    }
}
