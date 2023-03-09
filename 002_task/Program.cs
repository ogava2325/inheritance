//Используя Visual Studio, создайте проект по шаблону Console Application.
//Создайте программу, в которой создайте базовый класс Shape (фигура), который содержит в себе
//поле типа double c именем Volume и метод типа double GetVolume() который должен вернуть
//объём фигуры. Далее создайте классы: Pyramid(пирамида), Cylinder(цилиндр), Ball(шар),
//которые будут наследоваться от класса Shape, реализуйте в каждом из них метод для
//нахождения объёма. Создайте класс Box (ящик) – он является контейнером, может содержать в
//себе другие фигуры. В классе Box создайте поле типа double с именем DrawerVolume (Объем
//ящика), поле должно хранить в себе объём ящика. Далее в классе Box создайте метод Аdd(),
//который принимает на вход объекты типа Shape, и возвращает значение типа boll. В классе Box
//реализуйте логику для добавления новых фигуры до тех пор, пока для них хватает места в Box
//(будем считать только объём, игнорируя форму, например, мы переливаем жидкость). Если
//места для добавления новой фигуры не хватает, то метод должен вернуть false. 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _002_task
{
    class Shape
    {
        public virtual double GetVolume()
        {
            return 0;
        }
        public double Volume { get; set; }
    }
    class Pyramide : Shape
    {
        private double a;
        private double b;   
        private double heigth;
        public Pyramide(double a, double b, double heigth)
        {
            this.a = a;
            this.b = b; 
            this.heigth = heigth;   
        }
        public override double GetVolume() 
        {
            Volume = (a * b * heigth) / 3;
            return Volume;
        }
    }
    class Ball : Shape
    {
        private double radius;
        public Ball (double radius)
        {
            this.radius = radius;  
        }
        public override double GetVolume()
        {
            Volume = (4 * Math.PI * Math.Pow(radius ,3)) / 3;
            return Volume;
        }
    }
    class Cylinder : Shape
    {
        private double radius;
        private double heigth;
        public Cylinder(double heigth, double radius)
        {
            this.radius = radius;
            this.heigth = heigth;
        }
        public override double GetVolume()
        {
            Volume = Math.PI * Math.Pow(radius ,2); 
            return Volume;
        }
    }
    class Drawer
    {
        private double DrawerSize;
        private double DrawerVolume;
        public Drawer(double size)
        {
            DrawerSize = size;
            DrawerVolume = 0;
        }
        public void Add(Shape shape)
        {
            if((shape.GetVolume() + DrawerVolume) <= DrawerSize)
            {
                DrawerVolume += shape.GetVolume();
            }
            else Console.WriteLine("Drawer is full");
        }
        public void ShowFreeSpace()
        {
            Console.WriteLine($"Free space is {DrawerSize - DrawerVolume}");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Pyramide pyramide = new Pyramide(2, 2, 3);
            Ball ball = new Ball(3);
            Cylinder cylinder = new Cylinder(2, 3);
            Drawer drawer = new Drawer(1000);
            drawer.Add(pyramide);
            drawer.Add(ball);
            drawer.Add(cylinder);
            drawer.ShowFreeSpace();
        }
    }
}
