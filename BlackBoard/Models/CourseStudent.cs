using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class CourseStudent
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public int StudentAUID { get; set; }
        [Required]
        public string Status { get; set; }
        public int Grade { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
        
    }
}
