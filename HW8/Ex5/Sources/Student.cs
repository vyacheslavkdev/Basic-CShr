using System;

namespace Ex5
{
    [Serializable]
    public class Student
    {
        private string _lastName;
        private string _firstName;
        private string _university;
        private string _faculty;
        private int _course;
        private string _department;
        private int _group;
        private string _city;
        private int _age;

        public Student()
        {
        }

        public Student(
            string firstName, string lastName, string university, string faculty,
            string department, int course, int age, int group, string city)
        {
            _lastName = lastName;
            _firstName = firstName;
            _university = university;
            _faculty = faculty;
            _department = department;
            _course = course;
            _age = age;
            _group = group;
            _city = city;
        }

        public string LastName
        {
            get => _lastName;
            set => _lastName = value;
        }

        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }

        public string University
        {
            get => _university;
            set => _university = value;
        }

        public string Faculty
        {
            get => _faculty;
            set => _faculty = value;
        }

        public int Course
        {
            get => _course;
            set => _course = value;
        }

        public string Department
        {
            get => _department;
            set => _department = value;
        }

        public int Group
        {
            get => _group;
            set => _group = value;
        }

        public string City
        {
            get => _city;
            set => _city = value;
        }

        public int Age
        {
            get => _age;
            set => _age = value;
        }
    }
}