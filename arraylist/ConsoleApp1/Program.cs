using System;
using System.Collections;
using System.Collections.Generic;

namespace cavka
{   abstract class Person
    {
        public string name;
        public string surname;
        public Person(string Name,string Surname)
        {
            name = Name; surname = Surname;
        }
    }
    class Student:Person
    {
        public int course;
        public int codebook;
        public Student(string Name, string Surname, int Course, int Codebook)
            :base(Name, Surname)
        {
            course = Course; codebook = Codebook;
        }
    }
    class Aspirant:Person
    {
        public int course;
        public int codebook;
        public string disertation;
        public Aspirant(string Name,string Surname,int Course,int Codebook,string Disertation)
            :base(Name,Surname)
        {
            course = Course; codebook = Codebook; disertation= Disertation;
        }
    }
    class Program
    {
        static ArrayList aspirantlist = new ArrayList();
        static ArrayList studentlist = new ArrayList();
        static void Main()
        {
            Console.Write("If you wanna register as student press - 1 , as aspirant press - 2 : ");
            int press12 = TryPress12();
            switch (press12)
            {
                case 1:
                    {
                        Console.Write("Input name of student : "); string name = Alphabet();
                        Console.Write("Input surname of student : "); string surname = Alphabet();
                        Console.Write("Input course of student : "); int course = TryPress();
                        Console.Write("Input codebook of student : "); int codebook = TryPress();
                        Student student = new Student(name, surname, course, codebook);
                        studentlist.Add(student);
                        break;
                    }
                case 2:
                    {
                        Console.Write("Input name of aspirant : "); string name = Alphabet();
                        Console.Write("Input surname of aspirant : "); string surname = Alphabet();
                        Console.Write("Input course of aspirant : "); int course = TryPress();
                        Console.Write("Input codebook of aspirant : "); int codebook = TryPress();
                        Console.Write("Input disertation of aspirant : "); string disertation = Console.ReadLine();
                        Aspirant aspirant = new Aspirant(name, surname, course, codebook, disertation);
                        aspirantlist.Add(aspirant);
                        break;
                    }
            }
            Console.Write("For continue  press - 1 , for see  users registered list and exit press - 2 : ");
            int menu = TryPress12();
            switch (menu)
            {
                case 1:
                    {
                        Main();
                        break;
                    }
                case 2:
                    {
                        break;
                    }
            }


            bool check = true;

            do
            {
                Console.WriteLine("\n For get student with index press 1:\n For get aspirant with index press 2:\n For exit and get full list press 3:");
                int presskey = TryPress();
                switch (presskey)
                {
                    case 1:
                        {
                            bool checkcase = true;
                            do
                            {
                                Console.Write(" Input index of student : ");
                                int index = TryPress12();
                                if (index >= studentlist.Count) { Console.WriteLine("\nEmpty list,try again!");checkcase = true; }
                                else
                                { 
                                    Student stud = (Student)studentlist[index];
                                    Console.WriteLine( "Student name - {0} , surname - {1} , course - {2} , codebook - {3}",stud.name , stud.surname , stud.course, stud.codebook);
                                    Console.Write("For continue checking press - 1 , for go to menu - 2 : ");
                                    int num = TryPress12();
                                    if (num == 1) { checkcase = true; } else { checkcase = false; }
                                }
                            } while (checkcase == true);
                           break;
                        }
                    case 2:
                        {
                            bool checkcase = true;
                            do
                            {
                                Console.Write("Input index of student : ");
                                int index = TryPress();
                                if (index >= aspirantlist.Count) { Console.WriteLine("\nEmpty list,try again!"); checkcase = false; }
                                else
                                {
                                    Aspirant asp = (Aspirant)aspirantlist[index];
                                    Console.WriteLine("Student name - {0} , surname - {1} , course - {2} , codebook - {3}", asp.name, asp.surname, asp.course, asp.codebook);
                                    Console.Write("For continue checking press - 1 , for go to menu - 2 : ");
                                    int num = TryPress12();
                                    if (num == 1) { checkcase = true; } else { checkcase = false; }
                                }
                            } while (checkcase == true);
                            break;
                        }
                    case 3:
                        {
                            check = false;
                            break;
                        }

                }

            } while (check == true);

          foreach (Aspirant each in aspirantlist)
          {
              Console.Write("\n Your aspirant : ");
              Console.Write("Name of aspirant - " + each.name + ",surname - " + each.surname + ",course - " + each.course + ",codebook - " + each.codebook + ",disertation - " + each.disertation);
          }

          foreach (Student each in studentlist)
          {
              Console.Write("\n Your student : ");
              Console.Write("Name of student - " + each.name + ",surname - " + each.surname + ",course - " + each.course + ",codebook - " + each.codebook);
          }

        }
        public static int TryPress12()
        {
            int presskey=0;
            if(int.TryParse(Console.ReadLine(),out presskey))
            { if (presskey == 1) { return presskey; } else if (presskey == 2) { return presskey; } else { Console.WriteLine("Wrong input try again!"); return TryPress12(); } }
            else { Console.WriteLine("Wrong input try again!");return TryPress12(); }
        }
        public static int TryPress()
        {
            int presskey = 0;
            if (int.TryParse(Console.ReadLine(), out presskey)) { return presskey;}
            else { Console.WriteLine("Wrong input try again!"); return TryPress12(); }
        }
        public static string Alphabet()
        {
            string x;
            bool check = true;
            do
            {
                x = Console.ReadLine();
                foreach (char i in x)
                {

                    if (i < '0' || i > '9')
                    {
                        foreach (char a in "the quick brown fox jumps over the lazy dog THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG")
                        {
                            if (a == i) { check = true; break; }
                            else { check = false; }
                        }
                    }
                    else { Console.WriteLine("Wrong name input again!"); check = false; break; }
                    if (check == false) { Console.WriteLine("Wrong name input again!"); break; }
                }
            } while (check == false);
            return x;
        }

    }
}