using PG3302Eksamen.Model;
using PG3302Eksamen.Utils;

namespace PG3302Eksamen.View;

public class Ui {
    private readonly UiAccount _uiAccount = new();
    private readonly UiBill _uiBill = new();
    private readonly UiTransaction _uiTransaction = new();
    private Person _person;

    public UiPerson UiPerson { set; get; }

    public void ClearConsole() {
        Console.Clear();
    }

    public void WelcomeMessage() {
        var selectedChoice = PromptUtil.PromptSelect(
            "[cyan]Welcome to Bank Kristiania![/]",
            new[] { "Register", "Login", "[red]Exit[/]" }
        );
        switch (selectedChoice) {
            case "Register":
                UiPerson = new UiPerson();
                UiPerson.CreatePerson();
                _person = UiPerson.GetPerson();
                ClearConsole();
                MainMenuAfterAuthorized();
                break;
            case "Login":
                UiPerson = new UiPerson();
                try {
                    _person = UiPerson.LogIn();
                    ClearConsole();
                    MainMenuAfterAuthorized();
                }
                catch (Exception e) {
                    PromptUtil.PromptAssertion(
                        "An error has occured or wrong credentials, try again or register.",
                        "red");
                    Thread.Sleep(3000);
                    UiPerson = null;
                    ClearConsole();
                    WelcomeMessage();
                }

                break;
            case "[red]Exit[/]":
                PromptUtil.PromptAssertion("Good bye, hope to see you soon!", "blue");
                Environment.Exit(0);
                break;
        }
    }


    public void GoBackToMainMenu() {
        var selectedChoice = PromptUtil.PromptSelect("",
            new[] {
                "[red]Back[/]"
            }
        );
        switch (selectedChoice) {
            case "[red]Back[/]":
                ClearConsole();
                MainMenuAfterAuthorized();
                break;
        }
    }

    public void MainMenuAfterAuthorized() {
        PromptUtil.PromptAssertion(
            $"Greetings {_person?.FirstName}, welcome to the Bank of Kristiania where your needs meets our competence!",
            "green");
        var selectedChoice = PromptUtil.PromptSelect("MAIN MENU",
            new[] {
                "Create an account",
                "Pay bills or transfer money",
                "Display all bills",
                "Display all accounts",
                "Display user details",
                "[red]Log out[/]"
            }
        );

        switch (selectedChoice) {
            case "Create an account":
                ClearConsole();
                _uiAccount.CreateBankAccountFor(_person);
                _uiAccount.AskUserWhatTypeOfAccountToBeMade();
                MainMenuAfterAuthorized();
                break;
            case "Pay bills or transfer money":
                ClearConsole();
                _uiTransaction.TransactionMenu(this, _uiAccount, _uiBill);
                break;
            case "Display all accounts":
                ClearConsole();
                _uiAccount.OverViewOfAccounts(null, this);
                GoBackToMainMenu();
                break;
            case "Display all bills":
                _uiBill.OverViewOfBills(this);
                break;
            case "Display user details":
                ClearConsole();
                UiPerson!.PersonAccountDetails();
                GoBackToMainMenu();
                break;
            case "[red]Log out[/]":
                PromptUtil.PromptAssertion(
                    $"You are now logged out, {_person?.FirstName}.",
                    "blue");
                Thread.Sleep(3000);
                ClearConsole();
                WelcomeMessage();
                _person = null;
                break;
        }
    }
}