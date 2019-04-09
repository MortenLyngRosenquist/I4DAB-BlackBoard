using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class Folder
    {
        [Key]
        public int FolderId { get; set; }
        [Required]
        public string FolderName { get; set; }
        [Required]
        public int CourseContentId { get; set; }
        public CourseContent CourseContent { get; set; }
        public List<ContentArea> ContentAreas { get; set; }

    }
}
