using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class CourseContent
    {      
        [Key]
        public int CourseContentId { get; set; }
        public List<Folder> Folders { get; set; }
        public List<ContentArea> ContentAreas { get; set; }
        [Required]
        public string CourseName { get; set; }
        public Course Course { get; set; }
    }
}
