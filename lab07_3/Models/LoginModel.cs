using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace lab07_3.Models
{
    public class LoginModel
    {
        [Required]
        public String Email { get; set; }
        public String Password { get; set; }
    }
}