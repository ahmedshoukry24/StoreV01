
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
            )).ForMember(x=>x.Media, i => i.MapFrom(c=>new MediaProps { Id = c.Media.Id, URL = c.Media.URL}));

            CreateMap<BranchDto, Branch>().BeforeMap((s, d) =>
            {
                s.CreatedDate = DateTime.Now;
                s.ModifiedDate = null;
                s.DeletedDate = null;
                s.IsDelete = false;
                s.IsActive = false;
                s.Serial = RandomSerial.GenerateSerial(10);
            });
            CreateMap<Branch, BranchDto>().ForMember(x => x.Media, i => i.MapFrom(x => new MediaProps { Id = x.ID, URL = x.Media.URL }));






            CreateMap<CategoryDto, Category>().BeforeMap((s, d) =>
            {
                s.Serial = RandomSerial.GenerateSerial(10);
            });
            CreateMap<Category, CategoryDto>();
            // Products & Variations
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>().BeforeMap((s,d) =>
            {
                s.Serial = RandomSerial.GenerateSerial(15);
                s.ModifiedDate = null;
                s.IsActive = false;
                s.IsDelete = false;
            });

            CreateMap<VariationDto, Variation>();
            CreateMap<Variation, VariationDto>();



            CreateMap<User, Customer>();

        }
    }



}
