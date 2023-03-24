using AdminDashboard_Sima_Maniyeva_.Models;
using BusinessLogicLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace AdminDashboard_Sima_Maniyeva_.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;
        public AdminController(IAdminService adminService)
        {
            _adminService=adminService;
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            Response.Cookies.Delete("AdminId");
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Admin admin)
        {
            if (admin.Email == null)
            {
                DashboardViewModel dashboardViewModel = new DashboardViewModel();
                admin = null;
                dashboardViewModel.ErrorMessage = "Xanaları doldurun";
                return View(dashboardViewModel);
            }
            else
            {
                List<Admin> data = new List<Admin>();
                data = _adminService.GetAll();
                if (data.Exists(I=>I.Email==admin.Email))
                {
                    data=data.Where(I=>I.Email== admin.Email).ToList();
                    if (data.FirstOrDefault().Password==admin.Password)
                    {
                        Response.Cookies.Append("AdminId", data.FirstOrDefault().AdminId.ToString());
                        return RedirectToAction("MainPage", "Home");
                    }
                    else
                    {
                        DashboardViewModel dashboardViewModel = new DashboardViewModel();
                        admin = null;
                        dashboardViewModel.ErrorMessage = "Şifrə yanlışdır.";
                        return View(dashboardViewModel);
                    }
                }
                else
                {
                    DashboardViewModel dashboardViewModel = new DashboardViewModel();
                    admin = null;
                    dashboardViewModel.ErrorMessage = "Email yanlışdır";
                    return View(dashboardViewModel);

                }
            }
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Admin admin)
        {
            DashboardViewModel model=new DashboardViewModel();
            List<Admin> data = _adminService.GetAll();
            if (admin.FirstName==null || admin.LastName==null ||admin.Email==null || admin.Password==null)
            {
                model.ErrorMessage = "Bütün xanaları doldurun";
                return View(model);
            }
            else if(data.Exists(I=>I.Email==admin.Email)){
                model.ErrorMessage = "Bu email artıq istifadədədir.";
                return View(model);

            }
            _adminService.Add(admin);
            return RedirectToAction("SignIn", "Admin");

            
        }
    }
}
