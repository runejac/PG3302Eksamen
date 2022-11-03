using Spectre.Console;

namespace PG3302Eksamen.Utils;

public static class PromptUtil {
    public static bool PromptConfirmation(string text) {
        return AnsiConsole.Confirm("[green]" + text + "[/]");
    }

    public static string PromptSelectPrompt(string? title, string[] questions) {
        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title(title)
                .PageSize(10)
                .AddChoices(questions));
    }

    public static string PromptPassword(string prompt) {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(prompt)
                .PromptStyle("grey50")
                .Secret());
    }


    // TODO: Validate correctly, now it only checks for no input

    public static string PromptQuestion(string question, string error) {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(question)
                .Validate(input
                    => !string.IsNullOrWhiteSpace(input)
                        ? ValidationResult.Success()
                        : ValidationResult.Error("[red]" + error + "[/]")));
    }

    // TODO: Does not seem to interpolate correctly :(
    public static void PromptAssertion(string assertion) {
        AnsiConsole.MarkupLineInterpolated($"[red]{assertion}[/]");
    }
}