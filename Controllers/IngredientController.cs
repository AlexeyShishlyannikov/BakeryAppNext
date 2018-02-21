using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core.Models;
using NextSugarCat.Persistance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers
{
    [Route("/api/ingredients")]
    public class IngredientController : Controller
    {
        private readonly IMapper mapper;
        private readonly BakeryDbContext context;
        public IngredientController(IMapper mapper, BakeryDbContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredient(int id)
        {
            var ingredients = await context.Ingredients.SingleOrDefaultAsync(ing => ing.Id == id);

            return Ok(mapper.Map<Ingredient, IngredientDTO>(ingredients));
        }

        [HttpGet]
        public async Task<IActionResult> GetIngredients()
        {
            var ingredients = await context.Ingredients.ToListAsync();

            return Ok(Mapper.Map<List<Ingredient>, List<IngredientDTO>>(ingredients));
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> PostIngredient([FromBody] IngredientDTO ingredientResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredient = mapper.Map<IngredientDTO, Ingredient>(ingredientResource);

            await context.AddAsync(ingredient);
            await context.SaveChangesAsync();
            ingredientResource.Id = ingredient.Id;
            return Ok(ingredientResource);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngredient(int id)
        {
            var ingredient = await context.Ingredients.SingleOrDefaultAsync(ing => ing.Id == id);

            if (ingredient == null)
                return NotFound();

            context.Remove(ingredient);
            await context.SaveChangesAsync();

            return Ok(id);
        }
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateIngredient(int id, [FromBody] IngredientDTO ingredientResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ingredient = await context.Ingredients.SingleOrDefaultAsync(i => i.Id == id);

            if (ingredient == null)
                return NotFound();

            mapper.Map(ingredientResource, ingredient);
            await context.SaveChangesAsync();
            ingredientResource.Id = id;

            return Ok(ingredientResource);
        }

    }
}
