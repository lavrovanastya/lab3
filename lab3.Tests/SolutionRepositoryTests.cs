using lab3.Core;
using lab3.Database;
using lab3.Repositories;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace lab3.Tests;

[TestFixture]
public class SolutionRepositoryTests
{
    private SolutionDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<SolutionDbContext>()
            .UseNpgsql("Host=localhost;Port=5432;Database=2_lab_test;Username=postgres;Password=12345")
            .Options;

        var context = new SolutionDbContext(options);
        context.Database.EnsureDeleted();
        context.Database.EnsureCreated();
        return context;
    }

    [Test]
    public async Task AddSolutionAsync_SavesSolutionToDatabase()
    {
        var context = CreateDbContext();
        var repository = new SolutionRepository(context);
        var solution = new Solution("1 * x^2 + -3 * x + 2 = 0", "x1 = 2, x2 = 1");
        
        await repository.AddSolutionAsync(solution);
        
        var savedSolution = await context.Solutions.FirstOrDefaultAsync();
        Assert.IsNotNull(savedSolution);
        Assert.AreEqual(solution.Equation, savedSolution.Equation);
        Assert.AreEqual(solution.Result, savedSolution.Result);
    }
}