public class Rectangle : Shape
{
    private double width;
    private double height;

    public double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Height
    {
        get { return height; }
        set { height = value; }
    }

    public Rectangle(string color, double width, double height) : base(color)
    {
        this.width = width;
        this.height = height;
    }

    // Override the GetArea() method
    public override double GetArea()
    {
        return width * height;
    }
}
