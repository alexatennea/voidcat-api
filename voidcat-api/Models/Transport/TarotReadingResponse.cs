using Newtonsoft.Json;

namespace voidcat_api.Models;

public class TarotReadingResponse
{
    public int Id { get; set; }
    public Guid UniqueIdentifier { get; set; }

    public List<TarotReadingResponeCard> IndividualCards { get; set; }

    public string OverallInterpretation { get; set; }
}