using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyCupOverflows.Models
{
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Branch { get; set; }

        [Required(ErrorMessage = "Please Enter Inside or Outside...")]
        public string InOut { get; set; }
        [Required(ErrorMessage = "Please Enter a Date to reserve...")]
        public DateTime DateReservation { get; set; }
        [Required(ErrorMessage = "Please Enter Seat...")]
        public int Seat { get; set; }
        [Required(ErrorMessage = "Please Enter Cost...")]
        public decimal Cost { get; set; }

    }
}