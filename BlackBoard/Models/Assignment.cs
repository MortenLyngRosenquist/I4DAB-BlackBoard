using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }

        [Required]
        public DateTime HandinDeadline { get; set; }
        [Required]
        public int Attempt { get; set; }
        public int Grade { get; set; }
        [Required]
        public int ParticipantsAllowed { get; set; }

        public Teacher Teacher { get; set; }
        [Required]
        public int TeacherAUID { get; set; }

        public Course Course { get; set; }
        [Required]
        public string CourseName { get; set; }

        public Student Student { get; set; }
        [Required]
        public int StudentAUID { get; set; }


    }
}
