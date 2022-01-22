using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCupOverflows.Models
{
    public class Seat
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string nTable { get; set; }
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public bool Reserve { get; set; }
    }
}