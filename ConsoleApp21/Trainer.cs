using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21
{
    public class Trainer
    {
        public string Name = "Ash";
        public void CreateTrainer()
        {
            Console.WriteLine("What is your name?");
            Name = Console.ReadLine();
            Console.WriteLine("Welcome " + Name);
        }
    }
}
