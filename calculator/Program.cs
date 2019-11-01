using calculator.Models.interfaces;
using calculator.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace calculator
{
    class Program
    {
        private static bool keepRunning = true;
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                                      .AddSingleton<IDelimiterService,DelimiterService>()
                                      .AddSingleton<IValidationService, ValidationService>()
                                      .AddSingleton<ICalculatorService, CalculatorService>()
                                      .BuildServiceProvider();
            var CalculatorService = serviceProvider.GetService<ICalculatorService>();
            Console.WriteLine("Enter x to exit program");
            while(keepRunning)
            {
                
                Console.WriteLine("Please enter 2 operands separated by comma to add:");
                Console.CancelKeyPress += Console_CancelKeyPress;


                var input = Console.ReadLine();
                if(input==null || input.ToLower()=="x")
                {
                    break;
                }
                try
                {
                    var sumResult = CalculatorService.AddOperands(input);
                    Console.WriteLine($"{string.Join('+', sumResult.operands)} = {sumResult.sum}");
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            
        }

        private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
            Program.keepRunning = false;
        }
    }
}
