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

        /*public string Title { get; set; }
        public string Author { get; set; }
        public bool Status { get; set; }*/
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Author
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
            }
        }
        public bool Status
        {
            get
            {
                return status;
            }
            set
            {
                Status = value;
            }

        }
    }

    class Program
    {
        public static List<Book> BookList = new List<Book>();

        static void Main(string[] args)
        {
            StreamReader läsfil = new StreamReader(@"..\SavedData\BookFiles.txt");
            string s;
            // Läser filen tills till slutet hittas
            while ((s = läsfil.ReadLine()) != null)
            {
                string[] bookdata = s.Split(',');
                string temptitel = bookdata[0];
                string tempAuthor = bookdata[1];
                bool tempstatus = bool.Parse(bookdata[2]);
                // Delar upp data i raden för array
                // Värden läggs till 
                BookList.Add(new Book(temptitel, tempAuthor, tempstatus));
            }
            läsfil.Close();
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
            Console.WriteLine("L : Borrow/Return book");
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
                case "L":
                case "l":
                    Borrow();
                    break;
                default:
                    Console.WriteLine("Please only write ST,st,SA,sa,A or a");
                    Start();
                    break;
            }
        }
        static void Borrow()
        {
            string TemporaryString;
            Console.WriteLine("=============");
            Console.WriteLine("Borrow/Return");
            Console.WriteLine("=============");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("B : Borrow");
            Console.WriteLine("R : Return");
            Console.Write(">>");
            TemporaryString = Console.ReadLine();
            switch (TemporaryString)
            {
                case "B":
                case "b":
                    Console.WriteLine("===========");
                    Console.WriteLine("Borrow Book");
                    Console.WriteLine("===========");

                    Console.WriteLine("Enter the title of the book you want to borrow:");
                    Console.Write(">>");
                    string RequestTitle = Console.ReadLine();
                    foreach (var book in BookList)
                    {
                        if (book.Title.Contains(RequestTitle))
                        {
                            bool CurrentBookStatus = book.Status;
                            string DisplayStatus;
                            if (CurrentBookStatus == false)
                            {
                                DisplayStatus = "This book is currently not available";
                            }
                            else
                            {
                                DisplayStatus = "This book is currently available";
                            }


                            Console.WriteLine("Book name: " + book.Title + ", " + "By author: " + book.Author + "; status: " + DisplayStatus);
                            if (CurrentBookStatus == true)
                            {
                                Console.WriteLine("Do you want to borrow this book? Y/N");
                                string tmp = Console.ReadLine();
                                switch (tmp)
                                {
                                    case "Y":
                                    case "y":
                                        book.Status = false;
                                        Console.WriteLine("You have now borrowed " + book.Title);
                                        Console.WriteLine("Press any key to go back to the menu");
                                        Console.ReadKey();
                                        Start();
                                        break;
                                    case "N":
                                    case "n":
                                        Start();
                                        break;
                                    default:
                                        Console.WriteLine("Please write Y,y,N or n");
                                        Borrow();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("This book is unfortunately not available");
                                Console.WriteLine("Press any key to go back to the menu");
                                Console.ReadKey();
                                Start();
                            }
                        }
                        else
                        {
                            Console.WriteLine("This book does not exist in this library");
                            Console.WriteLine("Press any key to go back to the menu");
                            Console.ReadKey();
                            Start();
                        }

                    }
                    break;
                case "R":
                case "r":
                    Console.WriteLine("===========");
                    Console.WriteLine("Return Book");
                    Console.WriteLine("===========");

                    Console.WriteLine("Enter the title of the book you want to return:");
                    Console.Write(">>");
                    string RequestReturnTitle = Console.ReadLine();

                    foreach (var book in BookList)
                    {
                        if (book.Title.Contains(RequestReturnTitle))
                        {
                            bool CurrentBookStatus = book.Status;
                            string DisplayStatus;
                            if (CurrentBookStatus == false)
                            {
                                DisplayStatus = "This book is currently not available";
                            }
                            else
                            {
                                DisplayStatus = "This book is currently available";
                            }


                            Console.WriteLine("Book name: " + book.Title + ", " + "By author: " + book.Author + "; status: " + DisplayStatus);
                            if (CurrentBookStatus == false)
                            {
                                Console.WriteLine("Do you want to return this book? Y/N");
                                string tmp = Console.ReadLine();
                                switch (tmp)
                                {
                                    case "Y":
                                    case "y":
                                        book.Status = true;
                                        Console.WriteLine("You have now returned " + book.Title);
                                        Console.WriteLine("Press any key to go back to the menu");
                                        Console.ReadKey();
                                        Start();
                                        break;
                                    case "N":
                                    case "n":
                                        Start();
                                        break;
                                    default:
                                        Console.WriteLine("Please write Y,y,N or n");
                                        Borrow();
                                        break;
                                }
                            }
                            else
                            {
                                Console.WriteLine("This book is already available");
                                Console.WriteLine("Press any key to go back to the menu");
                                Console.ReadKey();
                                Start();
                            }
                        }
                        else
                        {
                            Console.WriteLine("This book does not exist in this library");
                            Console.WriteLine("Press any key to go back to the menu");
                            Console.ReadKey();
                            Start();
                        }

                    }
                    break;
                default:
                    Console.WriteLine("Please only write B, b, R or r");
                    Start();
                    break;
            }
        }
        static void SearchTitle()
        {

            Console.WriteLine("Enter the book's name:");
            Console.Write(">>");
            string RequestTitle = (Console.ReadLine());
            foreach (var book in BookList)
            {
                if (book.Title.Contains(RequestTitle))
                {
                    bool CurrentBookStatus = book.Status;
                    string DisplayStatus;
                    if (CurrentBookStatus == false)
                    {
                        DisplayStatus = "This book is currently not available";
                    }
                    else
                    {
                        DisplayStatus = "This book is currently available";
                    }


                    Console.WriteLine("book name: " + book.Title + ", " + "By author: " + book.Author + "; status: " + DisplayStatus);

                }


            }
            Start();
        }
        static void SearchAuthor()
        {
            Console.WriteLine("Enter the author's name:");
            Console.Write(">>");
            string RequestAuthor = Console.ReadLine();
            foreach (var book in BookList)
            {
                if (book.Author.Contains(RequestAuthor))
                {
                    bool CurrentBookStatus = book.Status;
                    string DisplayStatus;
                    if (CurrentBookStatus == false)
                    {
                        DisplayStatus = "This book is currently not available";
                    }
                    else
                    {
                        DisplayStatus = "This book is currently available";
                    }


                    Console.WriteLine("book name: " + book.Title + ", " + "By author: " + book.Author + "; status: " + DisplayStatus);
                    Start();
                }

                Start();
            }
        }
        static void ShowAll()
        {
            Console.WriteLine("The list of all books...");
            Console.WriteLine("========================");
            int i = 1;
            foreach (var book in BookList)
            {
                Console.WriteLine(i + ". " + book);
                i++;
            }
            Console.WriteLine("==========================");
            Console.Write("Press any key to go back to Menu");
            Console.ReadLine();
            Start();
        }
        static void EditBook()
        {
            string Tempstring;
            Console.WriteLine("metod to choose book to edit:");
            Console.WriteLine("A: show all");
            Console.WriteLine("ST: to search for title");
            Console.WriteLine("SA: to search for  Author");
            Console.WriteLine("M: to go to menu");
            Tempstring = Console.ReadLine();
            switch (Tempstring)
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
                    ShowAllEdit();
                    break;
                case "M":
                case "m":
                    Start();
                    break;
            }
            Start();
        }
        static void ShowAllEdit()
        {
            Console.WriteLine("==========================");
            int i = 1;
            foreach (var book in BookList)
            {
                Console.WriteLine(i + ". " + book);
                i++;
            }
            // visar och tar bort boken
            Console.WriteLine("==========================");
            Console.WriteLine("Remove book by selecting the number in the list");
            int dele = Convert.ToInt32(Console.ReadLine()) - 1;
            BookList.RemoveAt(dele);
            // här börjar add book funktionen
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
            Console.Write("press enter to go back to Menu");
            Console.ReadLine();
            Start();
        }
        static void DeleteBook()
        {
            string Tempstring;
            Console.WriteLine("Do you wish to remove book by:");
            Console.WriteLine("A: show all");
            Console.WriteLine("ST: to search for title");
            Console.WriteLine("SA: to search for  Author");
            Console.WriteLine("M: to go to menu");
            Tempstring = Console.ReadLine();
            switch (Tempstring)
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
                    ShowAllRemove();
                    break;
                case "M":
                case "m":
                    Start();
                    break;
            }
            Start();

        }
        static void ShowAllRemove()
        {
            Console.WriteLine("==========================");
            foreach (var book in BookList)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine("==========================");
            Console.WriteLine("Remove book by selecting the number in the list");
            int dele = Convert.ToInt32(Console.ReadLine());
            BookList.RemoveAt(dele);
            Console.Write("press enter to go back to Menu");
            Console.ReadLine();
            Start();
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
            //using (TextWriter tw = new StreamWriter(@"..\SavedData\BookFiles.txt"))
            using (TextWriter tw = new StreamWriter(@"..\SavedData\BookFiles.txt"))
            {
                for (int i = 0; i < BookList.Count; i++)
                {
                    tw.WriteLine(BookList[i].Title + "," + BookList[i].Author + "," + BookList[i].Status);
                }
                tw.Close();
            }
        }
    }
}
//ADD: BookList.Add(new Book("Title", "Author", true)); 
//BookList.Add(new Book("titlehere", "authorhere", true));
//
