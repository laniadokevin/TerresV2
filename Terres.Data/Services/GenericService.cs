using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Terres.Core.Services;

namespace Terres.Data.Services
{
    public partial class GenericService<T> : IGenericService<T> where T : class
    {

        private IGenericService<T> _genericRepository;
        public JojmaDbContext context;

        public GenericService(IGenericService<T> genericRepository)
        {
            _genericRepository = genericRepository;

        }

        public GenericService(JojmaDbContext context)
        {
            this.context = context;
        }

        public async Task Delete(T entity)
        {
            await _genericRepository.Delete(entity);
        }

        public async Task<List<T>> GetAll(object id)
        {
            return await _genericRepository.GetAll(id);
        }

        public async Task<T> GetById(object id)
        {
            return await _genericRepository.GetById(id);
        }

        public async Task<T> Insert(T entity)
        {
            return await _genericRepository.Insert(entity);
        }

        public async Task<T> Update(T entity)
        {
            return await _genericRepository.Update(entity);
        }
    }

}