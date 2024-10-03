using Pizzeria.Application.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Pizzeria.Core.Options;
using Microsoft.Extensions.Options;

namespace Pizzeria.Application.Services
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;
        private readonly CloudinaryOptions cloudinaryOptions;

        public CloudinaryService(IOptions<CloudinaryOptions> cloudinaryOptions)
        {
            this.cloudinaryOptions = cloudinaryOptions.Value;
            var account = new Account(this.cloudinaryOptions.CloudName, this.cloudinaryOptions.ApiKey, this.cloudinaryOptions.ApiSecret);
            _cloudinary = new Cloudinary(account);
        }

        public async Task<ImageUploadResult> UploadAsync(IFormFile photoStream)
        {
            using var memoryStream = new MemoryStream();
            await photoStream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var fileName = Guid.NewGuid().ToString();

            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, memoryStream),
                PublicId = fileName,
                Overwrite = true
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);
            return uploadResult;
        }
    }
}
