using SistemaGestionEntities;
using Microsoft.AspNetCore.WebUtilities;
using System.Net.Http;

namespace SistemaGestionUI.ClientServices;

public class UsuariosService
{
    private readonly HttpClient _httpClient;

    public UsuariosService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<List<Usuario>?> ListUsers()
    {        
        return await _httpClient.GetFromJsonAsync<List<Usuario>>("");
    }

    public async Task<Usuario?> GetOneUser(int id)
    {        
        return await _httpClient.GetFromJsonAsync<Usuario>($"{id}");
    }


    public async Task CreateUser(Usuario usuario)
    {
        await _httpClient.PostAsJsonAsync("", usuario);
    }

    public async Task UpdateUser(int id, Usuario usuario)
    {
        await _httpClient.PutAsJsonAsync($"{id}", usuario);
    }

    public async Task DeleteUser(int id)
    {
        await _httpClient.DeleteAsync($"{id}");
    }

    public async Task<List<Usuario>?> GetUserBy(string filtro)
    {
        return await _httpClient.GetFromJsonAsync<List<Usuario>>(
            QueryHelpers.AddQueryString("", new Dictionary<string, string>() { { "filtro", filtro } }));
    }

}
