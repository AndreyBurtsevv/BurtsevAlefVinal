using AutoMapper;
using DataService;
using DataService.DataModels;
using DataService.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlefVinalServices.Mappers
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<Value, DBValue>().ReverseMap();          
        }
    }
}
