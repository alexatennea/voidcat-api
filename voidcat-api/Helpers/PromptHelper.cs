using voidcat_api.Models;

namespace voidcat_api.Helpers;

public static class PromptHelper
{
    public static string CreateTarotPrompt(TarotReadingRequest request)
    {
        var prompt = $"Tarot reading for the {request.Spread} spread. Cards drawn: {string.Join(",", request.Cards.Select(c => c.Name))}. ";
        prompt += !string.IsNullOrEmpty(request.Question) ? $"Question: {request.Question}" : "No specific question";
        return prompt;
    }
}