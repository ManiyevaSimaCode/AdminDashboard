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
    public class AdminManager : IAdminService
    {
        private readonly IAdminDal _adminDal;
        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }
        public void Add(Admin entity)
        {
            _adminDal.Add(entity);
        }

        public void Delete(Admin entity)
        {
           _adminDal.Delete(entity);
        }

        public Admin Get(int id)
        {
            return _adminDal.Get(id);
        }

        public List<Admin> GetAll()
        {
            return _adminDal.GetAll();
        }

        public void Update(Admin entity)
        {
            _adminDal.Update(entity);
        }
    }
}
