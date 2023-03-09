//Используя Visual Studio, создайте проект по шаблону Console Application.
//Создайте программу, в которой создайте класс хвост, который содержит в себе поля длину хвоста
//типа int и вид хвоста типа string, создать свойства доступа и конструктор пользовательский
//класса. Создать класс хвостатое животное, содержащий хвост, цвет(строка), возраст. Определить
//public -производный класс собака, имеющий дополнительный параметр-кличку (строка).
//В классе собака создать метод для отображения полной информации о собаке. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _001_task
{
    class Tail
    {
        private int length;
        private string type;
        public int Length
        {
            get { return length; }
            set { length = value; }
        }
        public string Type
        {
            get { return type; }
            set { type = value; }   
        }

        public Tail(int length, string type)
        {
            Length = length;
            Type = type;    
        }

    }
    class TailedAnimal:Tail
    {
        public string Color { get; set; }        
        public int Age{ get; set; }
        public TailedAnimal(string color, int age, string type, int length):base(length, type)
        {
            Age = age;
            Color = color;
        }

    }
    class Dog:TailedAnimal
    {
        public string Name { get; set; }
        public Dog(string name, string color, int age, string type, int length) : base(color, age, type, length)
        {
            Name = name;
        }
        public void ShowInfo()
        {
            Console.WriteLine($"Dog:\nName - {Name}\nColor - {Color}\nAge - {Age}\nType of tail - {Type}\nLength of tail - {Length}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog("Dog", "Brown", 12, "Straigth", 13);
            dog.ShowInfo();
        }
    }
}
