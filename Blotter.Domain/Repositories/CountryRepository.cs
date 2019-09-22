using Blotter.Domain.Interfaces;
using Blotter.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using Blotter.DataLayer;
using System.Threading.Tasks;

namespace Blotter.Domain.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private IRepository<CountryDto> repository;
        public CountryRepository(IRepository<CountryDto> repository)
        {
            this.repository = repository;
        }

        public void Add(CountryDto countryDto)
        {
            repository.Insert(countryDto);
        }

        public async Task AddAsync(CountryDto countryDto)
        {
            await repository.InsertAsync(countryDto);
        }

        public CountryDto Get(string id)
        {
            return repository.Get(id);
        }

        public async Task<CountryDto> GetAsync(string id)
        {
            return await repository.GetAsync(id);
        }
    }
}
