using Blotter.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blotter.Domain.Interfaces
{
    public interface ICountryRepository
    {
        //CountryDto Get(string id);
        //Task<CountryDto> GetAsync(string id);
        void Add(CountryDto countryDto);
        Task AddAsync(CountryDto countryDto);
    }
}
