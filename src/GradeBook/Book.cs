using System.IO;

namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class NameObject
    {
        public string Name
        {
            get;
            set;
            // private set;         Use this when you want to allow inital setting but not further modifications.
        }

        public NameObject(string name)
        {
            Name = name;
        }

        public NameObject()
        {
            Name = "New Object";
        }
    }

    public interface IBook
    {
        void AddGrade(double grade);
        Statistics GetStatistics();
        string Name { get; }
        event GradeAddedDelegate GradeAdded;
    }

    public abstract class Book : NameObject, IBook
    {
        protected Book(string name) : base(name)
        {
        }

        public abstract event GradeAddedDelegate GradeAdded;

        public abstract void AddGrade(double grade);

        public abstract Statistics GetStatistics();
    }


    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name)
        {
            Name = name.Replace(" ", "");
        }

        public override event GradeAddedDelegate? GradeAdded;

        public override void AddGrade(double grade)
        {
            // Disposes and cleans up after leaving this scope
            using (var writer = File.AppendText($"{Name}.txt"))
            {
                writer.WriteLine(grade);
                if (GradeAdded != null){
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            Statistics result = new Statistics();
            string[] reader = File.ReadAllLines($"{Name}.txt");

            foreach (var grade in reader)
            {
                result.AddGrade(double.Parse(grade));
            }

            return result;
        }
    }

    public class InMemoryBook : Book
    {
        private List<double> grades;

        readonly string category = "Science"; // Can be changed only in constructure
        const string category2 = "Science"; // Cannot be changed at all

        public InMemoryBook(string name) : base(name)
        {
            grades = new List<double>();
            Name = name;
        }
        public string GetName()
        {
            return Name;
        }
        public void SetName(string name)
        {
            Name = name;
        }
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    grades.Add(90);
                    break;
                case 'B':
                    grades.Add(80);

                    break;
                case 'C':
                    grades.Add(70);

                    break;
                case 'F':
                    grades.Add(0);
                    break;
                default:
                    throw new ArgumentException($"Invalid {nameof(letter)}");
            }
        }
        public override void AddGrade(double grade)
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
        public override event GradeAddedDelegate? GradeAdded;

        public override Statistics GetStatistics()
        {
            Statistics statistics = new Statistics();
            
            foreach (var grade in grades)
            {
                statistics.AddGrade(grade);
            }
            return statistics;
        }
    }
}