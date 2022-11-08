using PG3302Eksamen.Controller;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.View;

public class UiBill {
    private readonly List<string> _billOptions = new();
    private readonly TransferController _transferController = new();
    private Bill _bill;
    private readonly BillController _billController = new();
    private IEnumerable<Bill> _bills;

    public void SelectBillToPay(string billToPayAccountNumber) {
        //_bill = _bills.Single(bill => bill.AccountNumber == billToPayAccountNumber);
    }

    public IEnumerable<Bill> UnpaidBills(IEnumerable<Bill> unpaidBills) {
        return _bills = unpaidBills.Where(bill => bill.Status == BillStatusEnum.Notpaid);
    }


    public void Calculate(Account selectedFromAccount, Bill selectedBill) {
        _billController.ExecuteBillPayment(selectedFromAccount, selectedBill);
    }
}