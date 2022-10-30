using A_Team.Core.Model.AccountModel;

namespace A_Team.Core.Model;

public class Bill {
    public int Id { get; set; }
    public DateTime DueDate { get; set; }
    public string AccountNumber { get; set; }

    public decimal Payment { get; set; }
    public string Recipient { get; set; }
    public string MessageField { get; set; }
    public BillStatusEnum Status { get; set; }


    public Bill CreateBill(Account accountNumber, Account recipient, string messageField, decimal payment,
        BillStatusEnum status, DateTime dueDate) {
        return new Bill {
            AccountNumber = accountNumber.AccountNumber,
            Recipient = recipient.AccountNumber,
            MessageField = messageField,
            Payment = payment,
            Status = status,
            DueDate = dueDate
        };
    }
}