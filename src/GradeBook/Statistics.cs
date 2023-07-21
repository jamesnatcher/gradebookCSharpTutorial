namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return Sum / TotalGrades;
            }
        }
        public double Sum;
        public int TotalGrades;
        public double Highest;
        public double Lowest;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        public Statistics()
        {
            Sum = 0.0;
            TotalGrades = 0;
            Highest = double.MinValue;
            Lowest = double.MaxValue;
        }

        public void AddGrade(double grade)
        {
            TotalGrades += 1;
            Sum += grade;
            Lowest = Math.Min(Lowest, grade);
            Highest = Math.Max(Highest, grade);
        }

        public static void ShowStatistics(Statistics result)
        {
            if (result.Sum <= 0)
            {
                return;
            }
            Console.WriteLine($"Sum: {result.Sum:N2} Average: {result.Average:N2}");
            Console.WriteLine($"Highest grade: {result.Highest:N2} Lowest grade: {result.Lowest:N2}");
            Console.WriteLine($"Letter grade: {result.Letter}");
        }

    }
}