namespace GradeBook.Tests;

public class BookTests
{
    // [Fact]
    // public void TestLetterGrades()
    // {
    //     var book = new Book("");
    //     book.AddGrade('A');
    //     book.AddGrade('A');
    //     book.AddGrade('A');

    //     var result = book.GetStatistics();

    //     Assert.Equal(240.0, book.GetSum());
    //     Assert.Equal(90.0, result.Highest, 1);
    //     Assert.Equal(70.0, result.Lowest, 1);
    // }

    [Fact]
    public void BookCalculateStatistics()
    {
        // arrange
        var book = new Book("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        // act
        var result = book.GetStatistics();

        // assert
        Assert.Equal(85.6, result.Average, 1);
        Assert.Equal(90.5, result.Highest, 1);
        Assert.Equal(77.3, result.Lowest, 1);
        Assert.Equal('B', result.Letter);
        Assert.Equal("", book.GetName());
    }

    [Fact]
    public void BookDoesNotAllowInvalidInputs()
    {
        // arrange
        var book = new Book("");
        book.AddGrade(89.1);
        book.AddGrade(90.5);
        book.AddGrade(77.3);

        // act
        var result = book.GetStatistics();

        // assert
        Assert.Equal(85.6, result.Average, 1);
        Assert.Equal(90.5, result.Highest, 1);
        Assert.Equal(77.3, result.Lowest, 1);
        Assert.Equal("", book.GetName());
    }
}