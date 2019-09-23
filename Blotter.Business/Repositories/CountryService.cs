using AutoMapper;
using Blotter.Business.Interfaces;
using Blotter.Business.Models;
using Blotter.Domain.Dtos;
using Blotter.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blotter.Common.Extensions;

namespace Blotter.Business.Repositories
{
    public class CountryService: ICountryService
    {
        private readonly ICountryRepository repository;
        private readonly IMapper mapper;

        public CountryService(ICountryRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Add(CountryModel countryModel)
        {
            repository.Add(mapper.MapTo<CountryModel, CountryDto>(countryModel));
        }

        public async Task AddAsync(CountryModel countryModel)
        {
            await repository.AddAsync(mapper.MapTo<CountryModel, CountryDto>(countryModel));
        }

        public CountryModel Get(string id)
        {
            return mapper.MapTo<CountryDto, CountryModel>(repository.Get(id));
        }

        public async Task<CountryModel> GetAsync(string id)
        {
            return mapper.MapTo<CountryDto, CountryModel>(await repository.GetAsync(id));
        }
    }
}
