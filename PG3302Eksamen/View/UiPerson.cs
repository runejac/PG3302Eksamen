using PG3302Eksamen.Controller;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;
using Spectre.Console;
using static BCrypt.Net.BCrypt;

namespace PG3302Eksamen.View;

public class UiPerson {
    private readonly PersonController _personController = new();

    public Person GetPerson() {
        return _personController.GetPerson();
    }

    public IEnumerable<Account> GetAllAccounts() {
        return _personController.GetAllAccounts();
    }

    public IEnumerable<Bill> GetAllBills(Person person) {
        return _personController.GetAllBills(person);
    }


    public Person LogIn() {
        var ssnEntered = PromptUtil.PromptQuestion("Enter your social security number: ",
            "Invalid social security number entered.");
        var passwordEntered = PromptUtil.PromptPassword("Enter your password: ");

        var person = _personController.Authenticate(ssnEntered, passwordEntered);

        if (person != null) {
            _personController.BillGenerator();
            return person;
        }

        PromptUtil.PromptAssertion("Invalid user details", "red");

        return null;
    }

    public void CreatePerson() {
        var socialSecNrChecker = true;
        var passwordChecker = true;


		var address =
			PromptUtil.PromptQuestion("Address: ", "Invalid address entered");
		var firstName =
			PromptUtil.PromptQuestion("First name: ", "Invalid first name entered");
		var lastName =
			PromptUtil.PromptQuestion("Last name: ", "Invalid last name entered");
		var phoneNumber =
			PromptUtil.PromptPhoneNr("Phone number: ", "Invalid phone number entered (need 8 digits)");
		var email = PromptUtil.PromptEmail("Email: ", "Invalid email entered (need @)");

        var password = "";
        var hashedPassword = "";

        while (passwordChecker) {
            password = PromptUtil.PromptPassword("Password: ");
            var confirmPassword = PromptUtil.PromptPassword("Confirm password: ");


            if (password != confirmPassword) {
                PromptUtil.PromptAssertion("Passwords did not match, try again.", "red");
            }
            else {
                hashedPassword = HashPassword(password);
                passwordChecker = false;
            }
        }


        while (socialSecNrChecker) {
            var socialSecurityNumber =
                PromptUtil.PromptQuestion("Enter social security number: ",
                    "Invalid social security number entered");
            _personController.CreatePerson(address, firstName, lastName,
                hashedPassword,
                phoneNumber, socialSecurityNumber,
                email);
            if (_personController.ValidateSocialSecurityNumber()) {
                PromptUtil.PromptAssertion(
                    "Entered [social security number] already exist", "red");
                socialSecNrChecker = true;
            }
            else {
                socialSecNrChecker = false;
            }
        }
    }

    public void PersonAccountDetails() {
        var printUserDetails = GetPerson();
        var tableResult = new Table()
            .Border(TableBorder.MinimalHeavyHead)
            .BorderColor(Color.Green)
            .AddColumns("[white]Name[/]", "[white]Address[/]",
                "[white]Email[/]", "[white]Phone number[/]");

        tableResult.AddRow(
            "[grey]" + $"{printUserDetails.FirstName} {printUserDetails.LastName}" +
            "[/]",
            "[grey]" + $"{printUserDetails.Address}" + "[/]",
            "[grey]" + $"{printUserDetails.Email}" + "[/]",
            "[grey]" + $"{printUserDetails.PhoneNumber}" + "[/]"
        );

        AnsiConsole.Render(tableResult);
    }
}