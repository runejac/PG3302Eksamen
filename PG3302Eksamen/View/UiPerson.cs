using PG3302Eksamen.Controller;
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;
using static BCrypt.Net.BCrypt;

namespace PG3302Eksamen.View;

public class UiPerson {
	private readonly PersonController _personController = new();

	public Person GetPerson() {
		return _personController.GetPerson();
	}

	public List<Account> GetAllAccounts() {
		return _personController.GetAllAccounts();
	}
	
	public List<Bill> GetAllBills() {
		return _personController.GetAllBills();
	}

	public void LogIn() {
		var ssnEntered = PromptUtil.PromptQuestion(
			"Enter your social security number: ",
			"Invalid social security number entered.");
		var passwordEntered = PromptUtil.PromptPassword(
			"Enter your password: ");

		_personController.Authenticate(ssnEntered, passwordEntered);
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
			PromptUtil.PromptQuestion("Phone number: ", "Invalid phone number entered");
		var email = PromptUtil.PromptEmail("Email: ", "Invalid email entered");

		var password = "";
		var hashedPassword = "";

		while (passwordChecker) {
			password = PromptUtil.PromptPassword("Password: ");
			var confirmPassword = PromptUtil.PromptPassword("Confirm password: ");


			if (password != confirmPassword) {
				PromptUtil.PromptAssertion("Passwords did not match, try again.");
			}
			else {
				hashedPassword = HashPassword(password);
				passwordChecker = false;
			}
		}


		while (socialSecNrChecker) {
			var socialSecurityNumber =
				PromptUtil.PromptQuestion("Enter social security number: ",
					"Invalid social entered");
			_personController.CreatePerson(address, firstName, lastName,
				hashedPassword,
				phoneNumber, socialSecurityNumber,
				email);
			if (_personController.ValidateSocialSecurityNumber()) {
				PromptUtil.PromptAssertion(
					"Entered [social security number] already exist");
				socialSecNrChecker = true;
			}
			else {
				socialSecNrChecker = false;
			}
		}
	}
}