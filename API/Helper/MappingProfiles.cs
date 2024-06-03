using API.DTOs;
using AutoMapper;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<StoreDto, Store>();
        }
    }


    
}
