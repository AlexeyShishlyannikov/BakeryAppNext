using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core;
using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers
{
    [Route("/api/menu")]
    public class MenuItemController : Controller
    {
        private readonly IMapper mapper;
        private readonly IPhotoRepository photoRepository;
        private readonly IMenuRepository menuRepository;
        private readonly IUnitOfWork unitOfWork;

        public MenuItemController(
            IMenuRepository menuRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IPhotoRepository photoRepository)
        {
            this.mapper = mapper;
            this.photoRepository = photoRepository;
            this.menuRepository = menuRepository;
            this.unitOfWork = unitOfWork;
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] MenuItemSaveDTO menuItemResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var menuItem = mapper.Map<MenuItemSaveDTO, MenuItem>(menuItemResource);

            await menuRepository.Add(menuItem);
            //await context.AddAsync(menuItem.Price);
            await unitOfWork.SaveChangesAsync();

            menuItem = await menuRepository.GetMenuItem(menuItem.Id);

            var result = mapper.Map<MenuItem, MenuItemDTO>(menuItem);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await menuRepository.GetMenuItem(id);

            if (item == null)
                return NotFound();

            return Ok(mapper.Map<MenuItem, MenuItemDTO>(item));
        }

        [HttpGet]
        public async Task<IActionResult> GetMenu()
        {
            var menu = await menuRepository.GetMenu();

            return Ok(mapper.Map<IEnumerable<MenuItem>, IEnumerable<MenuItemDTO>>(menu));
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            var item = await menuRepository.GetMenuItem(id);
            if (item == null)
                return NotFound();
            foreach(var p in item.Photos)
            {
                photoRepository.DeletePhoto(p);
            }
            menuRepository.Remove(item);
            await unitOfWork.SaveChangesAsync();
            return Ok(id + " DELETED");
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItem(int id, [FromBody] MenuItemSaveDTO saveResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = await menuRepository.GetMenuItem(id);
            if (item == null)
                return NotFound();
            mapper.Map(saveResource, item);

            await unitOfWork.SaveChangesAsync();

            item = await menuRepository.GetMenuItem(item.Id);
            var result = mapper.Map<MenuItem, MenuItemDTO>(item);

            return Ok(result);
        }
    }
}
