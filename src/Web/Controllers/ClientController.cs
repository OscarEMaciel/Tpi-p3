using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientController : ControllerBase
	{
		private readonly IClientService _clientService;
		public ClientController(IClientService clientService)
		{
			_clientService = clientService;
		}
		[HttpGet("[action]")]
		public IActionResult GetAllClients() 
		{
			return Ok(_clientService.GetClients());
		}
        [HttpGet("[action]/{id}")]
		public IActionResult GetClientById(int id) 
		{
            return Ok(_clientService.GetClientById(id));
        }
        [HttpPost("[action]")]
        public IActionResult AddClient(Client client)
		{
			_clientService.AddClient(client);
			return Ok();
		}
		[HttpPut("[action]/{id}")]
        public IActionResult UpdateClient(int id, [FromBody] Client client)
		{
            _clientService.UpdateClient(id, client);
            return Ok();
        }
        [HttpDelete]
		public IActionResult DeleteClient(int id)
		{
			_clientService.DeleteClients(id);
			return Ok(); 
		}
    }
}