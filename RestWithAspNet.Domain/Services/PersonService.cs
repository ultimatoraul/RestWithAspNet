using RestWithAspNet.Domain.Interfaces;
using RestWithAspNet.Domain.Models;
using System.Xml.Linq;

namespace RestWithAspNet.Domain.Services
{
    public class PersonService : IPersonService
    {
        public Person Create(Person person)
        {
            Person newPerson = person;
            newPerson.Id = new Random().Next(1, 10000);

            return newPerson;
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }

        public List<Person> FindAll()
        {
            List<Person> people = [MockPerson(1), MockPerson(2), MockPerson(3), MockPerson(4)];

            return people;
        }

        public Person FindById(long id)
        {
            return MockPerson(id);
        }

        public List<Person> FindByName(string name)
        {
            List<Person> people = [MockPerson(1), MockPerson(2), MockPerson(3), MockPerson(4)];
            List<Person> peopleByName = [.. people.Where(p => 
                string.Equals(p.FirstName, name, StringComparison.OrdinalIgnoreCase) ||
                string.Equals(p.LastName, name, StringComparison.OrdinalIgnoreCase) ||
                string.Equals($"{p.FirstName} {p.LastName}", name, StringComparison.OrdinalIgnoreCase)
                )];

            return peopleByName;
        }

        public Person Update(Person person)
        {
            return person;
        }

        private static Person MockPerson(long key)
        {
            return key switch
            {
                1 => new Person("John", "Doe", "123 Main", "Male", new DateTime(1990, 1, 1)) { Id = 1 },
                2 => new Person("Carlos", "Rez", "123 Main", "Male", new DateTime(1988, 3, 12)) { Id = 2 },
                3 => new Person("Alicia", "Mao", "123 Main", "Female", new DateTime(1993, 10, 1)) { Id = 3 },
                4 => new Person("Mao", "Fei", "123 Main", "Female", new DateTime(1998, 10, 1)) { Id = 4 },
                5 => new Person("Max", "Oliver", "123 Main", "Male", new DateTime(1997, 8, 1)) { Id = 5 },
                //4 => new Person("Max", "Oliver", "123 Main", "Male", new DateTime(1997, 8, 1)) { Id = new Random().Next(1, 10000) },
                _ => null,
            };
        }
    }
}
