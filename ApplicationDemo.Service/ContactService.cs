using ApplicationDemo.Data.Models;
using ApplicationDemo.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDemo.Service
{
    public class ContactService : Repository<Contact>, IContactService
    {
        public ContactService(AppDemoContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Contact>> Get()
        {
            return await GetAllAsync();
        }
    }
}
