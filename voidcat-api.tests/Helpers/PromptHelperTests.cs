using voidcat_api.Helpers;
using voidcat_api.Models;

namespace voidcat_api.tests.Helpers;

public class PromptHelperTests
{
    [Fact]
    public void CreateTarotPrompt_ValidRequest_ReturnsCorrectPrompt()
    {
        // arrange
        var tarotRequest = new TarotReadingRequest
        {
            Spread = "Three Card",
            Question = "What lies ahead?",
            Cards = [ 
                new TarotReadingRequestCard() { Name = "The Fool"}, 
                new TarotReadingRequestCard() { Name = "The Magician"},
                new TarotReadingRequestCard() { Name = "The World"}
            ]
        };
        
        string expectedResponse = "Tarot reading for the Three Card spread. Cards drawn: The Fool,The Magician,The World. Question: What lies ahead?";
        
        // act 
        var response = PromptHelper.CreateTarotPrompt(tarotRequest);
        
        // assert
        Assert.Equal(expectedResponse, response);
    }
}