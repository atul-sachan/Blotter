using AutoMapper;
using Blotter.Business.Models;
using Blotter.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blotter.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CountryModel, CountryDto>().ReverseMap();
            CreateMap<StateModel, StateDto>().ReverseMap();
        }
    }
}
