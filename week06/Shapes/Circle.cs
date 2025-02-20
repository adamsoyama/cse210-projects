public class Circle : Shape
{
    private double radius;

    public double Radius
    {
        get { return radius; }
        set { radius = value; }
    }

    public Circle(string color, double radius) : base(color)
    {
        this.radius = radius;
    }

    // Override the GetArea() method
    public override double GetArea()
    {
        return Math.PI * radius * radius;
    }
}
