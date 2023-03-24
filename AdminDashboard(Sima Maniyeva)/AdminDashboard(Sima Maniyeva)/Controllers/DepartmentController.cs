using AdminDashboard_Sima_Maniyeva_.Models;
using BusinessLogicLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdminDashboard_Sima_Maniyeva_.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IDepartmentService _departmentService;
        private readonly IAdminService _adminService;
        private readonly IUniversityService _universityService;
        private readonly ISpecialityService _specialityService;

        public DepartmentController(
            IMemberService memberService,
            IDepartmentService departmentService,
            IUniversityService universityService,
            ISpecialityService specialityService,
            IAdminService adminService)
            
        {
            _memberService = memberService;
            _departmentService = departmentService;
            _specialityService = specialityService;
            _universityService = universityService;
            _adminService=adminService;
        }

        [HttpGet]
            public IActionResult MainPage()
        {
            if (Request.Cookies["AdminId"] != null)
            {
                List<DashboardViewModel> model = new List<DashboardViewModel>();
                DashboardViewModel department = new DashboardViewModel();
                DashboardViewModel member = AllMembers();
                DashboardViewModel admin = new DashboardViewModel();
              
                admin.Admin = _adminService.Get(Convert.ToInt32(Request.Cookies["AdminId"]));
                department.Departments = _departmentService.GetAll(); 
                model.Add(admin);
                model.Add(department);
                model.Add(member);
                return View(model);

            }
            else
            {
                return RedirectToAction("SignIn", "Admin");
            }
           
        }
        //public List<DashboardViewModel> ITMembers()
        //{
        //    List<DashboardViewModel> model = new List<DashboardViewModel>();
        //    DashboardViewModel ItMembers = new DashboardViewModel();
        //    ItMembers.Members = _memberService.GetAll().Where(I => I.DepartmentId == 2).ToList();
        //    foreach (var member in ItMembers.Members)
        //    {
        //        member.University = _universityService.Get(member.UniversityId);
        //        member.Department = _departmentService.Get(member.DepartmentId);
        //    }
        //    model.Add(ItMembers);
        //    return model;
        //}
        //public List<DashboardViewModel> HRMembers()
        //{
        //    List<DashboardViewModel> model = new List<DashboardViewModel>();
        //    DashboardViewModel HRMembers = new DashboardViewModel();
        //    HRMembers.Members = _memberService.GetAll().Where(I => I.DepartmentId == 1).ToList();
        //    foreach (var member in HRMembers.Members)
        //    {
        //        member.University = _universityService.Get(member.UniversityId);
        //        member.Department = _departmentService.Get(member.DepartmentId);
        //    }
        //    model.Add(HRMembers);
        //    return model;
        //}
        //public List<DashboardViewModel> ACCMembers()
        //{
        //    List<DashboardViewModel> model = new List<DashboardViewModel>();
        //    DashboardViewModel AccMembers = new DashboardViewModel();
        //   AccMembers.Members = _memberService.GetAll().Where(I => I.DepartmentId == 3).ToList();
        //    foreach (var member in AccMembers.Members)
        //    {
        //        member.University = _universityService.Get(member.UniversityId);
        //        member.Speciality = _specialityService.Get(member.SpecialityId);
        //        member.Department = _departmentService.Get(member.DepartmentId);
        //    }
        //    model.Add(AccMembers);
        //    return model;
        //}
        //public List<DashboardViewModel> DMMembers()
        //{
        //    List<DashboardViewModel> model = new List<DashboardViewModel>();
        //    DashboardViewModel DmMembers = new DashboardViewModel();
        //    DmMembers.Members = _memberService.GetAll().Where(I => I.DepartmentId == 4).ToList();
        //    foreach (var member in DmMembers.Members)
        //    {
        //        member.University = _universityService.Get(member.UniversityId);
        //        member.Speciality = _specialityService.Get(member.SpecialityId);
        //        member.Department = _departmentService.Get(member.DepartmentId);
        //    }
        //    model.Add(DmMembers);
        //    return model;
        //}
        //public List<DashboardViewModel> EngineeringMembers()
        //{
        //    List<DashboardViewModel> model = new List<DashboardViewModel>();
        //    DashboardViewModel engineeringMembers = new DashboardViewModel();
        //    engineeringMembers.Members = _memberService.GetAll().Where(I => I.DepartmentId == 6).ToList();
        //    foreach (var member in engineeringMembers.Members)
        //    {
        //        member.University = _universityService.Get(member.UniversityId);
        //        member.Speciality = _specialityService.Get(member.SpecialityId);
        //        member.Department = _departmentService.Get(member.DepartmentId); 
        //    }
        //    model.Add(engineeringMembers);
        //    return model;
        //}
        public DashboardViewModel AllMembers()
        {
            DashboardViewModel model = new DashboardViewModel();
            model.Members= _memberService.GetAll();
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
