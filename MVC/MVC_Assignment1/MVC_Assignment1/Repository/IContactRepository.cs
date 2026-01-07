using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVC_Assignment1.Models;


namespace MVC_Assignment1.Repository
{
    public interface IContactRepository
    {
            Task<List<Contact>> GetAllAsync();
            Task CreateAsync(Contact contact);
            Task DeleteAsync(long id);
        
    }
}

