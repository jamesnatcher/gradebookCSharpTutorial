// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("James' gradebook");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(95.6);

            book.ShowStatistics();
        }
    }
}