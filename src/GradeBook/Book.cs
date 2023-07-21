namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        private List<char> letterGrades;
        public string Name
        {
            get;
            set;
            // private set;         Use this when you want to allow inital setting but not further modifications.
        }
        readonly string category = "Science"; // Can be changed only in constructure
        const string category2 = "Science"; // Cannot be changed at all
        public delegate void GradeAddedDelegate(object sender, EventArgs args);

        public Book(string name)
        {
            grades = new List<double>();
            letterGrades = new List<char>();
            this.Name = name;
        }
        public Book()
        {
            grades = new List<double>();
            letterGrades = new List<char>();
            Name = "New Book";
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            this.Name = name;
        }
        public void AddGrade(string letter)
        {
            switch (letter)
            {
                case "A":
                    grades.Add(90);
                    break;
                case "B":
                    grades.Add(80);

                    break;
                case "C":
                    grades.Add(70);

                    break;
                case "D":
                    grades.Add(60);
                    break;
                case "F":
                    grades.Add(50);
                    break;
                default:
                    throw new ArgumentException($"Invalid {nameof(letter)}");
            }
        }
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public event GradeAddedDelegate GradeAdded;

        public double GetSum()
        {
            double sum = 0;
            foreach (double grade in grades)
            {
                sum += grade;
            }
            return sum;
        }
        public double GetAverage()
        {
            double sum = GetSum();
            double average = sum / grades.Count();
            return average;
        }
        public double GetHighestGrade()
        {
            double highestGrade = double.MinValue;
            foreach (var number in grades)
            {
                if (number > highestGrade)
                {
                    highestGrade = number;
                }
            }
            return highestGrade;
        }
        public double GetLowestGrade()
        {
            double lowestGrade = double.MaxValue;
            foreach (var number in grades)
            {
                if (number < lowestGrade)
                {
                    lowestGrade = number;
                }
            }
            return lowestGrade;
        }
        public char GetLetterGrade()
        {
            char letterGrade;

            switch (GetAverage())
            {
                case var d when d >= 90.0:
                    letterGrade = 'A';
                    break;
                case var d when d >= 80.0:
                    letterGrade = 'B';
                    break;
                case var d when d >= 70.0:
                    letterGrade = 'C';
                    break;
                case var d when d >= 60.0:
                    letterGrade = 'D';
                    break;
                default:
                    letterGrade = 'F';
                    break;
            }

            return letterGrade;
        }
        public void ShowStatistics()
        {
            var result = GetStatistics();
            Console.WriteLine($"Information about {GetName()}:");
            Console.Write("Grades: ");
            for (int i = 0; i < grades.Count(); i++)
            {
                if (i == (grades.Count - 1))
                {
                    Console.Write($"{grades[i]} ");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Write($"{grades[i]}, ");
                }
            }
            Console.WriteLine($"Sum: {GetSum():N2} Average: {result.Average:N2}");
            Console.WriteLine($"Highest grade: {result.Highest:N2} Lowest grade: {result.Lowest:N2}");
            Console.WriteLine($"Letter grade: {result.Letter}");
        }
        public Statistics GetStatistics()
        {
            Statistics statistics = new Statistics();
            statistics.Average = GetAverage();
            statistics.Highest = GetHighestGrade();
            statistics.Lowest = GetLowestGrade();
            statistics.Letter = GetLetterGrade();

            return statistics;
        }
    }
}