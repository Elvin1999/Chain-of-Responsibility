using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp25
{
    interface IChain
    {
        void SetNextChain(IChain chain);
        void Calculate(Numbers numbers);
    }

    class Numbers
    {
        public Numbers(int number1, int number2, string calculationWanted)
        {
            Number1 = number1;
            Number2 = number2;
            CalculationWanted = calculationWanted;
        }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public string CalculationWanted { get; set; }
    }

    class Add : IChain
    {
        public IChain NextChain { get; set; }
        public void Calculate(Numbers numbers)
        {
            if (numbers.CalculationWanted == "add")
            {
                Console.WriteLine(numbers.Number1 + numbers.Number2);
            }
            else
            {
                NextChain.Calculate(numbers);
            }
        }

        public void SetNextChain(IChain chain)
        {
            NextChain = chain;
        }
    }
    class Sub : IChain
    {
        public IChain NextChain { get; set; }
        public void Calculate(Numbers numbers)
        {
            if (numbers.CalculationWanted == "sub")
            {
                Console.WriteLine(numbers.Number1 - numbers.Number2);
            }
            else
            {
                NextChain.Calculate(numbers);
            }
        }

        public void SetNextChain(IChain chain)
        {
            NextChain = chain;
        }
    }
    class Mult : IChain
    {
        public IChain NextChain { get; set; }
        public void Calculate(Numbers numbers)
        {
            if (numbers.CalculationWanted == "mult")
            {
                Console.WriteLine(numbers.Number1 * numbers.Number2);
            }
            else
            {
                NextChain.Calculate(numbers);
            }
        }

        public void SetNextChain(IChain chain)
        {
            NextChain = chain;
        }
    }
    class Divi : IChain
    {
        public IChain NextChain { get; set; }
        public void Calculate(Numbers numbers)
        {
            if (numbers.CalculationWanted == "div")
            {
                Console.WriteLine(numbers.Number1 / numbers.Number2);
            }
            else
            {
                Console.WriteLine("Only add sub mult div ");
            }
        }

        public void SetNextChain(IChain chain)
        {
            NextChain = chain;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Numbers numbers = new Numbers(5, 3, "pow");
            IChain request1 = new Add();
            IChain request2 = new Sub();
            IChain request3 = new Mult();
            IChain request4 = new Divi();
            request1.SetNextChain(request2);
            request2.SetNextChain(request3);
            request3.SetNextChain(request4);
            request1.Calculate(numbers);

        }
    }
}
