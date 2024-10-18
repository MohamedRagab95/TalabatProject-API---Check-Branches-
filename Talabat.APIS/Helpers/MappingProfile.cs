using AutoMapper;
using Talabat.APIS.DTOs;
using Talabat.Core.Entities;

namespace Talabat.APIS.Helpers
{
    public class MappingProfile :Profile
    {

        public MappingProfile()
        {
            CreateMap<Product, ProductDtO>()
                        .ForMember(d => d.Brand, o => o.MapFrom(d => d.Brand.Name))
                        .ForMember(d => d.Category, o => o.MapFrom(d => d.Category.Name))
                        .ForMember(d => d.PictureUrl, o => o.MapFrom<ProductPictureURLResolver>());
            CreateMap<CustomerBasketDto, CustomerBasket>();
            CreateMap<BasketItemDto, BasketItem>(); 
        }
    }
}
