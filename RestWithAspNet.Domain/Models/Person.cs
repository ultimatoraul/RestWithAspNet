namespace RestWithAspNet.Domain.Models
{
    public class Person(string firstName, string lastName, string address, string gender, DateTime birthDate)
    {
        public long Id { get; set; }
        public string FirstName { get; init; } = firstName;
        public string LastName { get; init; } = lastName;
        public string Address { get; init; } = address;
        public string Gender { get; init; } = gender;
        public DateTime BirthDate { get; init; } = birthDate;
    }
}
