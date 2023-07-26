using System;
using System.Collections.Generic;
using System.IO;

namespace Project2
{
    class Student
    {
        public string Name { get; set; }
        public string Class { get; set; }
    }

    class Program
    {
        static List<Student> ReadStudentData(string filePath)
        {
            List<Student> students = new List<Student>();

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                foreach (string line in lines)
                {
                    string[] data = line.Split(',');
                    if (data.Length == 2)
                    {
                        Student student = new Student
                        {
                            Name = data[0].Trim(),
                            Class = data[1].Trim()
                        };
                        students.Add(student);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading student data: " + ex.Message);
            }

            return students;
        }

        static List<Student> SearchStudents(List<Student> students, string searchName)
        {
            return students.FindAll(s => s.Name.Equals(searchName, StringComparison.OrdinalIgnoreCase));
        }

        static void DisplayStudents(List<Student> students)
        {
            foreach (Student student in students)
            {
                Console.WriteLine($"Name: {student.Name}, Class: {student.Class}");
            }

        }
        static void Main()
        {
            string choice;
            // choice = Console.ReadLine();
            try
            {
                do
                {
                    Console.WriteLine("Enter the file path for student data:");
                    string filePath = Console.ReadLine();


                    List<Student> students = ReadStudentData(filePath);

                    if (students.Count == 0)
                    {
                        Console.WriteLine("No student data found.");
                        return;
                    }

                    // Sort the students by name
                    students.Sort((s1, s2) => s1.Name.CompareTo(s2.Name));

                    Console.WriteLine("Sorted Student Data:");
                    DisplayStudents(students);

                    Console.WriteLine("Do you want Serach Name \n If yes press y \n to exit press any key");
                    // Console.WriteLine("Enter your choice");
                    choice = Console.ReadLine().ToLower();
                    Console.WriteLine("Enter a student name to search:");
                    string searchName = Console.ReadLine();

                    List<Student> searchResults = SearchStudents(students, searchName);

                    if (searchResults.Count == 0)
                    {
                        Console.WriteLine("Student not found.");
                    }
                    else
                    {
                        Console.WriteLine("Search Results:");
                        DisplayStudents(searchResults);
                    }


                    //Console.WriteLine("Enter your choice");

                } while (choice == "y");

            }
            catch (Exception ex)
            {
                Console.WriteLine("No student found");
            }
            Console.ReadKey();
        }



    }

}