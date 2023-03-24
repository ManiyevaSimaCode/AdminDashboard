using BusinessLogicLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;
        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public void Add(Department entity)
        {
          _departmentDal.Add(entity);
        }

        public void Delete(Department entity)
        {
            _departmentDal.Delete(entity);  
        }

        public Department Get(int id)
        {
            return _departmentDal.Get(id);
        }

        public List<Department> GetAll()
        {
            return _departmentDal.GetAll();
        }

        public void Update(Department entity)
        {
            _departmentDal.Update(entity);
        }
    }
}
