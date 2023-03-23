using LibraryManagementApp;

List<Book> books = new List<Book>
{
    new Book("Tõde ja õigus", "Anton H. Tammsaare", "1"),
    new Book("Pool tõde ja natuke õigus", "Kait Kall", "2"),
    new Book("Kuritöö ja karistus", "Fjodor Dostojevski", "3")
};

List<BorrowedBook> borrowedBooks = new List<BorrowedBook>();
Library library = new Library(books, borrowedBooks);
User user = new User("maanus","1");
string[] commands = { "LISA RAAMAT", "EEMALDA RAAMAT", "OTSI RAAMAT", "KUVA RAAMAT", "LAENUTA RAAMAT", "TAGASTA RAAMAT" };

// start of main application
Console.WriteLine("Tere tulemast raamatukokku!");

while (true)
{
    Console.WriteLine("Sisesta käsklus: ");
    string userCommand = Console.ReadLine();
    string correctedCommand = VerifyCommand(userCommand);

    // Adds a book to the library
    if (correctedCommand == commands[0])
    {
        string title = ReadUserInput("Sisesta raamatu pealkiri");
        string author = ReadUserInput("Sisesta raamatu autor");
        string isbn = ReadUserInput("Sisesta raamaru ISBN");

        library.AddBook(new Book(title, author, isbn));

        Console.WriteLine("Raamat lisatud!");
    }

    // Removes a book from the library
    if (correctedCommand == commands[1])
    {
        string isbn = ReadUserInput("Sisesta raamatu ISBN");

        library.RemoveBook(isbn);

        Console.WriteLine("Raamat eemaldatud!");
    }

    // Search for a book based on a keyword
    if (correctedCommand == commands[2])
    {
        string keyword = ReadUserInput("Sisesta märgusõna");

        library.SearchBooks(keyword);
    }

    // Display all books from the library
    if (correctedCommand == commands[3])
    {    
        library.DisplayBooks(library.books);
    }

    // borrow a book from the library
    if (correctedCommand == commands[4])
    {
        string isbn = ReadUserInput("Sisesta soovitud raamatu ISBN");

        library.BorrowBook(isbn, user);
    }

    // return a borrowed book to the library
    if (correctedCommand == commands[5])
    {
        string isbn = ReadUserInput("Sisesta tagastatava raamatu ISBN");

        library.ReturnBook(isbn);
    }

}

string ReadUserInput(string instructionsForUser)
{
    Console.WriteLine(instructionsForUser + ": ");
    string userInput = Console.ReadLine();
    return userInput;
}

string VerifyCommand(string userCommand)
{

    userCommand = userCommand.ToUpper();

    if (commands.Contains(userCommand))
    {
        return userCommand;
    }
    else
    {
        return null;
    }
}