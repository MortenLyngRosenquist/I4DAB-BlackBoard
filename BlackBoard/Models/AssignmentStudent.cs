using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class AssignmentStudent
    {
        [Required]
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; }

        [Required]
        public int StudentAUID { get; set; }
        public Student Student { get; set; }


    }
}
