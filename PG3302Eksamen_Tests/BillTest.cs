using Microsoft.EntityFrameworkCore;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen_Tests;

public class BillTest {
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

    [Test]
    public void UpdateBillStatusTest() {
        Bill bill = new();
        Person person = new();
        SavingsAccountFactory save = new();
        var billService = new BillRepository(_context);

        var createdBill = bill.CreateBill(
           "12345678901",
            "Hola",
            "Pay now or die",
            3000,
            BillStatusEnum.Notpaid,
            DateTime.Now,
            1);
       
        
       billService.Insert(createdBill);
       billService.UpdateBillStatus(createdBill.OwnerId, BillStatusEnum.Paid);
      
       Assert.That(createdBill.Status, Is.EqualTo(BillStatusEnum.Paid));
        
    }

    [Test]
    public void BillSortedByOwnerIdTest() {
        Bill bill = new();
        var billService = new BillRepository(_context);

        var createdBill1 = bill.CreateBill(
            "12345678912",
            "Trude Drevland",
            "Frist 28 november",
            100,
            BillStatusEnum.Notpaid,
            DateTime.Now, 
            3);
        
        var createdBill2 = bill.CreateBill(
            "12345678911",
            "Hermann Friele",
            "For middag",
            4000,
            BillStatusEnum.Paid,
            DateTime.Now, 
            1);
        
        var createdBill3 = bill.CreateBill(
            "12345678913",
            "Patti Snitt",
            "Happy birthday",
            200,
            BillStatusEnum.Paid,
            DateTime.Now, 
            3);
        
        billService.Insert(createdBill1);
        billService.Insert(createdBill2);
        billService.Insert(createdBill3);

       
        
        Assert.That(billService.GetSortedByOwner(3), Is.EqualTo(3));
    }
}