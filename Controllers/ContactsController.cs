using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core.Models;
using NextSugarCat.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BakeryWebApi.Controllers
{
    [Route("/api/contacts")]
    public class ContactsController : Controller
    {
        private readonly BakeryDbContext context;
        private readonly IMapper mapper;

        public ContactsController(BakeryDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateContacts([FromBody] ContactsDTO contactsDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var contacts = await context.Contacts.SingleOrDefaultAsync(c => c.Id == 1);

            mapper.Map<ContactsDTO, Contacts>(contactsDTO, contacts);

            await context.SaveChangesAsync();

            return Ok(contactsDTO);
        }
    }
}
