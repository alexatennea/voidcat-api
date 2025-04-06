using Microsoft.EntityFrameworkCore;
using voidcat_api.Models;
using TarotCard = voidcat_api.Models.TarotCard;
using TarotCardType = voidcat_api.Models.TarotCardType;

namespace voidcat_api.Data
{
    public class TarotDbContext : DbContext
    {
        public DbSet<TarotCardType> TarotCardTypes { get; set; }
        public DbSet<TarotCard> TarotCards { get; set; }
        public DbSet<TarotCardSpread> TarotCardSpreads { get; set; }


        public TarotDbContext(DbContextOptions<TarotDbContext> options)
            : base(options)
        {
        }  
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TarotCardType>(e =>
                {
                    e.HasData(
                        new TarotCardType {Id = 1, Type = "Rider–Waite Tarot"}
                        );
                }
            );

            modelBuilder.Entity<TarotCard>(e =>
                {
                    e.HasData(
                        new TarotCard
                        {
                            Id = 1, Name = "The Fool", Interpretation = "New beginnings, optimism, trust in life",
                            TarotCardTypeId = 1, DisplayOrder = 0
                        },
                        new TarotCard
                        {
                            Id = 2, Name = "The Magician", Interpretation = "Resourcefulness, power, inspired action",
                            TarotCardTypeId = 1, DisplayOrder = 1
                        },
                        new TarotCard
                        {
                            Id = 3, Name = "The High Priestess",
                            Interpretation = "Intuition, unconscious knowledge, potential", TarotCardTypeId = 1, DisplayOrder = 2
                        },
                        new TarotCard
                        {
                            Id = 4, Name = "The Empress",
                            Interpretation = "Fertility, femininity, beauty, nature, abundance", TarotCardTypeId = 1,
                            DisplayOrder = 3
                        },
                        new TarotCard
                        {
                            Id = 5, Name = "The Emperor",
                            Interpretation = "Authority, father figure, structure, solid foundation", TarotCardTypeId = 1,
                            DisplayOrder = 4
                        },
                        new TarotCard
                        {
                            Id = 6, Name = "The Hierophant",
                            Interpretation = "Spiritual wisdom, religious beliefs, conformity, tradition", TarotCardTypeId = 1,
                            DisplayOrder = 5
                        },
                        new TarotCard
                        {
                            Id = 7, Name = "The Lovers", Interpretation = "Relationships, choices, alignment of values",
                            TarotCardTypeId = 1, DisplayOrder = 6
                        },
                        new TarotCard
                        {
                            Id = 8, Name = "The Chariot",
                            Interpretation = "Control, willpower, victory, assertion, determination", TarotCardTypeId = 1,
                            DisplayOrder = 7
                        },
                        new TarotCard
                        {
                            Id = 9, Name = "Strength", Interpretation = "Strength, courage, patience, control", TarotCardTypeId = 1,
                            DisplayOrder = 8
                        },
                        new TarotCard
                        {
                            Id = 10, Name = "The Hermit",
                            Interpretation = "Soul-searching, introspection, being alone, inner guidance", TarotCardTypeId = 1,
                            DisplayOrder = 9
                        },
                        new TarotCard
                        {
                            Id = 11, Name = "Wheel of Fortune",
                            Interpretation = "Good luck, karma, life cycles, destiny, a turning point", TarotCardTypeId = 1,
                            DisplayOrder = 10
                        },
                        new TarotCard
                        {
                            Id = 12, Name = "Justice", Interpretation = "Justice, fairness, truth, cause and effect, law",
                            TarotCardTypeId = 1, DisplayOrder = 11
                        },
                        new TarotCard
                        {
                            Id = 13, Name = "The Hanged Man",
                            Interpretation = "Pause, surrender, letting go, new perspectives", TarotCardTypeId = 1, DisplayOrder = 12
                        },
                        new TarotCard
                        {
                            Id = 14, Name = "Death", Interpretation = "Endings, change, transformation, transition",
                            TarotCardTypeId = 1, DisplayOrder = 13
                        },
                        new TarotCard
                        {
                            Id = 15, Name = "Temperance", Interpretation = "Balance, moderation, patience, purpose",
                            TarotCardTypeId = 1, DisplayOrder = 14
                        },
                        new TarotCard
                        {
                            Id = 16, Name = "The Devil", Interpretation = "Addiction, sexuality, attachment, restrictions",
                            TarotCardTypeId = 1, DisplayOrder = 15
                        },
                        new TarotCard
                        {
                            Id = 17, Name = "The Tower",
                            Interpretation = "Sudden change, upheaval, chaos, revelation, awakening", TarotCardTypeId = 1,
                            DisplayOrder = 16
                        },
                        new TarotCard
                        {
                            Id = 18, Name = "The Star", Interpretation = "Hope, faith, purpose, renewal, spirituality",
                            TarotCardTypeId = 1, DisplayOrder = 17
                        },
                        new TarotCard
                        {
                            Id = 19, Name = "The Moon", Interpretation = "Illusion, fear, anxiety, subconscious, intuition",
                            TarotCardTypeId = 1, DisplayOrder = 18
                        },
                        new TarotCard
                        {
                            Id = 20, Name = "The Sun", Interpretation = "Positivity, fun, warmth, success, vitality",
                            TarotCardTypeId = 1, DisplayOrder = 19
                        },
                        new TarotCard
                        {
                            Id = 21, Name = "Judgment", Interpretation = "Judgment, rebirth, inner calling, absolution",
                            TarotCardTypeId = 1, DisplayOrder = 20
                        },
                        new TarotCard
                        {
                            Id = 22, Name = "The World", Interpretation = "Completion, integration, accomplishment, travel",
                            TarotCardTypeId = 1, DisplayOrder = 21
                        },
                        new TarotCard
                        {
                            Id = 23, Name = "Ace of Cups", Interpretation = "New feelings, spirituality, intuition",
                            TarotCardTypeId = 1, DisplayOrder = 22
                        },
                        new TarotCard
                        {
                            Id = 24, Name = "Two of Cups", Interpretation = "Partnership, unity, love", TarotCardTypeId = 1,
                            DisplayOrder = 23
                        },
                        new TarotCard
                        {
                            Id = 25, Name = "Three of Cups",
                            Interpretation = "Celebration, friendship, creativity, collaborations", TarotCardTypeId = 1,
                            DisplayOrder = 24
                        },
                        new TarotCard
                        {
                            Id = 26, Name = "Four of Cups",
                            Interpretation = "Meditation, contemplation, apathy, reevaluation", TarotCardTypeId = 1,
                            DisplayOrder = 25
                        },
                        new TarotCard
                        {
                            Id = 27, Name = "Five of Cups", Interpretation = "Loss, bereavement, regret, disappointment",
                            TarotCardTypeId = 1, DisplayOrder = 26
                        },
                        new TarotCard
                        {
                            Id = 28, Name = "Six of Cups", Interpretation = "Nostalgia, childhood memories, innocence, joy",
                            TarotCardTypeId = 1, DisplayOrder = 27
                        },
                        new TarotCard
                        {
                            Id = 29, Name = "Seven of Cups", Interpretation = "Choices, confusion, illusion, fantasy",
                            TarotCardTypeId = 1, DisplayOrder = 28
                        },
                        new TarotCard
                        {
                            Id = 30, Name = "Eight of Cups",
                            Interpretation = "Disappointment, abandonment, withdrawal, escapism", TarotCardTypeId = 1,
                            DisplayOrder = 29
                        },
                        new TarotCard
                        {
                            Id = 31, Name = "Nine of Cups", Interpretation = "Satisfaction, emotional stability, luxury",
                            TarotCardTypeId = 1, DisplayOrder = 30
                        },
                        new TarotCard
                        {
                            Id = 32, Name = "Ten of Cups", Interpretation = "Contentment, family, harmony, marriage",
                            TarotCardTypeId = 1, DisplayOrder = 31
                        },
                        new TarotCard
                        {
                            Id = 33, Name = "Page of Cups",
                            Interpretation = "A messenger, creative beginnings, synchronicity", TarotCardTypeId = 1,
                            DisplayOrder = 32
                        },
                        new TarotCard
                        {
                            Id = 34, Name = "Knight of Cups", Interpretation = "Romance, charm, 'Knight in shining armor'",
                            TarotCardTypeId = 1, DisplayOrder = 33
                        },
                        new TarotCard
                        {
                            Id = 35, Name = "Queen of Cups", Interpretation = "Compassion, calm, comfort, healing",
                            TarotCardTypeId = 1, DisplayOrder = 34
                        },
                        new TarotCard
                        {
                            Id = 36, Name = "King of Cups",
                            Interpretation = "Emotionally balanced, compassionate, diplomatic", TarotCardTypeId = 1,
                            DisplayOrder = 35
                        },
                        new TarotCard
                        {
                            Id = 37, Name = "Ace of Swords",
                            Interpretation = "New ideas, clarity, breakthroughs, mental clarity", TarotCardTypeId = 1,
                            DisplayOrder = 36
                        },
                        new TarotCard
                        {
                            Id = 38, Name = "Two of Swords", Interpretation = "Difficult choices, indecision, stalemate",
                            TarotCardTypeId = 1, DisplayOrder = 37
                        },
                        new TarotCard
                        {
                            Id = 39, Name = "Three of Swords", Interpretation = "Heartbreak, emotional pain, sorrow",
                            TarotCardTypeId = 1, DisplayOrder = 38
                        },
                        new TarotCard
                        {
                            Id = 40, Name = "Four of Swords", Interpretation = "Rest, recovery, contemplation, peace",
                            TarotCardTypeId = 1, DisplayOrder = 39
                        },
                        new TarotCard
                        {
                            Id = 41, Name = "Five of Swords", Interpretation = "Conflict, tension, loss, defeat",
                            TarotCardTypeId = 1, DisplayOrder = 40
                        },
                        new TarotCard
                        {
                            Id = 42, Name = "Six of Swords", Interpretation = "Transition, change, rite of passage",
                            TarotCardTypeId = 1, DisplayOrder = 41
                        },
                        new TarotCard
                        {
                            Id = 43, Name = "Seven of Swords",
                            Interpretation = "Deception, trickery, tactics, and strategy", TarotCardTypeId = 1, DisplayOrder = 42
                        },
                        new TarotCard
                        {
                            Id = 44, Name = "Eight of Swords",
                            Interpretation = "Restriction, limitation, confusion, powerlessness", TarotCardTypeId = 1,
                            DisplayOrder = 43
                        },
                        new TarotCard
                        {
                            Id = 45, Name = "Nine of Swords", Interpretation = "Anxiety, worry, fear, depression",
                            TarotCardTypeId = 1, DisplayOrder = 44
                        },
                        new TarotCard
                        {
                            Id = 46, Name = "Ten of Swords", Interpretation = "Endings, loss, crisis, betrayal", TarotCardTypeId = 1,
                            DisplayOrder = 45
                        },
                        new TarotCard
                        {
                            Id = 47, Name = "Page of Swords",
                            Interpretation = "Curiosity, restless energy, thirst for knowledge", TarotCardTypeId = 1,
                            DisplayOrder = 46
                        },
                        new TarotCard
                        {
                            Id = 48, Name = "Knight of Swords", Interpretation = "Action, impulsiveness, defending beliefs",
                            TarotCardTypeId = 1, DisplayOrder = 47
                        },
                        new TarotCard
                        {
                            Id = 49, Name = "Queen of Swords",
                            Interpretation = "Complexity, perceptiveness, clear mindedness", TarotCardTypeId = 1, DisplayOrder = 48
                        },
                        new TarotCard
                        {
                            Id = 50, Name = "King of Swords", Interpretation = "Intellectual power, authority, truth",
                            TarotCardTypeId = 1, DisplayOrder = 49
                        },
                        new TarotCard
                        {
                            Id = 51, Name = "Ace of Wands",
                            Interpretation = "Inspiration, new opportunities, growth, potential", TarotCardTypeId = 1,
                            DisplayOrder = 50
                        },
                        new TarotCard
                        {
                            Id = 52, Name = "Two of Wands",
                            Interpretation = "Future planning, progress, decisions, discovery", TarotCardTypeId = 1,
                            DisplayOrder = 51
                        },
                        new TarotCard
                        {
                            Id = 53, Name = "Three of Wands",
                            Interpretation = "Preparation, foresight, enterprise, expansion", TarotCardTypeId = 1, DisplayOrder = 52
                        },
                        new TarotCard
                        {
                            Id = 54, Name = "Four of Wands",
                            Interpretation = "Celebration, joy, harmony, relaxation, homecoming", TarotCardTypeId = 1,
                            DisplayOrder = 53
                        },
                        new TarotCard
                        {
                            Id = 55, Name = "Five of Wands", Interpretation = "Competition, conflict, strife, tension",
                            TarotCardTypeId = 1, DisplayOrder = 54
                        },
                        new TarotCard
                        {
                            Id = 56, Name = "Six of Wands", Interpretation = "Success, acclaim, achievement, leadership",
                            TarotCardTypeId = 1, DisplayOrder = 55
                        },
                        new TarotCard
                        {
                            Id = 57, Name = "Seven of Wands",
                            Interpretation = "Perseverance, defensive, maintaining control", TarotCardTypeId = 1, DisplayOrder = 56
                        },
                        new TarotCard
                        {
                            Id = 58, Name = "Eight of Wands",
                            Interpretation = "Movement, fast paced change, action, alignment", TarotCardTypeId = 1, DisplayOrder = 57
                        },
                        new TarotCard
                        {
                            Id = 59, Name = "Nine of Wands",
                            Interpretation = "Resilience, courage, persistence, test of faith", TarotCardTypeId = 1,
                            DisplayOrder = 58
                        },
                        new TarotCard
                        {
                            Id = 60, Name = "Ten of Wands",
                            Interpretation = "Burden, extra responsibility, hard work, completion", TarotCardTypeId = 1,
                            DisplayOrder = 59
                        },
                        new TarotCard
                        {
                            Id = 61, Name = "Page of Wands",
                            Interpretation = "Enthusiasm, exploration, discovery, free spirit", TarotCardTypeId = 1,
                            DisplayOrder = 60
                        },
                        new TarotCard
                        {
                            Id = 62, Name = "Knight of Wands",
                            Interpretation = "Energy, passion, inspired action, adventure", TarotCardTypeId = 1, DisplayOrder = 61
                        },
                        new TarotCard
                        {
                            Id = 63, Name = "Queen of Wands", Interpretation = "Confidence, independence, home, vitality",
                            TarotCardTypeId = 1, DisplayOrder = 62
                        },
                        new TarotCard
                        {
                            Id = 64, Name = "King of Wands", Interpretation = "Natural-born leader, vision, entrepreneur",
                            TarotCardTypeId = 1, DisplayOrder = 63
                        },
                        new TarotCard
                        {
                            Id = 65, Name = "Ace of Pentacles", Interpretation = "Opportunity, prosperity, new venture",
                            TarotCardTypeId = 1, DisplayOrder = 64
                        },
                        new TarotCard
                        {
                            Id = 66, Name = "Two of Pentacles", Interpretation = "Balance, multitasking, time management",
                            TarotCardTypeId = 1, DisplayOrder = 65
                        },
                        new TarotCard
                        {
                            Id = 67, Name = "Three of Pentacles",
                            Interpretation = "Collaboration, learning, implementation", TarotCardTypeId = 1, DisplayOrder = 66
                        },
                        new TarotCard
                        {
                            Id = 68, Name = "Four of Pentacles",
                            Interpretation = "Conservation, security, frugality, control", TarotCardTypeId = 1, DisplayOrder = 67
                        },
                        new TarotCard
                        {
                            Id = 69, Name = "Five of Pentacles", Interpretation = "Need, poverty, insecurity, worry",
                            TarotCardTypeId = 1, DisplayOrder = 68
                        },
                        new TarotCard
                        {
                            Id = 70, Name = "Six of Pentacles",
                            Interpretation = "Generosity, giving, receiving, sharing wealth", TarotCardTypeId = 1, DisplayOrder = 69
                        },
                        new TarotCard
                        {
                            Id = 71, Name = "Seven of Pentacles",
                            Interpretation = "Patience, waiting, profitability, investment", TarotCardTypeId = 1, DisplayOrder = 70
                        },
                        new TarotCard
                        {
                            Id = 72, Name = "Eight of Pentacles",
                            Interpretation = "Apprenticeship, craftsmanship, skill, diligence", TarotCardTypeId = 1,
                            DisplayOrder = 71
                        },
                        new TarotCard
                        {
                            Id = 73, Name = "Nine of Pentacles", Interpretation = "Luxury, self-sufficiency, culmination",
                            TarotCardTypeId = 1, DisplayOrder = 72
                        },
                        new TarotCard
                        {
                            Id = 74, Name = "Ten of Pentacles",
                            Interpretation = "Wealth, inheritance, family, establishment", TarotCardTypeId = 1, DisplayOrder = 73
                        },
                        new TarotCard
                        {
                            Id = 75, Name = "Page of Pentacles",
                            Interpretation = "Ambition, desire, diligence, new beginnings", TarotCardTypeId = 1, DisplayOrder = 74
                        },
                        new TarotCard
                        {
                            Id = 76, Name = "Knight of Pentacles",
                            Interpretation = "Efficiency, hard work, responsibility, conservatism", TarotCardTypeId = 1,
                            DisplayOrder = 75
                        },
                        new TarotCard
                        {
                            Id = 77, Name = "Queen of Pentacles",
                            Interpretation = "Practicality, creature comforts, financial security", TarotCardTypeId = 1,
                            DisplayOrder = 76
                        },
                        new TarotCard
                        {
                            Id = 78, Name = "King of Pentacles",
                            Interpretation = "Abundance, prosperity, security, ambition", TarotCardTypeId = 1, DisplayOrder = 77
                        }
                    );
                }
            );
            
            modelBuilder.Entity<TarotCardSpread>(e =>
                {
                    e.HasData(
                        new TarotCardSpread {Id = 1, Name = "Single Card", Description = "The single card pull helps answer simple questions.", ImageUrl = null },
                        new TarotCardSpread {Id = 2, Name = "Three Card", Description = "The Three Card Spread is simple yet effective for straightforward questions.", ImageUrl = "assets/img/three-card.png"},
                        new TarotCardSpread {Id = 3, Name = "Celtic Cross", Description = "The Celtic Cross Spread provides in-depth insights into complex situations.", ImageUrl = "assets/img/celtic-cross.png"}
                    );
                }
            );
        }
    }
}