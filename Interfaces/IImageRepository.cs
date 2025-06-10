using BDWalks.API.Models.Domain;

namespace BDWalks.API.Interfaces
{
    public interface IImageRepository
    {
        Task<Image> UploadAsync(Image image);
    }
}
