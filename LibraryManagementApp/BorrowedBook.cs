using System;
namespace LibraryManagementApp
{
	public class BorrowedBook
	{
        //      public string title;
        //      public string author;
        //public string bookISBN;
        public Book book;
		public DateTime borrowDate;
		public User user;

        public BorrowedBook(Book book, DateTime borrowDate, User user)
        {
            //this.title = title;
            //this.author = author;
            //this.bookISBN = bookISBN;
            this.book = book;
            this.borrowDate = borrowDate;
            this.user = user;
        }
    }
}

