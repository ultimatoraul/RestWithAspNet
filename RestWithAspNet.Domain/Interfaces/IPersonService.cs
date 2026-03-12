using RestWithAspNet.Domain.Models;

namespace RestWithAspNet.Domain.Interfaces
{
    public interface IPersonService
    {
        Person Create (Person person);
        Person FindById(long id);
        List<Person> FindByName(string name);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
