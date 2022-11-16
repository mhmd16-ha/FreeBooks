using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Resource;
namespace infrastructure.ViewModel
{
    public class RoleViwModel
    {
        public List<IdentityRole> Roles { get; set; }
        public NewRole NewRole { get; set; }
       

    }
    public class NewRole
    {
        public string RoleId { get; set; }
        [Required(ErrorMessageResourceType = typeof(ResourceData), ErrorMessageResourceName = "RoleName")]
        public string Name { get; set; }
    }
}
