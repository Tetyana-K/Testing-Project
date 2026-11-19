namespace CalculatorNS;
public  class Calculator
{
    public  int Add(int num1, int num2) => num1  + num2;
    public  int Sub(int num1, int num2) => num1 - num2;
    public int Mult (int num1, int num2) => num1 * num2;
    public int Div(int num1, int num2) =>
        num2 != 0
        ? num1 / num2
        : throw new DivideByZeroException("Ділення на нуль");
        //: throw new ArgumentOutOfRangeException("Ділення на нуль");

    public int Pow(int num, int deg) => (int)Math.Pow(num, deg);
}
