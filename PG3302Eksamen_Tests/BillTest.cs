using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests; 

public class BillTest {

    private bool _disposedValue; // To detect redundant calls

    private BankContext _context = new();

	
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

    [Test]
    public void UpdateBillStatusTest() {
        Bill bill = new();
        Person person = new();
        SavingsAccountFactory save = new();
        var billService = new BillRepository(_context);
        var personService = new PersonRepository(_context);
        var transaction = new TransactionRepository(_context);
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

        var olaAccount = save.InitializeAccount("konto1", createdPerson.Id, "1123123123");

        var createdBill = bill.CreateBill(
            olaAccount.AccountNumber,
            "Hola",
            "Pay now or die",
            3000,
            BillStatusEnum.Notpaid,
            DateTime.Now,
            1);
        
       
        
        billService.UpdateBillStatus(createdPerson.Id, createdBill.Status = BillStatusEnum.Notpaid);
        
      
        
    }
}