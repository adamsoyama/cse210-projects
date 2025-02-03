using System;

class Program
{
    static void Main(string[] args)
    {
        //Create fractions using different constructors
        Fraction f1 = new Fraction(1); //1/1
        Fraction f2 = new Fraction(5); // 5/1
        Fraction f3 = new Fraction(3, 4); //3/4
        Fraction f4 = new Fraction(1, 3); //1/3

        // Dispolay fractions and their decimal values 
        Console.WriteLine($"Fraction 1:  {f1.GetFractionString()}");
        Console.WriteLine($"Decimal Value 1: {f1.GetDecimalValue()}");
        
        Console.WriteLine($"Fraction 2:  {f2.GetFractionString()}");
        Console.WriteLine($"Decimal Value 3: {f2.GetDecimalValue()}");

        Console.WriteLine($"Fraction 3:  {f3.GetFractionString()}");
        Console.WriteLine($"Decimal Value 3: {f3.GetDecimalValue()}");

        Console.WriteLine($"Fraction 4:  {f4.GetFractionString()}");
        Console.WriteLine($"Decimal Value 4: {f4.GetDecimalValue()}");
    }
}