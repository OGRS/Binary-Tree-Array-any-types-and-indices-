using System;

namespace Hrab_2.Classes
{
    /// <summary>
    /// Represents a student data store,such as first name, last name and evaluation
    /// </summary>
    public class Student : IComparable<Student>
    {
        public string first_name { get; private set; }
        public string last_name { get; private set; }
        public int rating { get; private set; }

        public Student(int evaluation, string first_name, string last_name)
        {
            this.rating = evaluation;
            this.first_name = first_name;
            this.last_name = last_name;
        }

        public int CompareTo(Student second)
        {
            if (rating > second.rating) return 1;
            else if (rating < second.rating) return -1;
            else return 0;
        }

        public override string ToString()
        {
            return $"\nFirst name: {first_name};\n" +
                $"Second name: {last_name};\n" +
                $"Rating: {rating};\n";
        }
    }
}
