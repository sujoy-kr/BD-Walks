using BDWalks.API.Interfaces;
using BDWalks.API.Models.DTO.UserDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] CreateUserRequestDto createUserRequestDto)
        {
            IdentityUser identityUser = new IdentityUser
            {
                Email = createUserRequestDto.Email,
                UserName = createUserRequestDto.Email
            };

            IdentityResult identityResult = await userManager.CreateAsync(identityUser, createUserRequestDto.Password);

            if (identityResult.Succeeded)
            {
                if (createUserRequestDto.IsWrter)
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, ["Reader", "Writer"]);
                }
                else
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, ["Reader"]);
                }

                if (identityResult.Succeeded)
                {
                    return Ok("User registered! Please login.");
                }
            }

            return BadRequest("Something went wrong.");
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserRequestDto loginUserRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginUserRequestDto.Username);

            if (user != null)
            {
                var checkPassword = await userManager.CheckPasswordAsync(user, loginUserRequestDto.Password);
                if (checkPassword)
                {
                    IList<string> roles = await userManager.GetRolesAsync(user);

                    if (roles != null)
                    {
                        var token = tokenRepository.GetJWTToken(user, roles.ToList());

                        LoginUserResponseDto loginUserResponseDto = new LoginUserResponseDto { JwtToken = token };

                        return Ok(loginUserResponseDto);
                    }
                }
            }
            return BadRequest("Wrong credentials.");
        }
    }
}
