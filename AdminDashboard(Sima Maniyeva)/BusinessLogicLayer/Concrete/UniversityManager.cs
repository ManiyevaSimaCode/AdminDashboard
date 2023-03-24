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
    public class UniversityManager : IUniversityService
    {
        private readonly IUniversityDal _universityDal;
        public UniversityManager(IUniversityDal universityDal)
        {
            _universityDal = universityDal;
        }
        public void Add(University entity)
        {
           _universityDal.Add(entity);  
        }

        public void Delete(University entity)
        {
            _universityDal.Delete(entity);

        }

        public University Get(int id)
        {
            return _universityDal.Get(id);
        }

        public List<University> GetAll()
        {
            return _universityDal.GetAll();
        }

        public void Update(University entity)
        {
            _universityDal.Update(entity);
        }
    }
}
