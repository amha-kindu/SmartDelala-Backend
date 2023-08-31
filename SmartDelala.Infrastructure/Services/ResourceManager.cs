using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using SmartDelala.Application.Contracts.Services;

namespace SmartDelala.Infrastructure.Services;

public class ResourceManager : IResourceManager
{
    private readonly Cloudinary _cloudinary;

    public ResourceManager(Cloudinary cloudinary)
    {
        _cloudinary = cloudinary;
    }

    public async Task<Uri> UploadImage(IFormFile image)
        {
            var uploadParams = new RawUploadParams()
            {
                File = new FileDescription(image.FileName, image.OpenReadStream()),
            };
            var uploadResult = await _cloudinary.UploadLargeAsync(uploadParams);
            return uploadResult.Url;
        }
}
