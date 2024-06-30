using AutoMapper;
using RestfulApi.Entity;
using RestfulApi.Entity.Dto;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestfulApi.Mapping.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddProductDto, Product>()
           .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
           .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
           .ForPath(dest => dest.ProductDetail.Amount, opt => opt.MapFrom(src => src.Amount))
           .ForPath(dest => dest.ProductDetail.DetailText, opt => opt.MapFrom(src => src.DetailText));


            CreateMap<UpdateProductDto, Product>()
                        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
        .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
        .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.ProductPrice))
        .ForPath(dest => dest.ProductDetail.Amount, opt => opt.MapFrom(src => src.Amount))
        .ForPath(dest => dest.ProductDetail.DetailText, opt => opt.MapFrom(src => src.DetailText));
        }
    }
}
