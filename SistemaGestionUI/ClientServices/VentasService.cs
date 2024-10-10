using SistemaGestionEntities;
using Microsoft.AspNetCore.WebUtilities;

namespace SistemaGestionUI.ClientServices;

public class VentasService
{
    private readonly HttpClient _httpClient;

    public VentasService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Venta?> ObtenerVenta(int id)
    {
        return await _httpClient.GetFromJsonAsync<Venta>($"{id}");
    }

    public async Task<List<Venta>?> ListarVentas()
    {
        return await _httpClient.GetFromJsonAsync<List<Venta>>("");
    }

    public async Task CrearVenta(Venta venta)
    {
        await _httpClient.PostAsJsonAsync("", venta);
    }

    public async Task ModificarVenta(int id, Venta venta)
    {
        await _httpClient.PutAsJsonAsync($"{id}", venta);            
    }

    public async Task EliminarVenta(int id)
    {
        await _httpClient.DeleteAsync($"{id}");
    }
}
