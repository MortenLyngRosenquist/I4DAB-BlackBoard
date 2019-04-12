using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlackBoard.Models
{
    public class Event
    {
        [Key]
        [Required]
        public string EventName { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public DateTime Deadline { get; set; }

        public Calendar Calender { get; set; }
    }
}
