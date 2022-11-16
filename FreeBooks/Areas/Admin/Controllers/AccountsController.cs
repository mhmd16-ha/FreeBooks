using infrastructure.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeBooks.Areas.Admin.Controllers
{
   
    [Area("Admin")]
    public class AccountsController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountsController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Role()
        {
            var role = new RoleViwModel
            {
                NewRole = new NewRole(),
                Roles = _roleManager.Roles.OrderBy(x => x.Name).ToList()

            };
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>Role(RoleViwModel model)
        {
            if (ModelState.IsValid)
            {
                   var role = new IdentityRole
                {
                    Id = model.NewRole.RoleId,
                    Name = model.NewRole.Name,
                };
                //create
                if (role.Id == null)
                {
                    role.Id = Guid.NewGuid().ToString();
                   var result=await _roleManager.CreateAsync(role);
                    if (result.Succeeded)// Succeeded 
                    {
                        HttpContext.Session.SetString("msgType", "success");
                        HttpContext.Session.SetString("title", "تم الحفظ");
                        HttpContext.Session.SetString("msg", "تمت العملية بنجاح");


                    }
                    else
                    {
                        HttpContext.Session.SetString("msgType", "error");
                        HttpContext.Session.SetString("title", "لم يتم الحفظ");
                        HttpContext.Session.SetString("msg", "لم تتم العملية بنجاح");

                    }
                }//update
                else
                {
                    var roleUpdate = await _roleManager.FindByIdAsync(role.Id);
                    roleUpdate.Id = model.NewRole.RoleId;
                    roleUpdate.Name = model.NewRole.Name;
                    var result = await _roleManager.UpdateAsync(roleUpdate);

                    if (result.Succeeded)// Succeeded 
                    {
                        HttpContext.Session.SetString("msgType", "success");
                        HttpContext.Session.SetString("title", "تم الحفظ");
                        HttpContext.Session.SetString("msg", "تمت العملية بنجاح");


                    }
                    else
                    {
                        HttpContext.Session.SetString("msgType", "error");
                        HttpContext.Session.SetString("title", "لم يتم الحفظ");
                        HttpContext.Session.SetString("msg", "لم تتم العملية بنجاح");

                    }

                }
            }
            return RedirectToAction("Role");
        }
        public async Task<IActionResult> DeleteRole(string id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
          
           if ((await _roleManager.DeleteAsync(role)).Succeeded) { 
                return RedirectToAction(nameof(Role));
            }
            return RedirectToAction(nameof(Role));

        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
