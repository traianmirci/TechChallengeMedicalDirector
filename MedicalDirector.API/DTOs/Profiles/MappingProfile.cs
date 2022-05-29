using AutoMapper;
using MedicalDirector.API.DTOs.Users;
using MedicalDirector.Domain.Entities;

namespace MedicalDirector.API.DTOs.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserInfoDTO>();
            CreateMap<Geo, GeoDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<Post, PostDTO>();
            CreateMap<User, UserDetailedDTO>();
        }
    }
}
