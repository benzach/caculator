using calculator.Models.interfaces;
using calculator.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                                      .AddSingleton<IValidationService, ValidationService>()
                                      .AddSingleton<ICalculatorService, CalculatorService>()
                                      .BuildServiceProvider();
            var CalculatorService = serviceProvider.GetService<ICalculatorService>();
            Console.WriteLine("Enter x to exit program");
            while(true)
            {
                
                Console.WriteLine("Please enter 2 operands separated by comma to add:");
                var input = Console.ReadLine();
                if(input.ToLower()=="x")
                {
                    break;
                }
                var sum=CalculatorService.Add(input);
                Console.WriteLine($"sum of {input} = {sum}");
            }
            
        }
    }
}
