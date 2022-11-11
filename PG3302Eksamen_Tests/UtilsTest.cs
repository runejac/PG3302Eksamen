using CommandDotNet;
using CommandDotNet.Spectre;
using CommandDotNet.Spectre.Testing;
using CommandDotNet.TestTools;
using PG3302Eksamen.Utils;
using PG3302Eksamen.View;
using Shouldly;
using Spectre.Console;
using  Spectre.Console.Testing;
using Xunit;
using TestConsole = Spectre.Console.Testing.TestConsole;


namespace PG3302Eksamen_Tests; 

public partial class AnsiConsoleTests
{
    public sealed class Prompt
    {
        [Fact]
        public void Should_Return_Default_Value_If_Nothing_Is_Entered()
        {
            var color1 = new Color(128, 0, 128);
            var color2 = new Color(128, 0, 128);

            // When
            var result = color1.Equals(color2);

            // Then
            result.ShouldBeTrue();
        }


        [Xunit.Theory]
        [InlineData(true, true)]
        [InlineData(false, false)]
        public void ShouldValidateEmailTest(bool expected, bool defaulValue) {
          
            var prompt = "ola@gmail.com";
            var error = "NOPE";
            var console = new TestConsole().EmitAnsiSequences();
            console.Input.PushKey(ConsoleKey.Enter);
            
            



        }
    }
}