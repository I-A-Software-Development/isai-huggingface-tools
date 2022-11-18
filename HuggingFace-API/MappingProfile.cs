using AutoMapper;
using Entities.DTOs;
using Entities.Models;
using System.Linq;

namespace AccountOwnerServer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TextDescription, TextDescriptionDto>();

            CreateMap<GeneratedImage, GeneratedImageDto>();
        }
    }
}