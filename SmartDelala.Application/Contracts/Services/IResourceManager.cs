using Microsoft.AspNetCore.Http;

namespace SmartDelala.Application.Contracts.Services;

public interface IResourceManager
{
    public Task<Uri> UploadImage(IFormFile image);
}
