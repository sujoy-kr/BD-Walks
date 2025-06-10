using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTO.ImageDtos
{
    public class UploadImageRequestDto
    {
        [Required]
        public required IFormFile File { get; set; }

        [Required]
        public required string FileName { get; set; }
        public string? FileDescription { get; set; }
    }
}
