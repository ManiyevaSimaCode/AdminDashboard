using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace EntityLayer.Abstract
{
    public class Department:ITable
    {
        public  int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public List<Member>Members { get; set; }
    }
}
