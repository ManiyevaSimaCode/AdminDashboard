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
    public class SpecialityManager : ISpecialityService
    {
        private readonly ISpecialityDal _specialityDal;
        public SpecialityManager(ISpecialityDal specialityDal)
        {
            _specialityDal = specialityDal;
        }
        public void Add(Speciality entity)
        {
            _specialityDal.Add(entity);
        }

        public void Delete(Speciality entity)
        {
            _specialityDal.Delete(entity);

        }

        public Speciality Get(int id)
        {
           return _specialityDal.Get(id);
        }

        public List<Speciality> GetAll()
        {
            return _specialityDal.GetAll();
        }

        public void Update(Speciality entity)
        {
             _specialityDal.Update(entity);
        }
    }
}
