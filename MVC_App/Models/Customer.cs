using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_App.Models
{
    public class Customer
    {

        public int ID { set; get; }
        [Required]
        public string Name { set; get; }
        [Required]

        public string Email { set; get; }
        public string Password { set; get; }

        public int Age { set; get; }
    }
}