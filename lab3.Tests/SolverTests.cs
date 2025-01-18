using lab3.Core;
using NUnit.Framework;

namespace lab3.Tests;

[TestFixture]
public class SolverTests
{
    private Solver _solver;

    [SetUp]
    public void Setup()
    {
        _solver = new Solver();
    }

    [Test]
    public void SolveQuadratic_ValidRoots_ReturnsCorrectSolution()
    {
        var solution = _solver.SolveQuadratic(1, -3, 2); // x^2 - 3x + 2 = 0
        Assert.AreEqual("1 * x^2 + -3 * x + 2 = 0", solution.Equation);
        Assert.AreEqual("x1 = 2, x2 = 1", solution.Result);
    }

    [Test]
    public void SolveQuadratic_NoRealRoots_ReturnsNoSolution()
    {
        var solution = _solver.SolveQuadratic(1, 0, 1); // x^2 + 1 = 0
        Assert.AreEqual("1 * x^2 + 0 * x + 1 = 0", solution.Equation);
        Assert.AreEqual("Уравнение не имеет действительных корней.", solution.Result);
    }

    [Test]
    public void SolveLinear_ValidRoot_ReturnsCorrectSolution()
    {
        var solution = _solver.SolveLinear(2, -4); // 2x - 4 = 0
        Assert.AreEqual("2 * x + -4 = 0", solution.Equation);
        Assert.AreEqual("x = 2", solution.Result);
    }

    [Test]
    public void SolveLinear_NoSolution_ReturnsNoSolution()
    {
        var solution = _solver.SolveLinear(0, 4); // 0x + 4 = 0
        Assert.AreEqual("0 * x + 4 = 0", solution.Equation);
        Assert.AreEqual("Уравнение не имеет решений.", solution.Result);
    }

    [Test]
    public void SolveLinear_InfiniteSolutions_ReturnsInfiniteSolution()
    {
        var solution = _solver.SolveLinear(0, 0); // 0x + 0 = 0
        Assert.AreEqual("0 * x + 0 = 0", solution.Equation);
        Assert.AreEqual("Уравнение имеет бесконечно много решений.", solution.Result);
    }
}