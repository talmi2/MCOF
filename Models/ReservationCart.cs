using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCupOverflows.Models
{
    public class ReservationCart
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Branch { get; set; }

        [Required]
        public string InOut { get; set; }
        [Required]
        public DateTime DateReservation { get; set; }
        [Required]
        public int Seat { get; set; }
        [Required]
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
    }
}