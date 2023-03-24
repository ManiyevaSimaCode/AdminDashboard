using AdminDashboard_Sima_Maniyeva_.Models;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace AdminDashboard_Sima_Maniyeva_.Controllers
{
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IUniversityService _universityService;
        private readonly ISpecialityService _specialityService;
        private readonly IDepartmentService _departmentService;
        private readonly IAdminService _adminService;



        public MemberController(IMemberService memberService,
            IUniversityService universityService, 
            ISpecialityService specialityService,
            IAdminService adminService,
            IDepartmentService departmentService)
        {
            _memberService=memberService; 
            _universityService=universityService;   
            _specialityService=specialityService;
            _adminService = adminService;
            _departmentService = departmentService;
        }
        [HttpGet]
        public IActionResult MainPage()
        {
            if (Request.Cookies["AdminId"]!=null)
            {
                List<DashboardViewModel> model = new List<DashboardViewModel>();
                DashboardViewModel member = AllMembers();
                DashboardViewModel admin = new DashboardViewModel();
                admin.Admin = _adminService.Get(Convert.ToInt32(Request.Cookies["AdminId"]));
                model.Add(admin);
                model.Add(member);
                return View(model);

            }
            else
            {
                return RedirectToAction("SignIn", "Admin");
            }

        }
        public DashboardViewModel AllMembers()
        {
            DashboardViewModel model = new DashboardViewModel();
            model.Members = _memberService.GetAll();
            foreach (var member in model.Members)
            {
                member.University = _universityService.Get(member.UniversityId);
                member.Speciality = _specialityService.Get(member.SpecialityId);
                member.Department = _departmentService.Get(member.DepartmentId);
            }
            return model;
        }

    }
}
