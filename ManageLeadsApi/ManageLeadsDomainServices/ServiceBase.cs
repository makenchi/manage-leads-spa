using ManageLeadsDomainCore.Interfaces.Repos;
using ManageLeadsDomainCore.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageLeadsDomainServices
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : class
    {
        private readonly IRepositoryBase<TEntity> _repositoryBase;

        public ServiceBase(IRepositoryBase<TEntity> repositoryBase)
        {
            _repositoryBase = repositoryBase;
        }

        public async Task Add(TEntity obj)
        {
            await _repositoryBase.Add(obj);
        }

        public async Task Delete(TEntity obj)
        {
            await _repositoryBase.Delete(obj);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _repositoryBase.GetAll();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _repositoryBase.GetById(id);
        }

        public async Task Update(TEntity obj)
        {
            await _repositoryBase.Update(obj);
        }
    }
}
