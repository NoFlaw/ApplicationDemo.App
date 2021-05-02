using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationDemo.Data.Models;
using ApplicationDemo.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApplicationDemo.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<ContactController> _logger;

        public ContactController(ILogger<ContactController> logger, IContactService contactService)
        {
            _logger = logger;
            _contactService = contactService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Contact>>> Get()
        {
            try
            {
                _logger.LogInformation("WebApi Contact Controller: Get() - Invoked");

                var contacts = await _contactService.Get();

                if (contacts == null)
                {
                    return NotFound();
                }

                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "WebApi Contact Controller: Get() - Error Captured");
                return BadRequest(ex);
            }
        }
    }
}
