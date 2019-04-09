using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class Teacher
    {
        [Key]
        public int AUID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }

        public List<Assignment> Assignments { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }
    }
}
