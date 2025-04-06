using voidcat_api.Models;

namespace voidcat_api.Models
{
    public class TarotCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Interpretation { get; set; }
        public string? ImageUrl { get; set; }
        public int TarotCardTypeId { get; set; }
        public TarotCardType TarotCardType { get; set; }
        public int DisplayOrder { get; set; }
    }
}