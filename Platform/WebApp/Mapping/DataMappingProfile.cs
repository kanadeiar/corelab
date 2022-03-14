using AutoMapper;
using WebApp.Models;

namespace WebApp.Mapping;

public class DataMappingProfile : Profile
{
    public DataMappingProfile()
    {
        CreateMap<ProductDTO, Product>().ReverseMap();
    }
}
