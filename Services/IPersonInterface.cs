using System.Collections.Generic;
using System.Threading.Tasks;
using EFDemo.Models;

namespace EFDemo.Services
{
    public interface IPersonInterface
    {
        Task<List<Person>> GetAllPeopleAsync();
        Task<Person> GetPersonByIdAsync(int id);
        Task CreatePersonAsync(Person person);
        Task UpdatePersonAsync(Person person);
        Task DeletePersonAsync(int id);
    }
}
