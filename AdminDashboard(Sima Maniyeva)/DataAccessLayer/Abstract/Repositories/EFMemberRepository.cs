using DataAccessLayer.Concrete;
using EntityLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public class EFMemberRepository:EFGenericRepository<Member>,IMemberDal
    {
    }
}
