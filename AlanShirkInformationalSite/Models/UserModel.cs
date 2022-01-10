using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace AlanShirkInformationalSite.Models
{
    public class UserModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int Id { get; set; }
    }
}
