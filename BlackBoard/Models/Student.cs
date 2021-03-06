﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;


namespace BlackboardDatabase.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int AUID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public DateTime EnrollmentDate { get; set; }
        [Required]
        public DateTime GraduationDate { get; set; }

        public List<AssignmentStudent> AssignmentStudents { get; set; }
        public List<CourseStudent> CourseStudents { get; set; }

        
    }
}
