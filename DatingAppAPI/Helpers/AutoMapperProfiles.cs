using System.Linq;
using AutoMapper;
using DatingAppAPI.DTO;
using DatingAppAPI.Models;

namespace DatingAppAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForListDto>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).URL))

                .ForMember(dest => dest.Age, 
                    opt => opt.MapFrom(src => src.DateofBirth.CalculateAge()));
            CreateMap<User,UserForDetailedDto>()
                .ForMember(dest => dest.PhotoUrl, opt => 
                    opt.MapFrom( src => src.Photos.FirstOrDefault(predicate=>predicate.IsMain).URL))

                .ForMember(dest => dest.Age, 
                    opt => opt.MapFrom(src => src.DateofBirth.CalculateAge()));
            CreateMap<Photo, PhotosForDetailedDto>();
        }
    }
}