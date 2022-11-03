using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests;

public class UnitTest1 {
    private bool disposedValue; // To detect redundant calls

    private BankContext context;
    [SetUp]
    public void CreateContextForInMemory() {
        var option = new DbContextOptionsBuilder<BankContext>().UseInMemoryDatabase("test_db").Options;

        context = new BankContext(option);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
    }
    


    protected virtual void Dispose(bool disposing) {
        if (!disposedValue) {
            if (disposing) {
            }

            disposedValue = true;
        }
    }

    public void Dispose() {
        Dispose(true);
    }
    

    [Test]
    public void TestMethod() {
        Person person = new();
        var service = new PersonRepository(context);
        service.Insert(person.CreatePerson("uno", "dos", "tres", "lala", "lala", "122222222", "lol"));
        context.SaveChanges();
            
            
        Assert.That(context.Persons.Count(), Is.EqualTo(1));
        Assert.That(context.Persons.Single().Address, Is.EqualTo("uno"));
        
        
    }
    [Test]
    public void AddNewAccountTest() {
        SavingsAccountFactory saving = new();
        Person person = new();
        var personService = new PersonRepository(context);
        var accountService = new AccountRepository(context);
        personService.Insert(person.CreatePerson("uno", "dos", "tres", "lala", "lala", "122222222", "lol"));
        context.SaveChanges();
        
        personService.AddNewAccount(saving.InitializeAccount("Konto1", 1, "1337"));
        context.SaveChanges();
        Assert.That(accountService.GetById(1).OwnerId, Is.EqualTo(personService.GetById(1).Id));
       
    }
    
   
}