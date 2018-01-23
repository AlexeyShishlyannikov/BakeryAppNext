using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core.Models;
using NextSugarCat.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers
{
    [Route("/api/faq")]
    public class FAQController : Controller
    {
        private readonly BakeryDbContext context;
        private readonly IMapper mapper;

        public FAQController(BakeryDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetQuestions()
        {
            var questions = await context.FAQ.ToListAsync();

            if (questions == null)
                return NotFound("No questions found");

            var result = mapper.Map<List<FAQ>, List<FAQDTO>>(questions);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var question = await context.FAQ.SingleOrDefaultAsync(q => q.Id == id);

            if (question == null)
                return NotFound("No questions found");

            context.FAQ.Remove(question);

            await context.SaveChangesAsync();

            return Ok(id + "DELETED");
        }

        [HttpPost]
        public async Task<IActionResult> PostQuestion([FromBody] FAQDTO question)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = mapper.Map<FAQDTO,FAQ>(question);

            await context.FAQ.AddAsync(result);
            await context.SaveChangesAsync();

            question.Id = result.Id;

            return Ok(question);
        }
    }
}
