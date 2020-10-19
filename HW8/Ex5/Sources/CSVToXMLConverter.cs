/*
 * Вячеслав Индорил
 * Задача 5
    **Написать программу-преобразователь из CSV в XML-файл с информацией о студентах (6 урок).
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Ex5
{
    class CSVToXMLConverter
    {
        private const string FileName = "../../students.csv";
        private const string NewFileName = "../../students.xml";
        
        private static List<Student> _students;
        
        static void Main(string[] args)
        {
            ParseStudents();
            SaveAsXML();
        }
        
        private static void ParseStudents()
        {
            try
            {
                FileStream fileStream = new FileStream(FileName, FileMode.Open);
                StreamReader streamReader = new StreamReader(fileStream);
                
                _students = new List<Student>();
                while (!streamReader.EndOfStream)
                {
                    string[] line = streamReader.ReadLine().Split(" ");
                    Student student = new Student(line[1], line[0],
                        line[2], line[3], line[4],
                        int.Parse(line[5]), int.Parse(line[8]),
                        int.Parse(line[6]), line[7]);
                    _students.Add(student);
                }

                streamReader.Close();
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private static void SaveAsXML()
        {
            try
            {
                StudentsCollection studentsCollection = new StudentsCollection(_students);
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(StudentsCollection));
                FileStream fileStream = new FileStream(NewFileName, FileMode.Create);
                xmlSerializer.Serialize(fileStream, studentsCollection);
                fileStream.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }

   
}