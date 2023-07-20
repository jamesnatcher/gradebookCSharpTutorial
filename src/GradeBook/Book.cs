namespace GradeBook
{
    public class Book
    {
        private List<double> grades;
        public string Name;

        public Book(string name)
        {
            grades = new List<double>();
            this.Name = name;
        }
        public Book()
        {
            grades = new List<double>();
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
        public void AddGrade(double grade)
        {
            if (grade >= 0 && grade <= 100)
            {
                grades.Add(grade);
            }
        }
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
        public void ShowStatistics()
        {

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
            Console.WriteLine($"Sum: {GetSum():N2} Average: {GetAverage():N2}");
            Console.WriteLine($"Highest grade: {GetHighestGrade():N2} Lowest grade: {GetLowestGrade():N2}");
        }
        public Statistics GetStatistics()
        {
            Statistics statistics = new Statistics();
            statistics.Average = GetAverage();
            statistics.Highest = GetHighestGrade();
            statistics.Lowest = GetLowestGrade();

            return statistics;
        }
    }
}