using PG3302Eksamen.Model;
using PG3302Eksamen.Model.AccountModel;
using PG3302Eksamen.Utils;
using Spectre.Console;

namespace PG3302Eksamen.View;

public class Ui {
    private readonly UiAccount _uiAccount = new();
    // TODO Message skal være private etter hvert, men brukes i BankManager enn så lenge
    // TODO og skal kun brukes her
    // TODO, så skrives custom meldinger her og calles hvor de brukes tror jeg

    private readonly UiPerson _uiPerson = new();
    private Person? _person;


    private void ClearConsole() {
        Console.Clear();
    }

    private void Message(string message, ConsoleColor color) {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
    }

    public void MessageSameLine(string message, ConsoleColor color) {
        Console.ForegroundColor = color;
        Console.Write(message);
    }


    public void InvalidInputMessage(string? customMessage) {
        Message(customMessage ?? "Invalid input, try again.", ConsoleColor.DarkRed);
    }

    public void WelcomeMessage() {
        var selectedChoice = PromptUtil.PromptSelectPrompt(
            "[cyan]Welcome to Bank Kristiania![/]",
            new[] { "Register", "Login", "Exit" }
        );
        switch (selectedChoice) {
            case "Register":
                _uiPerson.CreatePerson();
                _person = _uiPerson.GetPerson();
                ClearConsole();
                MainMenuAfterAuthorized();
                break;
            case "Login":
                while (_person == null) {
                    _person = _uiPerson.LogIn();
                    var askExit = PromptUtil.PromptSelectPrompt("", new[] {
                        "Try again",
                        "Exit"
                    });

                    if (askExit == "Exit") {
                        ClearConsole();
                        WelcomeMessage();
                    }
                    else {
                        _person = _uiPerson.LogIn();
                    }
                }

                ClearConsole();
                MainMenuAfterAuthorized();
                break;
            case "Exit":
                Message("Good bye, hope to see you soon!", ConsoleColor.Blue);
                Environment.Exit(0);
                break;
        }
    }

    // TODO: Move to UiAccount
    private void OverViewOfAccounts() {
        var printAccountDetails = _uiPerson.GetAllAccounts();

        var tableResult = new Table()
            .Border(TableBorder.Square)
            .BorderColor(Color.Green)
            .AddColumns("[white]Account name[/]", "[white]Account number[/]",
                "[white]Balance[/]",
                "[white]Interest rate[/]", "[white]Withdrawal limit[/]");

        foreach (var account in printAccountDetails)
            tableResult.AddRow(
                "[grey]" + $"{account.Name}" + "[/]",
                "[grey]" + $"{account.AccountNumber}" + "[/]",
                "[grey]" + $"{account.Balance} kr" + "[/]",
                "[grey]" + $"{account.Interest}" + "[/]",
                "[grey]" + $"{WithdrawLimit(account)}" + "[/]"
            );

        // Current account will never have withdraw limit?
        dynamic WithdrawLimit(Account account) {
            if (account.GetAccountType() == "current account") return "Unlimited";
            return account.WithdrawLimit;
        }

        AnsiConsole.Write(tableResult);
        GoBackToMainMenu();
    }


    private void GoBackToMainMenu() {
        var selectedChoice = PromptUtil.PromptSelectPrompt("",
            new[] {
                "Back"
            }
        );
        switch (selectedChoice) {
            case "Back":
                ClearConsole();
                MainMenuAfterAuthorized();
                break;
        }
    }

    private void MainMenuAfterAuthorized() {
        Message(
            $"Greetings {_person?.FirstName}, welcome to the Bank of Kristiania where your needs meets our competence!",
            ConsoleColor.Green);
        var selectedChoice = PromptUtil.PromptSelectPrompt("MAIN MENU",
            new[] {
                "Create a money account",
                "Pay bills or transfer money",
                "Check balance",
                "See user details",
                "Log out"
            }
        );

        switch (selectedChoice) {
            case "Create a money account":
                ClearConsole();
                _uiAccount.CreateBankAccountFor(_person);
                _uiAccount.AskUserWhatTypeOfAccountToBeMade();
                GoBackToMainMenu();
                break;
            case "Pay bills or transfer money":
                // TODO run code for transactions
                break;
            case "Check balance":
                ClearConsole();
                OverViewOfAccounts();
                break;
            case "See user details":
                ClearConsole();
                _uiPerson!.UserAccountDetails();
                GoBackToMainMenu();
                break;
            case "Log out":
                Message(
                    $"Good bye {_person?.FirstName}, hope to see you soon!",
                    ConsoleColor.Blue);
                // TODO set timeout 0.5sec or something here before clearing
                ClearConsole();
                WelcomeMessage();
                _person = null;
                break;
        }
    }
}