using AutoMapper;
using nlog_example.services;

namespace nlog_example.web
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      CreateMap<Product, ProductViewModel>().ReverseMap();
    }
  }
}