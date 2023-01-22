using AutoMapper;
using ProiectV1.Models;
using ProiectV1.Models.DTOs;

namespace ProiectV1.Helpers.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //populez baza de date mai repede
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductDTO>()
                .ForMember(dest => dest.ProductId,
                opts => opts.MapFrom(source => source.Id)).ReverseMap();
            
        }
    }
}
