using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminController : ControllerBase
	{
		private readonly IAdminService _clientService;
		public AdminController(IAdminService clientService)
		{
			_clientService = clientService;
		}
		[HttpGet("[action]")]
		public IActionResult GetAllAdmins() 
		{
			return Ok(_clientService.GetAdmins());
		}
        [HttpGet("[action]/{id}")]
		public IActionResult GetAdminById(int id) 
		{
            return Ok(_clientService.GetAdminById(id));
        }
        [HttpPost("[action]")]
        public IActionResult AddAdmin(Admin client)
		{
			_clientService.AddAdmin(client);
			return Ok();
		}
		[HttpPut("[action]/{id}")]
        public IActionResult UpdateAdmin(int id, [FromBody] Admin client)
		{
            _clientService.UpdateAdmin(id, client);
            return Ok();
        }
        [HttpDelete]
		public IActionResult DeleteAdmin(int id)
		{
			_clientService.DeleteAdmin(id);
			return Ok(); 
		}
    }
}