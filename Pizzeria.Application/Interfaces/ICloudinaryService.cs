using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace Pizzeria.Application.Interfaces
{
    public interface ICloudinaryService
    {
        Task<ImageUploadResult> UploadAsync(IFormFile photoStream);
    }
}
