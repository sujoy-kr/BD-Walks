using System.ComponentModel.DataAnnotations;

namespace BDWalks.API.Models.DTO.UserDtos
{
    public class LoginUserRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public required string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}