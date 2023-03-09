//Используя Visual Studio, создайте проект по шаблону Console Application.
//Требуется: Создать класс, представляющий учебный класс ClassRoom. Создайте класс ученик
//Pupil. В теле класса создайте методы void Study(), void Read(), void Write(), void Relax(). Создайте 3
//производных класса ExcelentPupil, GoodPupil, BadPupil от класса базового класса Pupil и
//переопределите каждый из методов, в зависимости от успеваемости ученика. Конструктор
//класса ClassRoom принимает аргументы типа Pupil, класс должен состоять из 4 учеников.
//Предусмотрите возможность того, что пользователь может передать 2 или 3 аргумента. Выведите
//информацию о том, как все ученики экземпляра класса ClassRoom умеют учиться, читать, писать,
//отдыхать. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_task
{
    class ClassRoom
    {
        Pupil[] students = new Pupil[4];
        public ClassRoom(params Pupil[] pupils)
        {
            for (int i = 0; i < pupils.Length; i++)
            {
                students[i] = pupils[i];
            }

        }
        public void ShowInfo()
        {
            for(int i = 0; i < students.Length;i++) 
            {
                students[i].Study();
                students[i].Write();
                students[i].Read();
                students[i].Relax();
                Console.WriteLine();
            }

        }
    }
    class Pupil
    {
        public virtual void Study()
        {
        }
        public virtual void Read()
        {
        }
        public virtual void Write()
        { 
        } 
        public virtual void Relax()
        {
        }
    }
    class ExcelentPupil : Pupil 
    {
        public override void Study() 
        {
            Console.WriteLine("Excelent studying skills");
        }
        public override void Read()
        {
            Console.WriteLine("Excelent reading skills");
        }
        public override void Write()
        {
            Console.WriteLine("Excelent writing skills");
        }
        public override void Relax()
        {
            Console.WriteLine("No time for relax");
        }
    }
    class GoodPupil:Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Good studying skills");
        }
        public override void Read()
        {
            Console.WriteLine("Good reading skills");
        }
        public override void Write()
        {
            Console.WriteLine("Good writing skills");
        }
        public override void Relax()
        {
            Console.WriteLine("Some time for relax");
        }
    }
    class BadPupil:Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Bad studying skills");
        }
        public override void Read()
        {
            Console.WriteLine("Bad reading skills");
        }
        public override void Write()
        {
            Console.WriteLine("Bad writing skills");
        }
        public override void Relax()
        {
            Console.WriteLine("Always on chill");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            BadPupil badPupil = new BadPupil(); 
            GoodPupil goodPupil = new GoodPupil();
            ExcelentPupil excelentPupil = new ExcelentPupil();
            ClassRoom classRoom = new ClassRoom(badPupil,goodPupil, excelentPupil, excelentPupil);
            classRoom.ShowInfo();
        }
    }
}
