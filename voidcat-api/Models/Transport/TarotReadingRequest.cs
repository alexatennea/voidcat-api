namespace voidcat_api.Models;

public class TarotReadingRequest
{
    public string Spread { get; set; }
    public List<TarotReadingRequestCard> Cards { get; set; }
    public string Question { get; set; }
}