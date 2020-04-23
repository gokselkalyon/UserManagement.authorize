using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UM.PresentationLayer.Models
{
    public partial class user
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Password { get; set; }
    }
}