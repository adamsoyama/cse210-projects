public abstract class Shape
{
    private string color;

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public Shape(string color)
    {
        this.color = color;
    }

    // Virtual method for GetArea()
    public virtual double GetArea()
    {
        return 0; // Default implementation (can be overridden)
    }
}
