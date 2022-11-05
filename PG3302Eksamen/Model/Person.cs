namespace PG3302Eksamen.Model;

public class Person {
    public DateTime RegisterAt = DateTime.Now;

    public int Id { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Password { get; set; }
    public string PhoneNumber { get; set; }
    public string SocialSecurityNumber { get; set; }


    // TODO skal addes inn i DB vei
    //public List<Account> Accounts { get; set; } = new();


    public Person CreatePerson(string address, string firstName, string lastName,
        string password,
        string phoneNumber,
        string socialSecurityNumber, string email) {
        return new Person {
            Address = address,
            FirstName = firstName,
            LastName = lastName,
            Password = password,
            Email = email,
            PhoneNumber = phoneNumber,
            SocialSecurityNumber = socialSecurityNumber
        };
    }
}