using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AlanShirkInformationalSite.Models
{
    public class ForumPostModel
    {
        [Required]
        public string Text { get; set; }
        [Required]
        public int Id { get; set; }
        public DateTime PostDate { get; set; } = DateTime.Now;

        public string Page { get; set; } = "Forum";
        public int Rating { get; set; }

        public string User { get; set; }
    }
}
