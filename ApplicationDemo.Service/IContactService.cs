using ApplicationDemo.Data.Models;
using ApplicationDemo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDemo.Service
{
    public interface IContactService : IRepository<Contact>
    {
        Task<IEnumerable<Contact>> Get();
    }
}
