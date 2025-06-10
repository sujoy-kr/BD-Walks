using BDWalks.API.Models.DTO.ImageDtos;

namespace BDWalks.API.Validators
{
    public static class ImageUploadValidator
    {
        public static Dictionary<string, string> Validate(UploadImageRequestDto dto)
        {
            var errors = new Dictionary<string, string>();
            var allowedExtensions = new[] { ".jpg", ".png", ".jpeg", ".webp" };

            var extension = Path.GetExtension(dto.File.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
            {
                errors["File"] = "Format not supported.";
            }

            if (dto.File.Length > 10 * 1024 * 1024)
            {
                errors["File"] = "File exceeded max size limit (10MB).";
            }

            return errors;
        }
    }
}
