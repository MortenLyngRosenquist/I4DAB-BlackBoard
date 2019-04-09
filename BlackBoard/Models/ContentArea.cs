using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlackboardDatabase.Models
{
    public class ContentArea
    {
        [Key]
        public int ContentAreaId { get; set; }
        public string TextBlock { get; set; }
        public CourseContent CourseContent { get; set; }
        [Required]
        public int CourseContentId { get; set; }
        public Folder Folder { get; set; }
        public int FolderId { get; set; }

    }
}
