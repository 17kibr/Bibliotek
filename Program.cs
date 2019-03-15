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
            List<Book> mylist = new List<Book>()
        }
        static void Start()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("ST :Search tile");
            Console.WriteLine("SA :Search author");
            Console.WriteLine("A :Show all books");
            Console.WriteLine("");
            
        }
        Console.WriteLine("");
            EditSvar = (Console.ReadLine());
       static void Edit()
        {
           
            string EditSvar, ADD, REM, ActionError, AddAuthor, AddTitel;
            Console.WriteLine("to ADD author or book type ADD");
            Console.WriteLine("to Remove author or book type REM");
            EditSvar = (Console.ReadLine());

            if (EditSvar == "ADD")
            {
                Console.WriteLine("Titel for the book");
                AddTitel = (Console.ReadLine());
               
                Console.WriteLine("Author for the book");
                AddAuthor = (Console.ReadLine());
                mylist.Add(new Book(AddTitel, AddAuthor));
            }
            else if (EditSvar == "REM")
            {

            }
            else 
            {
                Console.WriteLine("Someting went wrong type (return) to go back to start page or S to shutdown program");
                ActionError = (Console.ReadLine());
                if (ActionError == "return")
                    {

                }
                else if (ActionError == "S")
                    {

                }
                else
                {

                }
            }
        }
    }
}
