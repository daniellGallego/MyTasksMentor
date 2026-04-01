using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Configuration;

namespace MyTasksMentor.Application.Services;

public class AiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    private readonly string _baseUrl;

    public AiService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _apiKey = configuration["AiSettings:ApiKey"]!;
        _baseUrl = configuration["AiSettings:BaseUrl"]!;
    }

    public async Task<string> GenerateSummaryAsync(List<string> tasks)
    {
        if (!tasks.Any())
            return "No tienes tareas pendientes.";

        var prompt = $@"
            Eres un asistente experto en productividad.

            Analiza las siguientes tareas pendientes de un usuario:

            {string.Join("\n", tasks.Select(t => "- " + t))}

            Genera una respuesta clara y útil que incluya:

            1. Un resumen general
            2. Qué tipo de trabajo predominante hay (ej: técnico, administrativo, personal)
            3. Una recomendación concreta para priorizar

            Sé breve pero útil.
            ";

        var requestBody = new
        {
            model = "openai/gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "user", content = prompt }
            }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/chat/completions");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            return "Error generando resumen con IA.";

        var json = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(json);

        var content = doc
            .RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        return content ?? "No se pudo generar el resumen.";
    }

    public async Task<string> AnalyzeNotesAsync(List<string> notes)
    {
        if (!notes.Any())
            return "No hay notas para analizar.";

            var prompt = $@"
            Eres un asistente experto en análisis de información personal.

            Analiza las siguientes notas del usuario:

            {string.Join("\n", notes.Select(n => "- " + n))}

            Genera una respuesta que incluya:

            1. Temas principales
            2. Posibles patrones o intereses
            3. Una recomendación útil basada en esta información

            Sé claro y breve.
            ";

        var requestBody = new
        {
            model = "openai/gpt-3.5-turbo",
            messages = new[]
            {
            new { role = "user", content = prompt }
        }
        };

        var request = new HttpRequestMessage(HttpMethod.Post, $"{_baseUrl}/chat/completions");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json"
        );

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
            return "Error analizando notas.";

        var json = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(json);

        return doc.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString() ?? "No se pudo analizar.";
    }
}