
using library;

var historyBook = new Book();
historyBook.Name = "World History";
historyBook.Id=1;
var book2 = new Book();
book2.Name = "Harry Potter";
book2.Id = 2;

var bookList = new List<Book>
{
    historyBook,book2
};

var author= new Author(bookList);
author.Name = "Meri Peting";
var author2 = new Author(bookList);
author2.Name = "Anabel Marlon";

var biography = new Biography();
biography.Id = 1;
biography.Author = author;
author.Biography = biography;

var biography2 = new Biography();
biography2.Id = 2;
biography2.Author = author2;


var chapter = new Chapter();
chapter.Name = "First Chapter";
chapter.Id = 2;
chapter.Book = historyBook;

