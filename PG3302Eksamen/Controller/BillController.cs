using PG3302Eksamen.Model;
using PG3302Eksamen.Repositories;
using PG3302Eksamen.Utils;

namespace PG3302Eksamen.Controller;

public class BillController {
    private readonly AccountController _ac = new();
    private readonly AccountRepository _accountRepository = new(new BankContext());
    private readonly Bill _bill = new();
    private readonly BillRepository _billRepository = new(new BankContext());
    private readonly BankContext _context = new();
    private readonly Person _person = new();
    private List<string> _billRecipients;

    public Person GetPerson() {
        return _person;
    }

    public List<Bill> GetAllBills() {
        return _billRepository.GetSortedByOwner(GetPerson().Id).ToList();
    }

    private void AddBillRecipients() {
        _billRecipients = new List<string> {
            "Rent to Jack Sparrow",
            "PayPal",
            "Amazon.com",
            "Netflix AS",
            "Foodora AS",
            "Electricity AS",
            "Spotify account",
            "Kondomeriet AS",
            "Mamma"
        };
    }

    private string UseRandomRecipient() {
        AddBillRecipients();
        var random = new Random();
        var i = 0;
        var next = random.Next(_billRecipients.Count);
        Console.WriteLine(next);

        foreach (var recipient in _billRecipients) {
            if (i == next) {
                return recipient;
            }

            i++;
        }

        return "";
    }

    private static string GenerateRandomKidNumber() {
        var random = new Random();
        var numbers = random.NextInt64(0000000000, 9999999999);
        var accountNumberGenerated = numbers.ToString();

        // make an KID number / message
        return "7777" + accountNumberGenerated;
    }


    public Bill GenerateBills(Person? person) {
        return _bill.CreateBill(_ac.GenerateBankAccountNumber(),
            UseRandomRecipient(),
            GenerateRandomKidNumber(),
            AmountGeneratorUtil.GenerateAmount(50, 700),
            BillStatusEnum.Notpaid,
            DateTime.Today.AddDays(14),
            person.Id);
    }
}