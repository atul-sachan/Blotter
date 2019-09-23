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
using Microsoft.Extensions.Logging;

namespace Blotter.Business.Repositories
{
    public class CountryService: ICountryService
    {
        private readonly ILogger<CountryService> logger;
        private readonly ICountryRepository repository;
        //private readonly IMapper mapper;

        public CountryService(ILogger<CountryService> logger, ICountryRepository repository)
        {
            this.logger = logger;
            this.repository = repository;
        }
        //public CountryService(ICountryRepository repository, IMapper mapper)
        //{
        //    this.repository = repository;
        //    this.mapper = mapper;
        //}

        public void Add(CountryModel countryModel)
        {
            logger.LogInformation(countryModel.Name);
            //repository.Add(mapper.MapTo<CountryModel, CountryDto>(countryModel));
        }

        public async Task AddAsync(CountryModel countryModel)
        {
            //logger.LogInformation(countryModel.Name);
            //await repository.AddAsync(mapper.MapTo<CountryModel, CountryDto>(countryModel));
        }

        //public CountryModel Get(string id)
        //{
        //    return mapper.MapTo<CountryDto, CountryModel>(repository.Get(id));
        //}

        //public async Task<CountryModel> GetAsync(string id)
        //{
        //    return mapper.MapTo<CountryDto, CountryModel>(await repository.GetAsync(id));
        //}
    }
}
