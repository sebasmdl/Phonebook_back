using phonebook_back.Data;
using phonebook_back.Data.EFCore;
using phonebook_back.Models;

namespace phonebook_back.Repositories
{
    public class ContactRepository : EfCoreRepository<Contact, DatabaseContext>
    {
        public ContactRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
