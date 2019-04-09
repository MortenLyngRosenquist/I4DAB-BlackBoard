using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class TeacherCourse
    {
        [Required]
        public int TeacherAUID { get; set; }
        public Teacher Teacher { get; set; }
        [Required]
        public string CourseName { get; set; }
        public Course Course { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
