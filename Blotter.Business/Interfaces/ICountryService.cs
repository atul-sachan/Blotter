using Blotter.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blotter.Business.Interfaces
{
    public interface ICountryService
    {
        //CountryModel Get(string id);
        //Task<CountryModel> GetAsync(string id);
        void Add(CountryModel countryModel);
        Task AddAsync(CountryModel countryModel);
    }
}
