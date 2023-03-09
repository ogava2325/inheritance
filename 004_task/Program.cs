//Используя Visual Studio, создайте проект по шаблону Console Application.
//Создайте программу, в которой создайте базовый класс Person (человек), в классе создайте поле
//типа int с именем BirthYear (год рождения), поле типа string с именем Name и поле типа
//string с именем Surname. Далее создайте классы Student (студент), Teacher(преподаватель).В
//классе Student добавьте поле типа string[] с именем Study Courses (изучаемые курсы), свойство
//(не авто свойство) для добавления(set) и получения(get) изучаемых курсов и метод
//DisplayStudyСourses() с возвращаемым значением void который будет выводить на консоль все
//предметы, максимальное количество изучаемых курсов = 3. В классе преподаватель создать поле
//типа Student[] с именем StudentsArray, и свойство (не авто свойство) для добавления(set) и
//получения(get) студентов.Создайте 5 экземпляров класса типа Student и инициализируйте их
//произвольными значениями, и 2 экземпляра класса типа Teacher, инициализируйте их
//произвольными значениями (для инициализации поля StudentsArray используйте уже созданные
//экземпляры Student). Далее создайте класс PeopleInfo, в нем создайте поле типа Person[] с
//именем PeopleArray и свойство (не авто свойство) для добавления(set) и получения(get) людей и
//метод который будет выводить всех людей который есть в поле PeopleInfo в порядке возрастания
//возраста.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _004_task
{
    class Person
    {
        public int BirthYear { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
    }
    class Student:Person
    {
        protected string[] Courses;
        public void SetCourses(string[] courses)
        {
            Courses = courses;  
        }
        public void GetCourses()
        {
            for(int i = 0; i < Courses.Length; i++)
            {
                Console.Write(Courses[i] + " ");
            }                
        }
    }
    class Teacher : Person
    {
        private Student[] StudenArray = new Student[5];
        public void SetStudents(params Student[] students)
        {
            for(int i = 0; i < students.Length; i++) 
            {
                StudenArray[i] = students[i];   
            }
        }
        public void GetStudents() 
        {
            int i = 0;
            while (StudenArray[i] != null)
            {
                Console.Write(StudenArray[i] + " ");
                i++;
            }
        }
    }
    class PeopleInfo
    {
        private Person[] Persons;
        public void SetPersons(params Person[] persons)
        {
            Persons = persons;
        }
        static void Swap(ref Person e1, ref Person e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        private Person[] BubbleSort(Person[] array)
        {
            var len = array.Length;
            for (var i = 1; i < len; i++)
            {
                for (var j = 0; j < len - i; j++)
                {
                    if (array[j].BirthYear > array[j + 1].BirthYear)
                    {
                        Swap(ref array[j],ref array[j + 1]);
                    }
                }
            }
            return array;
        }
        public void ShowInfo()
        {
            BubbleSort(Persons);
            for(int i = 0; i < Persons.Length;i++)
            {
                Console.Write(Persons[i].Name + " ");
                Console.Write(Persons[i].Surname + " ");
                Console.Write(Persons[i].BirthYear + " ");
                Console.WriteLine();

            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] courses = { "C#", "c++", "Java" };
            Student student0 = new Student();
            Student student1 = new Student();
            Student student2 = new Student();   
            Student student3 = new Student();
            Student student4 = new Student();
            student4.SetCourses(courses);
            student4.Surname = "Fourth";
            student4.Name = "4";
            student4.BirthYear = 2004;

            student3.SetCourses(courses);
            student3.Surname = "Third";
            student3.Name = "3";
            student3.BirthYear = 2003;

            student2.SetCourses(courses);
            student2.Surname = "Second";
            student2.Name = "2";
            student2.BirthYear = 2002;

            student1.SetCourses(courses);
            student1.Surname = "First";
            student1.Name = "1";
            student1.BirthYear = 2001;

            student0.SetCourses(courses);
            student0.Surname = "Zero";
            student0.Name = "0";
            student0.BirthYear = 2000;

            Teacher teacher0 = new Teacher();
            teacher0.Name = "Valya";
            teacher0.Surname = "valik";
            teacher0.BirthYear = 1978;
            teacher0.SetStudents(student4, student3, student2);

            Teacher teacher1 = new Teacher();
            teacher1.Name = "Nadya";
            teacher1.Surname = "good";
            teacher1.BirthYear = 1974;
            teacher1.SetStudents(student1, student0);

            PeopleInfo peopleInfo = new PeopleInfo();
            peopleInfo.SetPersons(student4, student3, student2, student1, student0, teacher0, teacher1);
            peopleInfo.ShowInfo();
        }
    }
}
