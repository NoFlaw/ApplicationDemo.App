using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationDemo.Mvc.Models;
using ApplicationDemo.Mvc.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApplicationDemo.Mvc.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<ContactController> _logger;        
        private readonly IContactService _contactService;
  
        public ContactController(ILogger<ContactController> logger, IContactService contactService, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _contactService = contactService;
        }

        public async Task<ActionResult<IEnumerable<ContactViewModel>>> Index()
        {
            try
            {
                _logger.LogInformation("Mvc Contact Controller: Get() - Invoked");

                const string url = "api/contact/";

                var contactDtos = await _contactService.GetContactsAsync(url);
                var contacts = _mapper.Map<IEnumerable<ContactViewModel>>(contactDtos);

                return View(contacts);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Mvc Contact Controller: Get() - Error Captured");
                return View(null);
            }
        }     
    }
}
