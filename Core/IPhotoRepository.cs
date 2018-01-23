using Microsoft.AspNetCore.Http;
using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextSugarCat.Core
{
    public interface IPhotoRepository
    {
        Task<IEnumerable<Photo>> GetPhotosAsync(int id);
        Task<Photo> UploadPhotoAsync(IFormFile file);
        Task<Photo> GetPhotoAsync(int itemId, int photoId);
        void DeletePhoto(Photo photo);
    }
}
