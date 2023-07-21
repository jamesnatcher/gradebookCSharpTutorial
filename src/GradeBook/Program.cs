// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
namespace GradeBook
{

    class Program
    {
        static void Main(string[] args)
        {
            var defaultBookname = "Gradebook";
            Console.Write("Input the name you want to give the gradebook: ");
            var input = Console.ReadLine();
            if (input == "")
            {
                input = defaultBookname;
            }
            var book = new Book(input);
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;
            book.GradeAdded += OnGradeAdded;


            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit:");
                var gradeInput = Console.ReadLine();
                if (gradeInput == "q")
                {
                    break;
                }
                try
                {
                    var gradeDouble = double.Parse(gradeInput);
                    book.AddGrade(gradeDouble);
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            book.ShowStatistics();

        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade was added");
        }
    }
}