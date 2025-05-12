using voidcat_api.Models;

namespace voidcat_api.Helpers;

public static class PromptHelper
{
    public static string CreateTarotPrompt(TarotReadingRequest request)
    {
        var formattedCards = request.Cards
            .OrderBy(c => c.DisplayOrder)
            .Select(c => c.Reversed ? $"{c.Name} (Reversed)" : c.Name);

        var prompt = $"Tarot reading for the {request.Spread} spread. Cards drawn: {string.Join(", ", formattedCards)}. ";
        prompt += !string.IsNullOrEmpty(request.Question) 
            ? $"Question: {request.Question}" 
            : "No specific question.";
        
        return prompt;
    }
}
