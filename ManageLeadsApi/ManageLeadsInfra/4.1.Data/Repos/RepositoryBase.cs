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

        public async Task Add(TEntity obj)
        {
            try
            {
                await _sqlContext.Set<TEntity>().AddAsync(obj);
                await _sqlContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task Delete(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Remove(obj);
                await _sqlContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _sqlContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _sqlContext.Set<TEntity>().FindAsync(id);
        }

        public async Task Update(TEntity obj)
        {
            try
            {
                _sqlContext.Set<TEntity>().Update(obj);
                await _sqlContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }  
}
