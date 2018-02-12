using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NextSugarCat.Controllers.Resources;
using NextSugarCat.Core;
using NextSugarCat.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NextSugarCat.Controllers
{
    [Route("/api/client")]
    public class ClientController : Controller
    {
        private readonly IMapper mapper;
        private readonly IClientRepository clientRepository;
        private readonly IUnitOfWork unitOfWork;

        public ClientController(
            IMapper mapper,
            IClientRepository clientRepository,
            IUnitOfWork unitOfWork,
            UserManager<IdentityUser> userManager
            )
        {
            this.mapper = mapper;
            this.clientRepository = clientRepository;
            this.unitOfWork = unitOfWork;
        }
        
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInfo(string id)
        {
            var info = await clientRepository.GetClientAsync(id);

            if(info == null)
                return BadRequest("Not Found");
            
            var clientResource = mapper.Map<Client, ClientDTO>(info);

            return Ok(clientResource);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllClients()
        {
            var clients = await clientRepository.GetClientsAsync();

            if (clients == null)
                return NotFound("No clients in the Database");

            var clientsDto = mapper.Map<ICollection<Client>, List<ClientDTO>>(clients);

            return Ok(clientsDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfile(string id, [FromBody] ClientDTO clientResource)
        {
            var info = await clientRepository.GetClientAsync(id);

            if (info == null)
                return BadRequest("Not Found");

            mapper.Map(clientResource, info);

            await unitOfWork.SaveChangesAsync();

            return Ok(clientResource);
        }
    }
}
