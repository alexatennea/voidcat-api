using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace voidcat_api.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TarotCardSpreads",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarotCardSpreads", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TarotCardTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarotCardTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TarotCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interpretation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TarotCardTypeId = table.Column<int>(type: "int", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarotCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TarotCards_TarotCardTypes_TarotCardTypeId",
                        column: x => x.TarotCardTypeId,
                        principalTable: "TarotCardTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TarotCardSpreads",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "The single card pull helps answer simple questions.", null, "Single Card" },
                    { 2, "The Three Card Spread is simple yet effective for straightforward questions.", "assets/img/three-card.png", "Three Card" },
                    { 3, "The Celtic Cross Spread provides in-depth insights into complex situations.", "assets/img/celtic-cross.png", "Celtic Cross" }
                });

            migrationBuilder.InsertData(
                table: "TarotCardTypes",
                columns: new[] { "Id", "Type" },
                values: new object[] { 1, "Rider–Waite Tarot" });

            migrationBuilder.InsertData(
                table: "TarotCards",
                columns: new[] { "Id", "DisplayOrder", "ImageUrl", "Interpretation", "Name", "TarotCardTypeId" },
                values: new object[,]
                {
                    { 1, 0, null, "New beginnings, optimism, trust in life", "The Fool", 1 },
                    { 2, 1, null, "Resourcefulness, power, inspired action", "The Magician", 1 },
                    { 3, 2, null, "Intuition, unconscious knowledge, potential", "The High Priestess", 1 },
                    { 4, 3, null, "Fertility, femininity, beauty, nature, abundance", "The Empress", 1 },
                    { 5, 4, null, "Authority, father figure, structure, solid foundation", "The Emperor", 1 },
                    { 6, 5, null, "Spiritual wisdom, religious beliefs, conformity, tradition", "The Hierophant", 1 },
                    { 7, 6, null, "Relationships, choices, alignment of values", "The Lovers", 1 },
                    { 8, 7, null, "Control, willpower, victory, assertion, determination", "The Chariot", 1 },
                    { 9, 8, null, "Strength, courage, patience, control", "Strength", 1 },
                    { 10, 9, null, "Soul-searching, introspection, being alone, inner guidance", "The Hermit", 1 },
                    { 11, 10, null, "Good luck, karma, life cycles, destiny, a turning point", "Wheel of Fortune", 1 },
                    { 12, 11, null, "Justice, fairness, truth, cause and effect, law", "Justice", 1 },
                    { 13, 12, null, "Pause, surrender, letting go, new perspectives", "The Hanged Man", 1 },
                    { 14, 13, null, "Endings, change, transformation, transition", "Death", 1 },
                    { 15, 14, null, "Balance, moderation, patience, purpose", "Temperance", 1 },
                    { 16, 15, null, "Addiction, sexuality, attachment, restrictions", "The Devil", 1 },
                    { 17, 16, null, "Sudden change, upheaval, chaos, revelation, awakening", "The Tower", 1 },
                    { 18, 17, null, "Hope, faith, purpose, renewal, spirituality", "The Star", 1 },
                    { 19, 18, null, "Illusion, fear, anxiety, subconscious, intuition", "The Moon", 1 },
                    { 20, 19, null, "Positivity, fun, warmth, success, vitality", "The Sun", 1 },
                    { 21, 20, null, "Judgment, rebirth, inner calling, absolution", "Judgment", 1 },
                    { 22, 21, null, "Completion, integration, accomplishment, travel", "The World", 1 },
                    { 23, 22, null, "New feelings, spirituality, intuition", "Ace of Cups", 1 },
                    { 24, 23, null, "Partnership, unity, love", "Two of Cups", 1 },
                    { 25, 24, null, "Celebration, friendship, creativity, collaborations", "Three of Cups", 1 },
                    { 26, 25, null, "Meditation, contemplation, apathy, reevaluation", "Four of Cups", 1 },
                    { 27, 26, null, "Loss, bereavement, regret, disappointment", "Five of Cups", 1 },
                    { 28, 27, null, "Nostalgia, childhood memories, innocence, joy", "Six of Cups", 1 },
                    { 29, 28, null, "Choices, confusion, illusion, fantasy", "Seven of Cups", 1 },
                    { 30, 29, null, "Disappointment, abandonment, withdrawal, escapism", "Eight of Cups", 1 },
                    { 31, 30, null, "Satisfaction, emotional stability, luxury", "Nine of Cups", 1 },
                    { 32, 31, null, "Contentment, family, harmony, marriage", "Ten of Cups", 1 },
                    { 33, 32, null, "A messenger, creative beginnings, synchronicity", "Page of Cups", 1 },
                    { 34, 33, null, "Romance, charm, 'Knight in shining armor'", "Knight of Cups", 1 },
                    { 35, 34, null, "Compassion, calm, comfort, healing", "Queen of Cups", 1 },
                    { 36, 35, null, "Emotionally balanced, compassionate, diplomatic", "King of Cups", 1 },
                    { 37, 36, null, "New ideas, clarity, breakthroughs, mental clarity", "Ace of Swords", 1 },
                    { 38, 37, null, "Difficult choices, indecision, stalemate", "Two of Swords", 1 },
                    { 39, 38, null, "Heartbreak, emotional pain, sorrow", "Three of Swords", 1 },
                    { 40, 39, null, "Rest, recovery, contemplation, peace", "Four of Swords", 1 },
                    { 41, 40, null, "Conflict, tension, loss, defeat", "Five of Swords", 1 },
                    { 42, 41, null, "Transition, change, rite of passage", "Six of Swords", 1 },
                    { 43, 42, null, "Deception, trickery, tactics, and strategy", "Seven of Swords", 1 },
                    { 44, 43, null, "Restriction, limitation, confusion, powerlessness", "Eight of Swords", 1 },
                    { 45, 44, null, "Anxiety, worry, fear, depression", "Nine of Swords", 1 },
                    { 46, 45, null, "Endings, loss, crisis, betrayal", "Ten of Swords", 1 },
                    { 47, 46, null, "Curiosity, restless energy, thirst for knowledge", "Page of Swords", 1 },
                    { 48, 47, null, "Action, impulsiveness, defending beliefs", "Knight of Swords", 1 },
                    { 49, 48, null, "Complexity, perceptiveness, clear mindedness", "Queen of Swords", 1 },
                    { 50, 49, null, "Intellectual power, authority, truth", "King of Swords", 1 },
                    { 51, 50, null, "Inspiration, new opportunities, growth, potential", "Ace of Wands", 1 },
                    { 52, 51, null, "Future planning, progress, decisions, discovery", "Two of Wands", 1 },
                    { 53, 52, null, "Preparation, foresight, enterprise, expansion", "Three of Wands", 1 },
                    { 54, 53, null, "Celebration, joy, harmony, relaxation, homecoming", "Four of Wands", 1 },
                    { 55, 54, null, "Competition, conflict, strife, tension", "Five of Wands", 1 },
                    { 56, 55, null, "Success, acclaim, achievement, leadership", "Six of Wands", 1 },
                    { 57, 56, null, "Perseverance, defensive, maintaining control", "Seven of Wands", 1 },
                    { 58, 57, null, "Movement, fast paced change, action, alignment", "Eight of Wands", 1 },
                    { 59, 58, null, "Resilience, courage, persistence, test of faith", "Nine of Wands", 1 },
                    { 60, 59, null, "Burden, extra responsibility, hard work, completion", "Ten of Wands", 1 },
                    { 61, 60, null, "Enthusiasm, exploration, discovery, free spirit", "Page of Wands", 1 },
                    { 62, 61, null, "Energy, passion, inspired action, adventure", "Knight of Wands", 1 },
                    { 63, 62, null, "Confidence, independence, home, vitality", "Queen of Wands", 1 },
                    { 64, 63, null, "Natural-born leader, vision, entrepreneur", "King of Wands", 1 },
                    { 65, 64, null, "Opportunity, prosperity, new venture", "Ace of Pentacles", 1 },
                    { 66, 65, null, "Balance, multitasking, time management", "Two of Pentacles", 1 },
                    { 67, 66, null, "Collaboration, learning, implementation", "Three of Pentacles", 1 },
                    { 68, 67, null, "Conservation, security, frugality, control", "Four of Pentacles", 1 },
                    { 69, 68, null, "Need, poverty, insecurity, worry", "Five of Pentacles", 1 },
                    { 70, 69, null, "Generosity, giving, receiving, sharing wealth", "Six of Pentacles", 1 },
                    { 71, 70, null, "Patience, waiting, profitability, investment", "Seven of Pentacles", 1 },
                    { 72, 71, null, "Apprenticeship, craftsmanship, skill, diligence", "Eight of Pentacles", 1 },
                    { 73, 72, null, "Luxury, self-sufficiency, culmination", "Nine of Pentacles", 1 },
                    { 74, 73, null, "Wealth, inheritance, family, establishment", "Ten of Pentacles", 1 },
                    { 75, 74, null, "Ambition, desire, diligence, new beginnings", "Page of Pentacles", 1 },
                    { 76, 75, null, "Efficiency, hard work, responsibility, conservatism", "Knight of Pentacles", 1 },
                    { 77, 76, null, "Practicality, creature comforts, financial security", "Queen of Pentacles", 1 },
                    { 78, 77, null, "Abundance, prosperity, security, ambition", "King of Pentacles", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TarotCards_TarotCardTypeId",
                table: "TarotCards",
                column: "TarotCardTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TarotCards");

            migrationBuilder.DropTable(
                name: "TarotCardSpreads");

            migrationBuilder.DropTable(
                name: "TarotCardTypes");
        }
    }
}
