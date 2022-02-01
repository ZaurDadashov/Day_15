using System;
using System.Collections;

namespace Student_Aspirant_Collections
{
    abstract class Person
    {
        public string Surname { get; set; }
        public int CourseOfStudy { get; set; }
        public int GradeBookNumber { get; set; }
        public abstract void Print();
        public abstract Person[] Add();
        public abstract void DisplayByOrdinalIndex(byte index);
        public abstract void Delete();
        public Person() { }
        public Person(string surname, int courseOfStudy, int gradeBookNumber)
        {
            Surname = surname;
            CourseOfStudy = courseOfStudy;
            GradeBookNumber = gradeBookNumber;
        }
        public string Input()
        {
            for (; ; )
            {
                string input = Console.ReadLine();
                string error = "1234567890-=!@#$%~^&*()_+`|\\,./<>?;':|[]{} ";
                int counter = 0;
                foreach (int i in input)
                {
                    int temp = i;
                    foreach (int j in error)
                    {
                        if (temp == j)
                            counter++;
                    }
                }
                if (counter == 0 && input != "")
                {
                    return input;
                }
                else
                    Console.WriteLine("Invalid input.Please try again!");
            }
        }
        public static int InputDigits()
        {
            int digits = 0;
            for (; ; )
            {
                if (!int.TryParse(Console.ReadLine(), out digits) || digits <= 0 || digits > 4) { Console.WriteLine("Invalid input. Please try again!"); }
                else
                    return digits;
            }
        }
    }
    class Student : Person
    {
        public Student[] data;
        public Student()
        {
            data = new Student[0];
        }
        public void LentghOfData()
        {
            int counter = 0;
            foreach (var student in data)
            {
                if (student == null)
                {
                    counter++;
                }
            }
            Console.WriteLine($"The count is {data.Length - counter}");
        }
        public Student this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public override Person[] Add()
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = new Student();
            Console.Write($"Enter surname: ");
            data[data.Length - 1].Surname = Input();
            Console.Write($"Enter cours of study: ");
            data[data.Length - 1].CourseOfStudy = InputDigits();
            data[data.Length - 1].GradeBookNumber = Math.Abs(GetHashCode());
            return data;
        }
        public override void Print()
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == null) continue;
                Console.Write($"\nSurname: {data[i].Surname} / ");
                Console.Write($"Course of study: {data[i].CourseOfStudy} / ");
                Console.Write($"Gradebook number: {Math.Abs(data[i].GetHashCode())}");
            }
        }
        public override void DisplayByOrdinalIndex(byte index)
        {
            Console.Write($"Surname: {data[index].Surname} / ");
            Console.Write($"Course of study: {data[index].CourseOfStudy} / ");
            Console.Write($"Gradebook number: {Math.Abs(data[index].GetHashCode())}");
        }
        public override void Delete()
        {
            byte index;
            for (; ; )
            {
                Console.Write("Please enter index: ");
                if (!byte.TryParse(Console.ReadLine(), out index) || index > data.Length - 1) { Console.WriteLine("Invalid input. There isn't this index !"); }
                else break;
            }
            data[index] = null;
        }
        public byte InputIndex()
        {
            byte index = 0;
            for (; ; )
            {
                Console.Write("Please enter index: ");
                if (!byte.TryParse(Console.ReadLine(), out index) || index > data.Length - 1 || data[index] == null) { Console.WriteLine("Invalid input. There isn't this index !"); }
                else break;
            }
            return index;
        }
    }
    class Aspirant : Person
    {
        public string Subject { get; set; }
        public Aspirant[] data;
        public Aspirant()
        {
            data = new Aspirant[0];
        }
        public void LentghOfData()
        {
            int counter = 0;
            foreach (var aspirant in data)
            {
                if (aspirant == null)
                {
                    counter++;
                }
            }
            Console.WriteLine($"The count is {data.Length - counter}");
        }
        public Aspirant this[int index]
        {
            get
            {
                return data[index];
            }
            set
            {
                data[index] = value;
            }
        }
        public override Person[] Add()
        {
            Array.Resize(ref data, data.Length + 1);
            data[data.Length - 1] = new Aspirant();
            Console.Write($"Enter surname: ");
            data[data.Length - 1].Surname = Input();
            Console.Write($"Enter cours of study: ");
            data[data.Length - 1].CourseOfStudy = InputDigits();
            Console.Write($"Enter subject: ");
            data[data.Length - 1].Subject = Input();
            return data;
        }
        public override void Print()
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] == null) continue;
                Console.Write($"\nSurname: {data[i].Surname} / ");
                Console.Write($"Course of study: {data[i].CourseOfStudy} / ");
                Console.Write($"Gradebook number: {Math.Abs(data[i].GetHashCode())} / ");
                Console.WriteLine($"Subject: {data[i].Subject}");
            }
        }
        public override void DisplayByOrdinalIndex(byte index)
        {
            Console.Write($"Surname: {data[index].Surname} / ");
            Console.Write($"Course of study: {data[index].CourseOfStudy} / ");
            Console.Write($"Gradebook number: {Math.Abs(data[index].GetHashCode())}");
            Console.Write($" / Subject: {(data[index].Subject)}");
        }
        public override void Delete()
        {
            byte index;
            for (; ; )
            {
                Console.Write("Please enter index: ");
                if (!byte.TryParse(Console.ReadLine(), out index) || index > data.Length - 1) { Console.WriteLine("Invalid input. There isn't this index !"); }
                else break;
            }
            data[index] = null;
        }
        public byte InputIndex()
        {
            byte index = 0;
            for (; ; )
            {
                Console.Write("Please enter index: ");
                if (!byte.TryParse(Console.ReadLine(), out index) || index > data.Length - 1 || data[index] == null) { Console.WriteLine("Invalid input. There isn't this index !"); }
                else break;
            }
            return index;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This program for creating the list of the your students and aspirants informations !");
            Student myListOfStudents = new Student();
            Aspirant myListOfAspirants = new Aspirant();
            bool exit = false;
            for (; ; )
            {
                if (exit) break;
                Console.WriteLine("\nTo add student to the list, enter 1");
                Console.WriteLine("To add aspirant to the list, enter 2");
                Console.WriteLine("To display the count of students, enter 3");
                Console.WriteLine("To display the count of aspirants, enter 4");
                Console.WriteLine("To display the list all students, enter 5");
                Console.WriteLine("To display the list all aspirants, enter 6");
                Console.WriteLine("To display student by ordinal index, enter 7");
                Console.WriteLine("To display aspirant by ordinal index, enter 8");
                Console.WriteLine("To remove a student by ordinal index, enter 9");
                Console.WriteLine("To remove a aspirant by ordinal index, enter 10");
                Console.WriteLine("To exit the program, enter 0");
                switch (Console.ReadLine())
                {
                    case "1":
                        ArrayList studentList = new ArrayList();
                        studentList.AddRange(myListOfStudents.Add());
                        foreach (Student student in studentList)
                        {
                            Console.WriteLine(student.Surname);
                            Console.WriteLine(student.CourseOfStudy);
                            Console.WriteLine(student.GradeBookNumber);
                        }

                        break;
                    case "2":
                        myListOfAspirants.Add();
                        break;
                    case "3":
                        myListOfStudents.LentghOfData();
                        break;
                    case "4":
                        myListOfAspirants.LentghOfData();
                        break;
                    case "5":
                        myListOfStudents.Print();
                        break;
                    case "6":
                        myListOfAspirants.Print();

                        break;
                    case "7":
                        myListOfStudents.DisplayByOrdinalIndex(myListOfStudents.InputIndex());
                        break;
                    case "8":
                        myListOfAspirants.DisplayByOrdinalIndex(myListOfAspirants.InputIndex());
                        break;
                    case "9":
                        myListOfStudents.Delete();
                        break;
                    case "10":
                        myListOfAspirants.Delete();
                        break;
                    case "0":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("There is not this option!");
                        break;
                }
            }
            Console.ReadKey();
        }
    }
}
