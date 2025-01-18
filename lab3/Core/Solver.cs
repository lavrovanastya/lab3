namespace lab3.Core;

public class Solver
{
    public Solution SolveQuadratic(double a, double b, double c)
    {
        string equation = $"{a} * x^2 + {b} * x + {c} = 0";
        string result = "";

        if (a == 0)
        {
            return SolveLinear(b, c); // Если a == 0, это линейное уравнение
        }

        double discriminant = b * b - 4 * a * c;

        if (discriminant > 0)
        {
            double root1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
            double root2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
            result = $"x1 = {root1}, x2 = {root2}";
        }
        else if (discriminant == 0)
        {
            double root = -b / (2 * a);
            result = $"x = {root}";
        }
        else
        {
            result = "Уравнение не имеет действительных корней.";
        }

        return new Solution(equation, result);
    }

    public Solution SolveLinear(double b, double c)
    {
        string equation = $"{b} * x + {c} = 0";
        string result = "";

        if (b == 0)
        {
            if (c == 0)
            {
                result = "Уравнение имеет бесконечно много решений.";
            }
            else
            {
                result = "Уравнение не имеет решений.";
            }
        }
        else
        {
            double root = -c / b;
            result = $"x = {root}";
        }

        return new Solution(equation, result);
    }
}