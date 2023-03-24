using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
namespace EntityLayer.Abstract
{
    public class Member:ITable
    {
        public int MemberId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  int Age { get; set; }
        public  bool Gender { get; set; }

        public DateTime StartTime { get; set; }
        public double Salary { get; set; }
        public int Degree { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }

        public University University { get; set; }
        public int UniversityId { get; set; }
        public Speciality Speciality { get; set; }
        public  int SpecialityId { get; set; }


    }
}
