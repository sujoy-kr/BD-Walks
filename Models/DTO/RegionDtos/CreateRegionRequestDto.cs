using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTO.RegionDtos
{
    public class CreateRegionRequestDto
    {
        [Required]
        [MinLength(3, ErrorMessage = "Code must be atleast 3 characters long.")]
        [MaxLength(3, ErrorMessage = "Code must not exceed 3 characters.")]
        public string Code { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Name must be atleast 3 characters long.")]
        [MaxLength(100, ErrorMessage = "Name must not exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
        public string? RegionImageUrl { get; set; }
    }
}
