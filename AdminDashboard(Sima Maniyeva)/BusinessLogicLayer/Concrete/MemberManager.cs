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
    public class MemberManager : IMemberService
    {
        private readonly IMemberDal _memberDal;
        public MemberManager(IMemberDal memberDal)
        {
            _memberDal = memberDal;

        }
        public void Add(Member entity)
        {
            _memberDal.Add(entity);
        }

        public void Delete(Member entity)
        {
            _memberDal.Delete(entity);
        }

        public Member Get(int id)
        {
            return _memberDal.Get(id);
        }

        public List<Member> GetAll()
        {
            return _memberDal.GetAll();
        }

        public void Update(Member entity)
        {
            _memberDal.Update(entity);
        }
    }
}
