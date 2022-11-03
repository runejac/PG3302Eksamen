using PG3302Eksamen.Controller;
using PG3302Eksamen.Utils;

namespace PG3302Eksamen.View;

public class UiPerson {
    private readonly PersonController _personController = new();

    public void CreatePerson() {
        var socialSecNrChecker = true;
        var passwordChecker = true;


        var address = PromptUtil.PromptQuestion("Enter address: ", "Invalid address entered");
        var firstName = PromptUtil.PromptQuestion("Enter first name: ", "Invalid first name entered");
        var lastName = PromptUtil.PromptQuestion("Enter last name: ", "Invalid last name entered");
        var phoneNumber = PromptUtil.PromptQuestion("Phone number: ", "Invalid phone number entered");
        var email = PromptUtil.PromptQuestion("Enter email: ", "Invalid email entered");


        var password = "";

        while (passwordChecker) {
            password = PromptUtil.PromptPassword("Password: ");
            var confirmPassword = PromptUtil.PromptPassword("Password again: ");
            if (password != confirmPassword)
                PromptUtil.PromptAssertion("Passwords did not match, try again.");

            else
                passwordChecker = false;
        }


        while (socialSecNrChecker) {
            var socialSecurityNumber =
                PromptUtil.PromptQuestion("Enter social security number: ", "Invalid social entered");
            _personController.CreatePerson(address, firstName, lastName, password, phoneNumber, socialSecurityNumber,
                email);
            if (_personController.ValidateSocialSecurity()) {
                PromptUtil.PromptAssertion("Entered [social security number] already exist");
                socialSecNrChecker = true;
            }
            else {
                socialSecNrChecker = false;
            }
        }
    }
}