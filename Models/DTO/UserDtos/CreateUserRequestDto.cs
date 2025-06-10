using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTO.UserDtos
{
    public class CreateUserRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public required string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
        public bool IsWrter { get; set; }
    }
}
