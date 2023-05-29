using EFDemo.Data;
using EFDemo.Interfaces;
using EFDemo.Models;

namespace EFDemo.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Person> GetActivePeople()
        {
            return _context.Person;
        }
    }
}
