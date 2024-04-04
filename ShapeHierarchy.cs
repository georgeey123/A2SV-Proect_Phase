using System;

//Base Class
class Shape {
    public string Name {get; set;}

    public virtual double CalculateArea()
    {
        return 0;
    }
}

class Circle : Shape {
    private double PI = Math.PI;
    public double Radius{get; set;}

    public override double CalculateArea()
    {

        return PI *Radius * Radius;
    }
}

class Rectangle : Shape {
    public double Width {get; set;}
    public double Height { get; set;}

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

class Triangle : Shape {
    public double Base {get; set;}
    public double Height {get; set;}

    public override double CalculateArea()
    {
        return (Base*Height)/2;
    }

}
class ShapeHierarchy {
    static void PrintShapeArea(Shape shape){
        Console.WriteLine($"Name: {shape.Name}, Area: {shape.CalculateArea()}");
    }
    static void Main(string[] args)
    {
        Circle circle = new Circle {Name = "Circle", Radius= 5};
        Rectangle rectangle = new Rectangle {Name = "rectangle", Width = 10, Height = 2};
        Triangle triangle = new Triangle {Name = "triangle", Base = 10, Height = 3};

        PrintShapeArea(circle);
        PrintShapeArea(rectangle);
        PrintShapeArea(triangle);
    }
}
