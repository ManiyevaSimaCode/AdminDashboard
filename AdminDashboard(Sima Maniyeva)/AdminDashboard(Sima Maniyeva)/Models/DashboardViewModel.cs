using EntityLayer.Abstract;
using System.Collections.Generic;

namespace AdminDashboard_Sima_Maniyeva_.Models
{
    public class DashboardViewModel
    {
        public List<Admin> Admins { get; set; }
        public Admin Admin { get; set; }
        public List<Speciality>Specialities { get; set; }
        public Speciality Speciality { get; set; }
        public List<Department>Departments { get; set; }
        public Department Department { get; set; }
        public List<University>Universities { get; set; }
        public University University { get; set; }
        public List<Member>Members { get; set; }
        public Member Member { get; set; }
        public string ErrorMessage { get;set; }

    }
}
