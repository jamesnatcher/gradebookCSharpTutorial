namespace GradeBook.Tests;

public delegate string WriteLogDelegate(string logMessage);

public class TypeTests
{
    int count = 0;

    [Fact]
    public void WriteLogDelegateCanPointToMethod()
    {
        WriteLogDelegate log = ReturnMessage;

        log +=  ReturnMessage;
        log += IncrementCount;

        var result = log("Hello!");
        Assert.Equal(3, count);
    }

    string IncrementCount(string message)
    {
        count++;
        return message.ToLower();
    }
    string ReturnMessage(string message)
    {
        count++;
        return message;
    }

    [Fact]
    public void Testsest()
    {
        // Given
        var x = GetInt();
        SetInt(ref x);

        // Then
        Assert.Equal(42, x);
    }

    private void SetInt(ref int x)
    {
        x = 42;
    }

    private int GetInt()
    {
        return 3;
    }

    [Fact]
    public void CSharpCanPassByRef()
    {
        // Given
        var book1 = GetBook("Book 1");
        GetBookSetNameRef(ref book1, "New Name");

        // Then
        Assert.Equal("New Name", book1.Name);
    }

    private void GetBookSetNameRef(ref Book book, string name)
    {
        book = new Book(name);
        book.Name = name;
    }

    [Fact]
    public void CSharpIsPassByValue()
    {
        // Given
        var book1 = GetBook("Book 1");
        GetBookSetName(book1, "New Name");

        // Then
        Assert.Equal("Book 1", book1.Name);
    }

    private void GetBookSetName(Book book, string name)
    {
        book = new Book(name);
        book.Name = name;
    }

    [Fact]
    public void CanSetNameFromReference()
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
    public void StringsBehaveLikeValueTypes()
    {
        string name = "James";
        var upper = MakeUppercase(name);

        Assert.Equal("James", name);
        Assert.Equal("JAMES", upper);
    }

    private string MakeUppercase(string name)
    {
        return name.ToUpper();
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