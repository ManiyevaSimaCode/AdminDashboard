using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public class Speciality:ITable
    {
        public int SpecialityId { get; set; }
        public string SpecialityName { get; set; }
        public List<Member>Members { get; set; }
    }
}
