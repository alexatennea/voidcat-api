using Microsoft.AspNetCore.Mvc;
using Moq;
using voidcat_api.Controllers;
using voidcat_api.Helpers;
using voidcat_api.Models;
using voidcat_api.Services;

namespace voidcat_api.tests.Controllers;

public class TarotControllerTests
{
    [Fact]
    public async Task InterpretTarotCards_ValidRequest_ReturnsOkWithResponse()
    {
        // Arrange
        var mockService = new Mock<IChatGptService>();
        var mockTarotService = new Mock<ITarotService>();
        var tarotRequest = new TarotReadingRequest
        {
            Question = "What lies ahead?",
            Cards = [ 
                new TarotReadingRequestCard() { Name = "The Fool"}, 
                new TarotReadingRequestCard() { Name = "The Magician"},
                new TarotReadingRequestCard() { Name = "The World"}
            ]
        };

        var expectedPrompt = PromptHelper.CreateTarotPrompt(tarotRequest);
        var expectedResponse = "This is the AI's interpretation of the tarot cards.";

        mockService
            .Setup(s => s.GetAssistantResponseAsync(expectedPrompt))
            .ReturnsAsync(expectedResponse);

        var controller = new TarotController(mockService.Object, mockTarotService.Object);

        // Act
        var result = await controller.InterpretTarotCards(tarotRequest);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResponse, okResult.Value);
    }
}