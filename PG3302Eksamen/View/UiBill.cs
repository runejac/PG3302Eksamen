using PG3302Eksamen.Model;

namespace PG3302Eksamen.View;

public class UiBill {
    private IEnumerable<Bill> _bills;
    private readonly List<string> _billOptions = new();
    private Bill _bill;
    
    public void SelectBillToPay(string billToPayAccountNumber) {
        _bill = _bills.Single(bill => bill.AccountNumber == billToPayAccountNumber);
    }
    
    public IEnumerable<Bill> UnpaidBills(IEnumerable<Bill> unpaidBills) {
       return _bills = unpaidBills.Where(bill => bill.Status == BillStatusEnum.Notpaid);
    }
}