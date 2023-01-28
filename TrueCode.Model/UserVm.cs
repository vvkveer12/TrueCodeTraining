using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCode.Model
{
    public class UserVm
    {
        public int UserID { get; set; }
        [StringLength(200)]
        [Required]
        public string FirstName { get; set; }
        [StringLength(200)]
        [Required]
        public string LastName { get; set; }
        [StringLength(200)]
        [Required]
        public string UserName { get; set; }
        [StringLength(200)]
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
