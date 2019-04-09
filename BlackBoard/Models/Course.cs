using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class Course
    {
        [Key]
        [Required]
        public string CourseName { get; set; }
        public CourseContent CourseContent { get; set; }
        public int CourseContentId { get; set; }
        public List<Assignment> Assignments { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }
        public List<TeacherCourse> TeacherCourses { get; set; }

    }
}
