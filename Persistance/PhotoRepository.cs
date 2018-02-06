using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using NextSugarCat.Core;
using NextSugarCat.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace NextSugarCat.Persistance
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly BakeryDbContext context;
        private readonly IHostingEnvironment host;

        public PhotoRepository(BakeryDbContext context, IHostingEnvironment host)
        {
            this.context = context;
            this.host = host;
        }

        public void DeletePhoto(Photo photo)
        {
            context.Remove(photo);
        }

        public async Task<Photo> GetPhotoAsync(int itemId, int photoId)
        {
            return await context.Photos
                .Where(p => itemId == p.MenuItemId)
                .SingleOrDefaultAsync(p => p.Id == photoId);
        }

        public async Task<IEnumerable<Photo>> GetPhotosAsync(int id)
        {
            return await context.Photos
                .Where(p => id == p.MenuItemId)
                .ToArrayAsync();
        }

        // Storing pictures in DB

        public async Task<Photo> UploadPhotoAsync(IFormFile file)
        {
            MemoryStream ms = new MemoryStream();
            await file.OpenReadStream().CopyToAsync(ms);

            Photo photo = new Photo()
            {
                FileName = file.FileName,
                Data = ms.ToArray(),
                ContentType = file.ContentType,
                Length = file.Length
            };

            await context.Photos.AddAsync(photo);

            return photo;
        }




        // Storing pictures in wwwroot

        //public async Task<IEnumerable<Photo>> GetPhotos(int id)
        //{
        //    return await context.Photos
        //        .Where(p => p.MenuItemId == id)
        //        .ToListAsync();
        //}

        //public async Task<string> UploadPhotoAsync(IFormFile file)
        //{
        //    var uploadFolderPath = Path.Combine(host.WebRootPath, "uploads");
        //    if (!Directory.Exists(uploadFolderPath))
        //        Directory.CreateDirectory(uploadFolderPath);

        //    // FileName Hashing
        //    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
        //    var filePath = Path.Combine(uploadFolderPath, fileName);

        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }

        //    return fileName;
        //}

        //public async Task<Photo> GetPhoto(int itemId, int photoId)
        //{
        //    var photo = await context.Photos.Where(p => p.MenuItemId == itemId).SingleOrDefaultAsync(p => p.Id == photoId);
        //    return photo;
        //}
        //public void DeletePhoto(Photo photo)
        //{
        //    var uploadFolderPath = Path.Combine(host.WebRootPath, "uploads");
        //    var filePath = Path.Combine(uploadFolderPath, photo.FileName);

        //    System.IO.File.Delete(filePath);
        //    context.Remove(photo);
        //}
    }
}
