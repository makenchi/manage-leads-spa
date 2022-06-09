using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsApp.Interfaces
{
    public interface IApplicationServiceBase<TEntity> where TEntity : class
    {
        Task Add(TEntity obj);
        Task Update(TEntity obj);
        Task Delete(TEntity obj);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetById(int id);
    }
}
