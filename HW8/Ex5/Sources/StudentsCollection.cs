using System.Collections.Generic;

namespace Ex5
{
    public class StudentsCollection
    {
        private List<Student> _students;

        public StudentsCollection()
        {
        }

        public StudentsCollection(List<Student> students)
        {
            _students = students;
        }

        public List<Student> Students
        {
            get => _students;
            set => _students = value;
        }
    }
}