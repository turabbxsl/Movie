using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Filmsayt.appclass
{
    public class Changepasswordmodel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Currentpassword")]
        public string Currentpassword { get; set; }

       
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Newpassword")]
        public string Newpassword { get; set; }

      
        
        [DataType(DataType.Password)]
        [Display(Name = "Confirmpassword")]
        [Compare("Newpassword",ErrorMessage ="Uygunluq Yoxdur")]
        public string Confirmpassword { get; set; }
    }
}