namespace PG3302Eksamen.Model;

public class Person {
    public Person(string address, string firstName, string lastName, string password, string phoneNumber,
        string socialSecurityNumber, DateTime registerAt) {
        Address = address;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        PhoneNumber = phoneNumber;
        SocialSecurityNumber = socialSecurityNumber;
        RegisterAt = registerAt;
    }

    public int Id { get; set; }
    public string Address { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string SocialSecurityNumber { get; set; }

    public DateTime RegisterAt { get; set; }
}