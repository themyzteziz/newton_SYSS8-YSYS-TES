using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookstore;

namespace Bookstore.Tests;

[TestClass]
public class BookstoreInventoryTests
{
    private BookstoreInventory _inventory;

    [TestInitialize]
    public void Setup()
    {
        _inventory = new BookstoreInventory();
    }

    [TestMethod]
    public void Test1()
    {
        //Implement tests
        Assert.IsTrue(true);
    }

[TestMethod]
    public void AddBook_ShouldAddNewBook()
    {
        var isbn = "1234";
        var expectedStock = 10;
        var book = new Book("1234", "Harry Potter", "J.K Rowling", 10);

        _inventory.AddBook(book);

        var stock = _inventory.CheckStock(isbn);

        Assert.AreEqual(expectedStock, stock);
    }      

    [TestMethod]
    public void FindBookByTitle_ShouldReturnCorrectBook()
    {
        var title = "Harry Potter";

        var book = new Book("1234", "Harry Potter", "J.K Rowling", 10);
        _inventory.AddBook(book);
        var result = _inventory.FindBookByTitle(title);

        Assert.IsNotNull(result);
        Assert.AreEqual("Harry Potter", result.Title);
    }

    [TestMethod]
    public void CheckStock_ShouldReturnCorrectStock()
    {        
        var book1 = new Book("1234", "Harry Potter", "J.K Rowling", 10);
        var book2 = new Book("5678", "The Lord of the Rings", "J.R.R. Tolkien", 5);

        _inventory.AddBook(book1);
        _inventory.AddBook(book2);

        var books = _inventory.GetAllBooks();

        Assert.AreEqual(2, books.Count);
        
    }     
}