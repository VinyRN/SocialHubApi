using AutoMapper;
using SocialHub.Domain.DTOs.Request;
using SocialHub.Domain.DTOs.Response;
using SocialHub.Domain.Entities;

namespace SocialHub.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Post, PostRequestDTO>();
            CreateMap<Post, PostResponseDTO>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Username)); 
        }

    }
}
