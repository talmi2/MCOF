using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MyCupOverflows.Models
{
    public class ForgetPassword
    {
        [Required]
        [Display(Name = "Username")]
        public string Username { get; set; }
    }
}