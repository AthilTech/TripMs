using AutoMapper;
using TripMs.Api.Controllers;
using TripMs.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripMs.Api.Mapper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region Trip 

            CreateMap<Trip, TripDTO>()
           .ReverseMap();
        }
    }
}
         #endregion