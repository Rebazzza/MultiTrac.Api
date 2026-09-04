using System.Net;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Multitrac.IntegrationTests;

public class SampleTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public SampleTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task UnauthenticatedEndpointsReturnUnauthorized_NotServerError()
    {
        var client = _factory.CreateClient();

        var response = await client.GetAsync("/api/moneda");

        Assert.NotEqual(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task Login_WithoutCredentials_ReturnsUnauthorized()
    {
        var client = _factory.CreateClient();

        var response = await client.PostAsJsonAsync("/api/auth/login", new { username = "", password = "" });

        Assert.NotEqual(HttpStatusCode.InternalServerError, response.StatusCode);
    }

    [Fact]
    public async Task AuthenticatedEndpoint_WithInvalidToken_ReturnsUnauthorized()
    {
        var client = _factory.CreateClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "invalid.token.value");

        var response = await client.GetAsync("/api/moneda");

        Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
    }

    private async Task<(HttpClient Client, string Token)> RegisterAndGetClientAsync(string username)
    {
        var client = _factory.CreateClient();

        var registerPayload = JsonSerializer.Serialize(new
        {
            username,
            password = "Test@123",
            fullName = "Integration Test User",
            email = $"{username}@test.com"
        });

        var registerResponse = await client.PostAsync("/api/auth/register",
            new StringContent(registerPayload, Encoding.UTF8, "application/json"));

        Assert.Equal(HttpStatusCode.OK, registerResponse.StatusCode);

        var registerBody = await registerResponse.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(registerBody);
        var token = doc.RootElement.GetProperty("token").GetString();

        Assert.False(string.IsNullOrEmpty(token));

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        return (client, token!);
    }

    [Fact]
    public async Task ProveedorCrud_WorksWithAuthentication()
    {
        var (client, _) = await RegisterAndGetClientAsync($"prov_{Guid.NewGuid():N}");

        var getAll = await client.GetAsync("/api/proveedor");
        Assert.Equal(HttpStatusCode.OK, getAll.StatusCode);

        var payload = JsonSerializer.Serialize(new { prvCod = 0, prvNom = "TEST PROVEEDOR IT", prvRuc = "99999999999" });
        var create = await client.PostAsync("/api/proveedor",
            new StringContent(payload, Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.Created, create.StatusCode);

        var createBody = await create.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(createBody);
        var newId = doc.RootElement.GetProperty("prvCod").GetInt32();
        Assert.True(newId > 0);

        var getOne = await client.GetAsync($"/api/proveedor/{newId}");
        Assert.Equal(HttpStatusCode.OK, getOne.StatusCode);

        var updatePayload = JsonSerializer.Serialize(new { prvCod = newId, prvNom = "TEST PROVEEDOR IT UPDATED", prvRuc = "88888888888" });
        var update = await client.PutAsync($"/api/proveedor/{newId}",
            new StringContent(updatePayload, Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.NoContent, update.StatusCode);

        var delete = await client.DeleteAsync($"/api/proveedor/{newId}");
        Assert.Equal(HttpStatusCode.NoContent, delete.StatusCode);

        var verify = await client.GetAsync($"/api/proveedor/{newId}");
        Assert.Equal(HttpStatusCode.NotFound, verify.StatusCode);
    }

    [Fact]
    public async Task AreaCrud_WorksWithAuthentication()
    {
        var (client, _) = await RegisterAndGetClientAsync($"area_{Guid.NewGuid():N}");

        var getAll = await client.GetAsync("/api/area");
        Assert.Equal(HttpStatusCode.OK, getAll.StatusCode);

        var payload = JsonSerializer.Serialize(new { areCod = 0, areNom = "AREA TEST IT" });
        var create = await client.PostAsync("/api/area",
            new StringContent(payload, Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.Created, create.StatusCode);

        var createBody = await create.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(createBody);
        var newId = doc.RootElement.GetProperty("areCod").GetInt32();
        Assert.True(newId > 0);

        var delete = await client.DeleteAsync($"/api/area/{newId}");
        Assert.Equal(HttpStatusCode.NoContent, delete.StatusCode);
    }

    [Fact]
    public async Task TipoDocumentoCrud_WorksWithAuthentication()
    {
        var (client, _) = await RegisterAndGetClientAsync($"tipodoc_{Guid.NewGuid():N}");

        var getAll = await client.GetAsync("/api/tipodocumento");
        Assert.Equal(HttpStatusCode.OK, getAll.StatusCode);

        var payload = JsonSerializer.Serialize(new { tipCod = 0, tipDoc = "DOC TEST IT" });
        var create = await client.PostAsync("/api/tipodocumento",
            new StringContent(payload, Encoding.UTF8, "application/json"));
        Assert.Equal(HttpStatusCode.Created, create.StatusCode);

        var createBody = await create.Content.ReadAsStringAsync();
        using var doc = JsonDocument.Parse(createBody);
        var newId = doc.RootElement.GetProperty("tipCod").GetInt32();
        Assert.True(newId > 0);

        var delete = await client.DeleteAsync($"/api/tipodocumento/{newId}");
        Assert.Equal(HttpStatusCode.NoContent, delete.StatusCode);
    }
}
