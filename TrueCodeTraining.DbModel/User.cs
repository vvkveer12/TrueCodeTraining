using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueCodeTraining.DbModel
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage ="This field is required ")]
        public string FirstName { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "This field is required ")]
        public string LastName { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "This field is required ")]
        public string UserName { get; set; }
        [StringLength(200)]
        [Required(ErrorMessage = "This field is required ")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required ")]
        public string Password{ get; set; }

        public bool Status { get; set; }
    }
}
