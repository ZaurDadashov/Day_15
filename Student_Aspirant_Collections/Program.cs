using System;
using System.Collections;

namespace Student_Aspirant_Collections
{
    abstract class Person
    {
        public string Surname { get; set; }
        public override int GetHashCode()
        {
            return Surname.GetHashCode();
        }
        public int CourseOfStudy { get; set; }
        public int GradeBookNumber { get; set; }
        public ArrayList list = new ArrayList();
        public abstract void Print();
        public abstract ArrayList Add();
        public abstract void Lentgh();
        public abstract ArrayList Sort();
        public abstract void Delete();
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
        public override ArrayList Add()
        {
            Console.Write($"Enter surname: ");
            Surname = Input();
            Console.Write($"Enter cours of study: ");
            CourseOfStudy = InputDigits();
            GradeBookNumber = Math.Abs(GetHashCode());
            list.Add($"Surname: {Surname} / Course of study: {CourseOfStudy} / Grade book number: {GradeBookNumber}");
            return list;
        }
        public override void Lentgh()
        {
            Console.WriteLine(list.Count);
        }
        public override ArrayList Sort()
        {
            list.Sort();
            return list;
        }
        public override void Print()
        {
            foreach (object student in list)
            {
                Console.WriteLine(student);
            }
        }
        public override void Delete()
        {
            byte index;
            for (; ; )
            {
                Console.Write("Please enter index: ");
                if (!byte.TryParse(Console.ReadLine(), out index) || index >= list.Count) { Console.WriteLine("Invalid input. There isn't this index !"); }
                else break;
            }
            list.RemoveAt(index);
        }
    }
    class Aspirant : Person
    {
        public string Subject { get; set; }
        public override ArrayList Add()
        {
            Console.Write($"Enter surname: ");
            Surname = Input();
            Console.Write($"Enter cours of study: ");
            CourseOfStudy = InputDigits();
            GradeBookNumber = Math.Abs(GetHashCode());
            Console.Write($"Enter subject: ");
            Subject = Input();
            list.Add($"Surname: {Surname} / Course of study: {CourseOfStudy} / Grade book number: {GradeBookNumber} / Subject: {Subject} ");
            return list;
        }
        public override void Lentgh()
        {
            Console.WriteLine(list.Count);
        }
        public override ArrayList Sort()
        {
            list.Sort();
            return list;
        }

        public override void Print()
        {
            foreach (object student in list)
            {
                Console.WriteLine(student);
            }
        }
        public override void Delete()
        {
            byte index;
            for (; ; )
            {
                Console.Write("Please enter index: ");
                if (!byte.TryParse(Console.ReadLine(), out index) || index >= list.Count) { Console.WriteLine("Invalid input. There isn't this index !"); }
                else break;
            }
            list.RemoveAt(index);
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
                Console.WriteLine("To sort student list enter 7");
                Console.WriteLine("To sort aspirant list enter 8");
                Console.WriteLine("To remove a student by ordinal index, enter 9");
                Console.WriteLine("To remove a aspirant by ordinal index, enter 10");
                Console.WriteLine("To exit the program, enter 0");
                switch (Console.ReadLine())
                {
                    case "1":
                        myListOfStudents.Add();
                        break;
                    case "2":
                        myListOfAspirants.Add();
                        break;
                    case "3":
                        myListOfStudents.Lentgh();
                        break;
                    case "4":
                        myListOfAspirants.Lentgh();
                        break;
                    case "5":
                        myListOfStudents.Print();
                        break;
                    case "6":
                        myListOfAspirants.Print();
                        break;
                    case "7":
                        myListOfStudents.Sort();
                        break;
                    case "8":
                        myListOfAspirants.Sort();
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

