using Blotter.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blotter.Business.Interfaces
{
    public interface IStateService
    {
        //StateModel Get(string id);
        //Task<StateModel> GetAsync(string id);
        void Add(StateModel stateModel);
        Task AddAsync(StateModel stateModel);
    }
}
