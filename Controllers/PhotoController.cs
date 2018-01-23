using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NextSugarCat.Core;
using NextSugarCat.Core.Models;
using System.IO;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers
{
    [Route("/api/menu/{itemId}/photos/")]
    public class PhotoController : Controller
    {
        private readonly IPhotoRepository photoRepository;
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IHostingEnvironment host;

        public PhotoController(
            IPhotoRepository photoRepository,
            IMenuRepository menuRepository,
            IUnitOfWork unitOfWork,
            IHostingEnvironment host
            )
        {
            this.photoRepository = photoRepository;
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
            this.host = host;
        }

        [HttpGet]
        public async Task<IActionResult> GetPhotos(int itemId)
        {
            var photos = await photoRepository.GetPhotosAsync(itemId);

            if (photos == null)
            {
                return NotFound("No photos in db");
            }

            return Ok(photos);
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UploadPhoto(int itemId, IFormFile file)
        {
            var menuItem = await menuRepository.GetMenuItem(itemId);
            if (menuItem == null)
                return NotFound();
            if (file == null)
                return BadRequest("Null file");

            if (file.Length == 0 || file.Length > 5 * 1024 * 1024) return BadRequest("File is too big");

            
            var photo = await photoRepository.UploadPhotoAsync(file);
            photo.MenuItemId = itemId;

            menuItem.Photos.Add(photo);
            await unitOfWork.SaveChangesAsync();

            return Ok(photo);
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{photoId}")]
        public async Task<IActionResult> DeletePhoto(int itemId, int photoId)
        {
            var menuItem = await menuRepository.GetMenuItem(itemId);
            if (menuItem == null)
                return NotFound();
            var uploadsFolderPath = Path.Combine(host.WebRootPath, "uploads");
            var photo = await photoRepository.GetPhotoAsync(itemId, photoId);
            if (photo == null)
                return NotFound();
            var filePath = Path.Combine(uploadsFolderPath, photo.FileName);
            if (System.IO.File.Exists(filePath))
            {
                photoRepository.DeletePhoto(photo);
                await unitOfWork.SaveChangesAsync();
            }
            else
                return BadRequest();
            return Ok(filePath + " Deleted");
        }
    }
}
