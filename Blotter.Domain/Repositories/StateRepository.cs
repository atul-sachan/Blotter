using Blotter.Domain.Interfaces;
using Blotter.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blotter.DataLayer;

namespace Blotter.Domain.Repositories
{
    public class StateRepository : IStateRepository
    {
        private IRepository<StateDto> repository;
        public StateRepository(IRepository<StateDto> repository)
        {
            this.repository = repository;
        }

        public void Add(StateDto stateDto)
        {
            repository.Insert(stateDto);
        }

        public async Task AddAsync(StateDto stateDto)
        {
            await repository.InsertAsync(stateDto);
        }

        public StateDto Get(string id)
        {
            return repository.Get(id);
        }

        public async Task<StateDto> GetAsync(string id)
        {
            return await repository.GetAsync(id);
        }
    }
}
