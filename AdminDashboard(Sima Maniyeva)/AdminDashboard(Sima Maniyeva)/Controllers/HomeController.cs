
using AdminDashboard_Sima_Maniyeva_.Models;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdminDashboard_Sima_Maniyeva_.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdminService _adminService;
        private readonly IMemberService _memberService;
        public HomeController(IAdminService adminService,IMemberService memberService)
        {
            _adminService = adminService;
            _memberService = memberService;
        }
        public IActionResult MainPage()
        {
            if (Request.Cookies["AdminId"]!=null)
            {
                List<DashboardViewModel> Members = new List<DashboardViewModel>();
                DashboardViewModel admin=new DashboardViewModel();
                admin.Admin = _adminService.Get(Convert.ToInt32(Request.Cookies["AdminId"]));
                Members.Add(admin);
                return View(Members);

            }
            else
            {
                return RedirectToAction("SignIn","Admin");


            }
        }

    }
}
