using PG3302Eksamen.Model;
using PG3302Eksamen.Repositories;

namespace PG3302Eksamen.Controller; 

public class BillController {
    private readonly BankContext _context = new();
    private readonly BillRepository _billRepository = new(new BankContext());
    
    private Person _person = new();

    public Person GetPerson() {
        return _person;
    }

    public List<Bill> GetAllBills() {
        return _billRepository.GetSortedByOwner(GetPerson().Id).ToList();
    }

}