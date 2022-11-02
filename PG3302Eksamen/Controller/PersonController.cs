
using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Repositories;
using PG3302Eksamen.View;

namespace PG3302Eksamen.Controller;

public class PersonController  {
    private Person Person = new();
    
    // TODO: Probably move creation to its own class, the same with prompt as its not persons job

    public void CreatePerson(string address, string firstName, string lastName, string password,
        string phoneNumber,
        string socialSecurityNumber, string email) {
         Person = Person.CreatePerson(address,firstName,lastName,password,phoneNumber,socialSecurityNumber,email);
    }
    
    
    	public void RegisterNewPerson() {
    		var personRepository = new PersonRepository();
    
    		var socialSecNrChecker = true;
    		var passwordChecker = true;
    
    
            var address = Utils.PromptUtil.PromptQuestion("Enter address: ", "Invalid address entered");
            var firstName = Utils.PromptUtil.PromptQuestion("Enter first name: ", "Invalid first name entered");
            var lastName = Utils.PromptUtil.PromptQuestion("Enter last name: ", "Invalid last name entered");
            var phoneNumber = Utils.PromptUtil.PromptQuestion("Phone number: ", "Invalid phone number entered");
            var email = Utils.PromptUtil.PromptQuestion("Enter email: ", "Invalid email entered");

    
    		var password = "";
    
    		while (passwordChecker) {
                password = Utils.PromptUtil.PromptPassword("Password: ");
                var confirmPassword = Utils.PromptUtil.PromptPassword("Password again: ");
                if (password != confirmPassword) {
    				Ui.InvalidInputMessage("Passwords did not match, try again.");
    			}
    			else {
    				passwordChecker = false;
    			}
    		}
    
    
    		while (socialSecNrChecker) {
    			Ui.MessageSameLine("Social security number: ", ConsoleColor.Blue);
    			var socialSecurityNumber = Console.ReadLine();
    			var match = personRepository.GetAll().ToList().Any(s =>
    				s.SocialSecurityNumber.Contains(socialSecurityNumber));
                
                
	            CreatePerson(address, firstName, lastName, password,
	                phoneNumber, socialSecurityNumber, email);
    
    			if (personRepository.GetAll().ToList().Count < 1) {
    				personRepository.Insert(Person);
    			}
    
    			if (!match) {
    				socialSecNrChecker = false;
    				personRepository.Insert(Person);
    				Ui.SuccessfullyRegistered(Person.FirstName);
    			}
    			else {
    				Ui.InvalidInputMessage("Social Sec already exists");
    			}
    		}
    	}
}