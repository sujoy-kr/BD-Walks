using BDWalks.API.Interfaces;
using BDWalks.API.Models.Domain;
using BDWalks.API.Models.DTO.ImageDtos;
using BDWalks.API.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BDWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Writer")]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload(UploadImageRequestDto uploadImageRequestDto)
        {
            var validationErrors = ImageUploadValidator.Validate(uploadImageRequestDto);

            foreach (var error in validationErrors)
            {
                ModelState.AddModelError(error.Key, error.Value);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Image imageModel = new Image
            {
                File = uploadImageRequestDto.File,
                FileExtension = Path.GetExtension(uploadImageRequestDto.File.FileName),
                FileSizeInBytes = uploadImageRequestDto.File.Length,
                FileName = uploadImageRequestDto.FileName,
                FileDescription = uploadImageRequestDto.FileDescription
            };

            await imageRepository.UploadAsync(imageModel);

            return Ok(imageModel);
        }
    }
}
