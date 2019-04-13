using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlackboardDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlackBoard.Models
{
    public class Calendar
    {
        public int CalendarId { get; set; }
        [Required]
        public string CourseName { get; set; }
        public Course Course { get; set; }
        
        public List<Event> Events { get; set; }
        
    }
}
