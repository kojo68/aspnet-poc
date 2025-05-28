using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Api.Tests;

public class WeatherEndpointTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public WeatherEndpointTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task WeatherForecast_Returns200()
    {
        var client = _factory.CreateClient();
        var resp = await client.GetAsync("/weatherforecast");

        Assert.Equal(HttpStatusCode.OK, resp.StatusCode);
    }
}
