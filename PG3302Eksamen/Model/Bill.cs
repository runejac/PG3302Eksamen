using PG3302Eksamen.Model.AccountModel;

namespace PG3302Eksamen.Model;

public class Bill {
    public int Id { get; set; }
    public DateTime DueDate { get; set; }
    public decimal Amount { get; set; }
    public string Recipient { get; set; }
    public string MessageField { get; set; }
    public BillStatusEnum Status { get; set; }

    public int OwnerId { get; set; }
    public int ToAccount { get; set; }


    public Bill CreateBill(Account toAccount, string recipient, string messageField,
        decimal amount,
        BillStatusEnum status, DateTime dueDate, int ownerId) {
        return new Bill {
            ToAccount = toAccount.Id,
            Recipient = recipient,
            MessageField = messageField,
            Amount = amount,
            Status = status,
            DueDate = dueDate,
            OwnerId = ownerId
        };
    }
}