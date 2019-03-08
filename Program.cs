using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }
        static void Start()
        {
            string TemporaryString;
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("ST :Search tile");
            Console.WriteLine("SA :Search author");
            Console.WriteLine("A :Show all books");
            Console.Write(">>");
            TemporaryString = Console.ReadLine();
            switch (TemporaryString)
            {
                case "ST":
                case "st":
                    SearchTitle();
                    break;
                case "SA":
                case "sa":
                    SearchAuthor();
                    break;
                case "A":
                case "a":
                    ShowAll();
                    break;
                default:
                    Console.WriteLine("Please only write ST,st,SA,sa,A or a");
                    Start();
                    break;
            }
        }
        static void SearchTitle()
        {
            Console.WriteLine("Enter the book's name:");
            Console.Write(">>");
            string TemporaryString = Console.ReadLine();
        }
        static void SearchAuthor()
        {
            Console.WriteLine("Enter the author's name:");
            Console.Write(">>");
            string TemporaryString = Console.ReadLine();
        }
        static void ShowAll()
        {

        }
    }
}
