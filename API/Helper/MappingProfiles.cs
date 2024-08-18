
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Models;
using Core.Entities;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<StoreDto, Store>();
            CreateMap<Store, StoreDto>().ForMember(x => x.Branches,
                i => i.MapFrom(c => c.Branches.Select(v => new BranchProps
                {
                    name = v.Name,
                    address = v.Address
                })
            ));
            CreateMap<BranchDto, Branch>();

            CreateMap<CategoryDto,Category>();
            // check on update
            CreateMap<ProductDto, Product>().BeforeMap((s,d)=>d.CreatedDate = DateTime.Now);
            CreateMap<Product, ProductDto>();

        }
    }



}
