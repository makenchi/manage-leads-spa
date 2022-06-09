using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsDomainCore.Interfaces.Repos
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
