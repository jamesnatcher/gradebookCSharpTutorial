namespace GradeBook.Tests;

public class TypeTests
{
    [Fact]
    public void TestName()
    {
        // Given
        var book1 = GetBook("Book 1");
        SetName(book1, "New Name");

        // Then
        Assert.Equal("New Name", book1.Name);
    }
    private void SetName(Book book, string name)
    {
        book.Name = name;
    }
    [Fact]
    public void GetBookReturnsDifferentObjects()
    {
        // arrange
        var book1 = GetBook("Book 1");
        var book2 = GetBook("Book 2");

        // act

        // assert
        Assert.Equal("Book 1", book1.Name);
        Assert.Equal("Book 2", book2.Name);
        Assert.NotSame(book1, book2);
    }
    [Fact]
    public void TwoVarsCanReferenceSameObject()
    {
        // arrange
        var book1 = GetBook("Book 1");
        var book2 = book1;

        // act

        // assert (Checking if two objects reference the same thing)
        Assert.Same(book1, book2);
        Assert.True(Object.ReferenceEquals(book1, book2));
    }

    Book GetBook(string name)
    {
        return new Book(name);
    }
}