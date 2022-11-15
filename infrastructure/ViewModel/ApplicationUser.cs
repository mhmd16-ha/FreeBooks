using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace infrastructure.ViewModel
{
   public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string ImageUser { get; set; }
        public bool ActiveUser { get; set; }
    }
}
