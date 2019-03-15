using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibrary
{
    public class Book
    {
        string title;
        string author;
        bool status;

        public override string ToString()
        {
            return $"{this.title} {this.author} {this.status}";
        }

        public Book(string BookTitle, string BookAuthor, bool BookStatus)
        {
            title = BookTitle;
            author = BookAuthor;
            status = BookStatus;
        }
    }

    class Program
    {
        public static List<Book> BookList = new List<Book>();

        static void Main(string[] args)
        {
                Start();
        }
        static void Start()
        {
            string TemporaryString;
            Console.WriteLine("====");
            Console.WriteLine("MENU");
            Console.WriteLine("====");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("ST :Search tile");
            Console.WriteLine("SA :Search author");
            Console.WriteLine("A :Show all books");
            Console.WriteLine("E :Edit");
            Console.WriteLine("S :ShutDown");
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
                case "E":
                case "e":
                    Edit();
                    break;
                case "S":
                case "s":
                    ShutDown();
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
            Console.WriteLine("The list of all books...");
            Console.WriteLine("==========================");
            foreach (var book in BookList)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("==========================");
            Console.Write("press enter to go back to Menu");
            Console.ReadLine();
            Start();
        }
        static void EditBook()
        {

        }
        static void DeleteBook()
        {

        }
        static void AddBook()
        {
            string tempTitle, tempAuthor;
            Console.WriteLine("========");
            Console.WriteLine("ADD BOOK");
            Console.WriteLine("========");
            Console.WriteLine("What is the book's title?");
            Console.WriteLine(">>");
            tempTitle = Console.ReadLine();
            Console.WriteLine("What is the book's Author");
            Console.WriteLine(">>");
            tempAuthor = Console.ReadLine();

            Console.WriteLine("You have added the following book: ");
            Console.WriteLine(tempTitle + ", " + tempAuthor);
            BookList.Add(new Book(tempTitle, tempAuthor, true));
            Console.WriteLine("Do you want to add another book? Y/N");
            string temp = Console.ReadLine();
            switch (temp)
            {
                case "Y":
                case "y":
                    AddBook();
                    break;
                case "N":
                case "n":
                    Start();
                    break;
                default:
                    Console.WriteLine("Please only write Y, y, N or n");
                    Start();
                    break;
            }
        }
        static void Edit()
        {
            Console.WriteLine("====");
            Console.WriteLine("EDIT");
            Console.WriteLine("====");
            Console.WriteLine("A : Add book");
            Console.WriteLine("D : Delete book");
            Console.WriteLine("E : Edit book information");
            Console.WriteLine("M : Back to main menu");
            Console.WriteLine("S :ShutDown");
            Console.Write(">>");
            string TemporaryString = Console.ReadLine();
            switch (TemporaryString)
            {
                case "A":
                case "a":
                    AddBook();
                    break;
                case "D":
                case "d":
                    DeleteBook();
                    break;
                case "E":
                case "e":
                    EditBook();
                    break;
                case "M":
                case "m":
                    Start();
                    break;
                case "S":
                case "s":
                    ShutDown();
                    break;
                default:
                    Console.WriteLine("Please only write A,a,D,d,E,e,M,m,S or s");
                    Start();
                    break;
            }
        } 
        static void ShutDown()
        {
            //BookList.Add(new Book("titlehereeeee", "authorhere", true));
            using (TextWriter tw = new StreamWriter(@"..\SavedData\BookFiles.txt"))
            {
                foreach (Book b in BookList)
                {
                    tw.WriteLine(b);
                }
                tw.Close();
            }
        }
    }
}
//ADD: BookList.Add(new Book("Title", "Author", true)); 
//BookList.Add(new Book("titlehere", "authorhere", true));
//
