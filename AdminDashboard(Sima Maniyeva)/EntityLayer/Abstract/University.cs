using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Abstract
{
    public class University:ITable
    {
        public int UniversityId { get; set; }
        public string UniversityName { get; set; }
        public  List<Member>Members { get; set; }
    }
}
