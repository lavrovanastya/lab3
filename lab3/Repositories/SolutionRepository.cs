using lab3.Core;
using lab3.Database;
using Microsoft.EntityFrameworkCore;

namespace lab3.Repositories;

public class SolutionRepository
{
    private readonly SolutionDbContext _context;

    public SolutionRepository(SolutionDbContext context)
    {
        _context = context;
    }
    
    public async Task AddSolutionAsync(Solution solution)
    {
        await _context.Solutions.AddAsync(solution);
        await _context.SaveChangesAsync();
    }
    
    public async Task<Solution> GetSolutionByIdAsync(int id)
    {
        return await _context.Solutions.FindAsync(id);
    }
}