using static System.Console;
using System.Collections.Generic;
using static System.Environment;
using static System.IO.Path;
using System.Xml.Serialization;
//create a list of Shapes to serialize
var listOfShapes = new List<Shape>
{
    new Circle {Colour = "Red", Radius = 2.5},
    new Rectangle {Colour = "Blue", Height = 20.0, Width = 10.0},
    new Circle {Colour = "Green", Radius = 8.0},
    new Circle {Colour = "Purple", Radius = 12.3},
    new Rectangle {Colour = "Blue", Height = 45.0, Width = 18.0}
};
foreach (Shape shape in listOfShapes)
{
    if (shape.GetType().Name == "Circle")
        {
            shape.Area = shape.Radius * shape.Radius * Math.PI;
        }
        if (shape.GetType().Name == "Rectangle")
        {
            shape.Area = shape.Height * shape.Width;
        }
}
var serializerXml = new XmlSerializer(typeof(List<Shape>));
string path = Combine(CurrentDirectory, "shapes.xml");
using (FileStream stream = File.Create(path))
{
    serializerXml.Serialize(stream, listOfShapes);
    WriteLine($"Wrote {new FileInfo(path).Length} bytes to XML.");
}


using (FileStream fileXml = File.Open(path, FileMode.Open))
{
    List<Shape> loadedShapesXml = serializerXml.Deserialize(fileXml) as List<Shape>;
    WriteLine("Loading shapes from XML.");
    foreach (Shape item in loadedShapesXml)
    {
        WriteLine($"{item.GetType().Name} is {item.Colour} and has an area of {item.Area:N2}");
    }
}

[XmlInclude(typeof(Circle)), XmlInclude(typeof(Rectangle)), XmlInclude(typeof(Shape))]
public class Shape
{
    public string Colour { get; set; }
    public double Area {get; set;}
    public double Radius;
    public double Height;
    public double Width;
}
public class Circle : Shape
{

}
public class Rectangle : Shape
{
    

}
