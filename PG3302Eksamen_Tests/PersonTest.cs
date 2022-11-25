using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests;

public class PersonTest {
    private BankContext _context = new();

    private bool _disposedValue; // To detect redundant calls


    [SetUp]
    public void CreateContextForInMemory() {
        var option = new DbContextOptionsBuilder<BankContext>().UseInMemoryDatabase("test_db").Options;
        _context = new BankContext(option);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
    }
    protected virtual void Dispose(bool disposing) {
        if (!_disposedValue) {
            if (disposing) {
            }

            _disposedValue = true;
        }
    }
    public void Dispose() {
        Dispose(true);
    }

    // a test that simulates that retrieves your name based on social security number
    [Test]
    public void GetBySocialSecNumberTest() {
        Person person = new();
        var personService = new PersonRepository(_context);
        var createdPerson = person.CreatePerson(
            "Elaveien 5",
            "Ola",
            "Normann",
            "123",
            "33445566",
            "04048944598",
            "olanormann@noreg.no"
        );
        personService.Insert(createdPerson);

        var findNameBySocialSecNumber = personService.GetBySocialSecNumber(createdPerson.SocialSecurityNumber);

        Assert.That(findNameBySocialSecNumber.FirstName, Is.EqualTo("Ola"));
    }

    // a test that simulates a creating of a person object
    [Test]
    public void CreatePersonTest() {
        Person person = new();
        var personService = new PersonRepository(_context);
        personService.Insert(person.CreatePerson(
            "Elaveien 5",
            "Ola",
            "Normann",
            "123",
            "33445566",
            "04048944598",
            "olanormann@noreg.no"
        ));

        Assert.That(personService.GetById(1).Id, Is.EqualTo(1));
    }

    // a test that simulates a deleting of person object
    [Test]
    public void DeletePersonTest() {
        var personService = new PersonRepository(_context);
        Person person = new();
        var createdPerson = person.CreatePerson(
            "Elaveien 5",
            "Ola",
            "Normann",
            "123",
            "33445566",
            "04048944598",
            "olanormann@noreg.no"
        );

        personService.Insert(createdPerson);
        personService.Remove(createdPerson);


        Assert.That(personService.GetAll().ToList().Count(), Is.EqualTo(0));
    }
    
    // a test that simulates updates on person object address
    [Test]
    public void UpdatePersonAdressTest() {
        Person person = new();
        var personService = new PersonRepository(_context);
        var createdPerson = person.CreatePerson(
            "Elaveien 3",
            "Ola",
            "Normann",
            "123",
            "33445566",
            "04048944598",
            "olanormann@noreg.no"
        );

        personService.Insert(createdPerson);

        personService.UpdateAddress(1, "Elaveien 6");
        var expectedPersonAdress = personService.GetById(1).Address;

        Assert.That(expectedPersonAdress, Is.EqualTo("Elaveien 6"));
    }
    
    // a test that simulates changing password in a person object
    [Test]
    public void ChangePersonPasswordTest() {
        Person person = new();
        var personService = new PersonRepository(_context);
        var createdPerson = person.CreatePerson(
            "Elaveien 3",
            "Ola",
            "Normann",
            "123",
            "33445566",
            "04048944598",
            "olanormann@noreg.no"
        );

        personService.Insert(createdPerson);

        personService.ChangePassword(1, "1337");
        var expectedNewPassword = personService.GetById(1).Password;

        Assert.That(expectedNewPassword, Is.EqualTo("1337"));
    }
    
   
}