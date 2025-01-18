using System.Net;
using System.Net.Http.Json;
using lab3.Core;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace lab3.Tests;

[TestFixture]
public class SolutionsControllerTests
{
    private HttpClient _client;

    [SetUp]
    public void SetUp()
    {
        var factory = new WebApplicationFactory<Program>();
        _client = factory.CreateClient();
    }

    [Test]
    public async Task SolveQuadratic_ValidInputs_ReturnsSolution()
    {
        var a = 1.0;
        var b = -3.0;
        var c = 2.0;

        var requestUrl = $"/api/Solutions/quadratic?a={a}&b={b}&c={c}";
        
        var response = await _client.PostAsync(requestUrl, null);
        
        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        var solution = await response.Content.ReadFromJsonAsync<Solution>();
        Assert.NotNull(solution);
        Assert.AreEqual("x1 = 2, x2 = 1", solution.Result); 
    }

    [Test]
    public async Task SolveLinear_ValidInputs_ReturnsSolution()
    {
        var k = 2.0;
        var b = -4.0;

        var requestUrl = $"/api/Solutions/linear?k={k}&b={b}";

        var response = await _client.PostAsync(requestUrl, null);

        Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);

        var solution = await response.Content.ReadFromJsonAsync<Solution>();
        Assert.NotNull(solution);
        Assert.AreEqual("x = 2", solution.Result);
    }
}