using Blotter.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blotter.Domain.Interfaces
{
    public interface IStateRepository
    {
        StateDto Get(string id);
        Task<StateDto> GetAsync(string id);
        void Add(StateDto stateDto);
        Task AddAsync(StateDto stateDto);
    }
}
