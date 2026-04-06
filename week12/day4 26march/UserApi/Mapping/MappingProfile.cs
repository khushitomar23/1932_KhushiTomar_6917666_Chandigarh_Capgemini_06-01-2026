using AutoMapper;
using UserApi.DTO;
using UserApi.Models;

namespace UserApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<RegisterDTO, User>();
        }
    }
}
