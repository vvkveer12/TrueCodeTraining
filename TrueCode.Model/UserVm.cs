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
        [Required(ErrorMessage ="Your must fill this field")]
        public string FirstName { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Your must fill this field")]
        public string LastName { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "Your must fill this field")]
        public string UserName { get; set; }
        [StringLength(200)]
        [EmailAddress(ErrorMessage ="Please enter the valid email !")]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
