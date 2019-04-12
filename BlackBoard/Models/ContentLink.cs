using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BlackboardDatabase.Models;

namespace BlackBoard.Models
{
    public class ContentLink
    {
        public int ContentLinkId { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string Type { get; set; }

        public ContentArea ContentArea { get; set; }
    }
}
