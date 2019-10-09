using ConsoleAutoMapper.domain;
using ConsoleAutoMapper.DTO;
using AutoMapper;

namespace ConsoleAutoMapper.core.maps
{
    public class DomainMappingProfile : Profile    
    {
        public DomainMappingProfile()
        {
            CreateMap<product, productDTO>()
                .ForMember(dest => dest.productId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.productName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.SKU, opt => opt.MapFrom(src => src.SKU))
                .ForMember(dest => dest.quantity, opt => opt.MapFrom(src => src.quanity));

            CreateMap<order, orderDTO>()
                .ForMember(dest => dest.orderId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.createDate, opt => opt.MapFrom(src => src.createDate))
                .ForMember(dest => dest.userId, opt => opt.MapFrom(src => src.userId))
                .ForMember(dest => dest.orderedProducts, opt => opt.MapFrom(src => src.products));


        }
    }
}