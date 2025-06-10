﻿using BDWalks.API.Models.DTO.DifficultyDtos;
using BDWalks.API.Models.DTO.RegionDtos;

namespace BDWalks.API.Models.DTO.WalkDtos
{
    public class WalkDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; }

        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
