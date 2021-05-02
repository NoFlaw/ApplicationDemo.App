using ApplicationDemo.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationDemo.Mvc.Services
{
    public interface IContactService
    {
        void Dispose();
        Task<IEnumerable<Contact>> GetContactsAsync(string url);
    }
}