using AdminDashboard_Sima_Maniyeva_.Models;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AdminDashboard_Sima_Maniyeva_.Controllers
{
    public class EventController : Controller
    {
        private readonly IAdminService _adminService;
        public EventController(IAdminService adminService)
        {
            _adminService = adminService;
        }
        public IActionResult MainPage()
        {
            if (Request.Cookies["AdminId"] != null)
            {
                List<DashboardViewModel> model = new List<DashboardViewModel>();
                DashboardViewModel admin = new DashboardViewModel();
                admin.Admin = _adminService.Get(Convert.ToInt32(Request.Cookies["AdminId"]));
                model.Add(admin);
                return View(model);
            }
            else
            {
                return RedirectToAction("SignIn", "Admin");
            }
           
        }
    }
}
