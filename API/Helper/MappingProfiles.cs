
using AutoMapper;
using Core.DTOs;
using Core.DTOs.Models;
using Core.Entities;
using Core.Entities.User;

namespace API.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            // Store & Branch
            CreateMap<StoreDto, Store>().BeforeMap((s, d) =>
            {
                s.IsActive = false;
                s.IsDelete = false;
                s.CreatedDate = DateTime.Now;
                s.ModifiedDate = null;
                s.DeletedDate = null;
                s.Serial = RandomSerial.GenerateSerial(10);
            });

            CreateMap<Store, StoreDto>().ForMember(x => x.Branches,
                i => i.MapFrom(c => c.Branches.Select(v => new BranchProps
                {
                    ID = v.ID,
                    name = v.Name,
                    address = v.Address
                })
            ));
            CreateMap<BranchDto, Branch>().BeforeMap((s, d) =>
            {
                s.CreatedDate = DateTime.Now;
                s.ModifiedDate = null;
                s.DeletedDate = null;
                s.IsDelete = false;
                s.IsActive = false;
                s.Serial = RandomSerial.GenerateSerial(10);
            });
            CreateMap<Branch, BranchDto>();





            CreateMap<CategoryDto,Category>();
            // Products & Variations
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<VariationDto, Variation>();
            CreateMap<Variation, VariationDto>();



            CreateMap<User, Customer>();

        }
    }



}
