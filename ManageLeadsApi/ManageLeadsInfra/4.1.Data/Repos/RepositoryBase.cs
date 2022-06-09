using ManageLeadsDomainCore.Interfaces.Repos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsInfra.Data.Repos
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly SqlContext _sqlContext;

        public RepositoryBase(SqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public void Add(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Add(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Remove(obj);
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async IEnumerable<TEntity> GetAll()
        {
            return await _sqlContext.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _sqlContext.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            try
            {
                _sqlContext.Entry(obj).State = EntityState.Modified;
                _sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }  
}
