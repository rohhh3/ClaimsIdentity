using EFDemo.Models;

namespace EFDemo.Interfaces
{
    public interface IPersonRepository
    {
        IQueryable<Person> GetActivePeople();
    }
}
