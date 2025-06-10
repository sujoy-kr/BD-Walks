using AutoMapper;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO.DifficultyDtos;
using BDWalks.API.Models.DTO.RegionDtos;
using BDWalks.API.Models.DTO.WalkDtos;

namespace BDWalks.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // Region mappings
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<Region, CreateRegionRequestDto>().ReverseMap();
            CreateMap<Region, UpdateRegionRequestDto>().ReverseMap();

            // Walk mappings
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Walk, CreateWalkRequestDto>().ReverseMap();
            CreateMap<Walk, CreateWalkResponseDto>().ReverseMap();
            CreateMap<Walk, UpdateWalkRequestDto>().ReverseMap();
            CreateMap<Walk, UpdateWalkResponseDto>().ReverseMap();

            // Difficulty mapping
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
        }
    }
}
