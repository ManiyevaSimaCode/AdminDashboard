using DataAccessLayer.Abstract.EntityFramework.Context;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract.Repositories
{
    public class EFGenericRepository<TEntity> : IGenericDal<TEntity> where TEntity : class, ITable, new()
    {
        public void Add(TEntity entity)
        {
            using (var context=new MemberContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context=new MemberContext())
            {
                var DeleteEntity = context.Entry(entity);
                DeleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(int id)
        {
            using (var context=new MemberContext())
            {
                var result = context.Set<TEntity>().Find(id);
                return result;
            }
        }

        public List<TEntity> GetAll()
        {
            using (var context = new MemberContext())
            {
                var result = context.Set<TEntity>().ToList();
                return result;
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new MemberContext())
            {
                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
