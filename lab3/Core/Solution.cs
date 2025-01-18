namespace lab3.Core;

public class Solution
{
    public int ID { get; set; }
    public string Equation { get; set; }
    public string Result { get; set; }

    public Solution(string equation, string result)
    {
        Equation = equation;
        Result = result;
    }
        
    public string ToSolutionString()
    {
        return $"#{ID}: {Equation}  Решение: {Result}";
    }
}