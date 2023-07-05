using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using phonebook_back.Models;
using phonebook_back.Repositories;

namespace phonebook_back.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactsController : BaseController<Contact, ContactRepository>
    {
        public ContactsController(ContactRepository repository) : base(repository)
        {

        }
    }
}
