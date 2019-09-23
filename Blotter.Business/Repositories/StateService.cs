using AutoMapper;
using Blotter.Business.Interfaces;
using Blotter.Business.Models;
using Blotter.Common.Extensions;
using Blotter.Domain.Dtos;
using Blotter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blotter.Business.Repositories
{
    public class StateService : IStateService
    {
        private readonly IStateRepository repository;
        private readonly IMapper mapper;

        public StateService(IStateRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(StateModel stateModel)
        {
            repository.Add(mapper.MapTo<StateModel, StateDto>(stateModel));
        }

        public async Task AddAsync(StateModel stateModel)
        {
            await repository.AddAsync(mapper.MapTo<StateModel, StateDto>(stateModel));
        }

        public StateModel Get(string id)
        {
            return mapper.MapTo<StateDto, StateModel>(repository.Get(id));
        }

        public async Task<StateModel> GetAsync(string id)
        {
            return mapper.MapTo<StateDto, StateModel>(await repository.GetAsync(id));
        }
    }
}
