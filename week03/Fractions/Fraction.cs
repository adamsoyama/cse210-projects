using System;

public class Fraction
{
    private int _numerator;
    private int _denominator;

    // Constructor with no parameters (default to 1/1)
    public Fraction()
    {
        _numerator = 1;
        _denominator = 1;
    }

    // Constructor with one parameter (numerator), default denominator to 1
    public Fraction(int wholeNumber)
    {
        _numerator = wholeNumber;
        _denominator = 1;
    }
    public Fraction(int numerator, int denominator)
    {
        _numerator = numerator;
        _denominator = denominator != 0 ? denominator : throw new ArgumentException("Denominator cannot be zero.");
    }

    // Method to return fraction as a string 
    public string GetFractionString()
    {
        // Notice that this is not stored as a member variable.
        // Is is just a temporary, local variable that will be recomputed each time this is called.
        string text = $"{_numerator}/{_denominator}";
        return text;
    }

    // Method to return fraction as a decimal
    public double GetDecimalValue()
        {
            return (double) _numerator / _denominator;
        }
}