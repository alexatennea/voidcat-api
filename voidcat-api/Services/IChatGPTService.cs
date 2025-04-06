using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace voidcat_api.Services;

public interface IChatGptService
{
    Task<string> GetAssistantResponseAsync(string prompt);
}

public class ChatGptService : IChatGptService
{
    private readonly HttpClient _client;
    private readonly string _assistantId;

    public ChatGptService(HttpClient client, string apiKey, string assistantId)
    {
        _client = client;
        _assistantId = assistantId;

        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        _client.DefaultRequestHeaders.Add("OpenAI-Beta", "assistants=v2");
    }

    public async Task<string> GetAssistantResponseAsync(string prompt)
    {
        var threadId = await CreateThreadAsync();
        await AddMessageToThreadAsync(threadId, prompt);
        var runId = await CreateRunAsync(threadId);
        await WaitForRunCompletionAsync(threadId, runId);
        return await GetAssistantReplyAsync(threadId);
    }

    private async Task<string> CreateThreadAsync()
    {
        var response = await _client.PostAsync("https://api.openai.com/v1/threads", null);
        response.EnsureSuccessStatusCode();
        var content = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        return content.RootElement.GetProperty("id").GetString()!;
    }

    private async Task AddMessageToThreadAsync(string threadId, string content)
    {
        var payload = JsonSerializer.Serialize(new { role = "user", content });
        var response = await _client.PostAsync(
            $"https://api.openai.com/v1/threads/{threadId}/messages",
            new StringContent(payload, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
    }

    private async Task<string> CreateRunAsync(string threadId)
    {
        var payload = JsonSerializer.Serialize(new { assistant_id = _assistantId });
        var response = await _client.PostAsync(
            $"https://api.openai.com/v1/threads/{threadId}/runs",
            new StringContent(payload, Encoding.UTF8, "application/json"));
        response.EnsureSuccessStatusCode();
        var content = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        return content.RootElement.GetProperty("id").GetString()!;
    }

    private async Task WaitForRunCompletionAsync(string threadId, string runId)
    {
        string status;
        do
        {
            await Task.Delay(1000);
            var response = await _client.GetAsync($"https://api.openai.com/v1/threads/{threadId}/runs/{runId}");
            response.EnsureSuccessStatusCode();
            var content = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
            status = content.RootElement.GetProperty("status").GetString()!;
        } 
        while (status is "queued" or "in_progress");

        if (status != "completed") 
        {
            throw new Exception($"Assistant run failed or cancelled: {status}");
        }
    }

    private async Task<string> GetAssistantReplyAsync(string threadId)
    {
        var response = await _client.GetAsync($"https://api.openai.com/v1/threads/{threadId}/messages");
        response.EnsureSuccessStatusCode();
        var messagesJson = JsonDocument.Parse(await response.Content.ReadAsStringAsync());

        return messagesJson.RootElement
            .GetProperty("data")[0]
            .GetProperty("content")[0]
            .GetProperty("text")
            .GetProperty("value")
            .GetString()!;
    }
}