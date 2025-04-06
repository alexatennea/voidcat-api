using System.Net;
using Moq;
using Moq.Protected;
using voidcat_api.Services;

namespace voidcat_api.tests.Services;

public class ChatGptServiceTests
{
    private const string ApiKey = "test-api-key";
    private const string AssistantId = "assistant-id";

    [Fact]
    public async Task GetAssistantResponseAsync_CallsWithValidRequest_ReturnsExpectedReply()
    {
        // Arrange
        var threadResponse = "{\"id\":\"thread-123\"}";
        var runResponse = "{\"id\":\"run-456\"}";
        var runStatusResponse = "{\"status\":\"completed\"}";
        var messagesResponse = """
                               {
                                   "data": [
                                       {
                                           "content": [
                                               {
                                                   "text": {
                                                       "value": "Test reply from assistant."
                                                   }
                                               }
                                           ]
                                       }
                                   ]
                               }
                               """;

        var httpClientMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);
        httpClientMock.Protected()
            .SetupSequence<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(threadResponse) })
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK))
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(runResponse) })
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(runStatusResponse) })
            .ReturnsAsync(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(messagesResponse) });

        var httpClient = new HttpClient(httpClientMock.Object)
        {
            BaseAddress = new Uri("https://api.openai.com")
        };

        var service = new ChatGptService(httpClient, ApiKey, AssistantId);

        // Act
        var result = await service.GetAssistantResponseAsync("Hello");

        // Assert
        Assert.Equal("Test reply from assistant.", result);
    }
}