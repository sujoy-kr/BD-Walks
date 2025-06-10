using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTO.WalkDtos
{
    public class UpdateWalkRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be atleast 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(10, ErrorMessage = "Description must be atleast 10 characters long.")]
        [MaxLength(1000, ErrorMessage = "Description must not exceed 1000 characters.")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Range(0, 50)]
        public double LengthInKm { get; set; }
        public string? WalkImageUrl { get; set; } = string.Empty;

        [Required]
        public Guid DifficultyId { get; set; }

        [Required]
        public Guid RegionId { get; set; }
    }
}
