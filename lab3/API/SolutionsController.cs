using lab3.Core;
using lab3.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace lab3.API;

[ApiController]
[Route("api/[controller]")]
public class SolutionsController : ControllerBase
{
    private readonly SolutionRepository _repository;
    private readonly Solver _solver;

    public SolutionsController(SolutionRepository repository, Solver solver)
    {
        _repository = repository;
        _solver = solver;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Solution>> GetSolutionById(int id)
    {
        var solution = await _repository.GetSolutionByIdAsync(id);
        if (solution == null)
        {
            return NotFound();
        }

        return Ok(solution);
    }

    [HttpPost("quadratic")]
    public async Task<ActionResult> SolveQuadratic([FromQuery] double a, [FromQuery] double b, [FromQuery] double c)
    {
        var solution = _solver.SolveQuadratic(a, b, c);
        await _repository.AddSolutionAsync(solution);
        return CreatedAtAction(nameof(GetSolutionById), new { id = solution.ID }, solution);
    }

    [HttpPost("linear")]
    public async Task<ActionResult> SolveLinear([FromQuery] double k, [FromQuery] double b)
    {
        var solution = _solver.SolveLinear(k, b);
        await _repository.AddSolutionAsync(solution);
        return CreatedAtAction(nameof(GetSolutionById), new { id = solution.ID }, solution);
    }
}