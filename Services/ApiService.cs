using System.Net.Http.Json;
using PersonnageLoLApp.Models;

namespace PersonnageLoLApp.Services;

public class ApiService
{
    private readonly HttpClient _httpClient = new()
    {
        BaseAddress = new Uri("http://localhost:5066/")
    };

    public async Task<List<PersonnageLoL>> GetPersonnagesAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<PersonnageLoL>>("api/PersonnageLoL")
               ?? new List<PersonnageLoL>();
    }

    public async Task<PersonnageLoL?> GetPersonnageAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<PersonnageLoL>($"api/PersonnageLoL/{id}");
    }

    public async Task CreatePersonnageAsync(PersonnageLoL personnage)
    {
        await _httpClient.PostAsJsonAsync("api/PersonnageLoL", personnage);
    }

    public async Task UpdatePersonnageAsync(int id, PersonnageLoL personnage)
    {
        await _httpClient.PutAsJsonAsync($"api/PersonnageLoL/{id}", personnage);
    }

    public async Task DeletePersonnageAsync(int id)
    {
        await _httpClient.DeleteAsync($"api/PersonnageLoL/{id}");
    }
}