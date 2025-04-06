using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using voidcat_api.Models;

namespace voidcat_api.Data
{
    public interface ITarotRepository
    {
        Task<List<TarotCardType>> GetTarotCardTypes();
        Task<List<TarotCard>> GetTarotCards();
        Task<List<TarotCard>> GetTarotCardsByTypeId(int tarotCardTypeId);
        Task<List<TarotCardSpread>> GetTarotCardSpreads();
    }

    public class TarotRepository : ITarotRepository
    {
        private readonly TarotDbContext _context;
        private readonly ILogger<TarotRepository> _logger;

        public TarotRepository(TarotDbContext context, ILogger<TarotRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<TarotCardType>> GetTarotCardTypes()
        {
            try
            {
                List<TarotCardType> tarotCardTypes = await _context.TarotCardTypes
                    .AsNoTracking()
                    .ToListAsync()
                    .ConfigureAwait(false);

                return tarotCardTypes;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving tarot card types.");
                throw;
            }
        }

        public async Task<List<TarotCard>> GetTarotCards()
        {
            try
            {
                List<TarotCard> tarotCards = await _context.TarotCards
                    .AsNoTracking()
                    .OrderBy(tc => tc.DisplayOrder)
                    .Include(tc => tc.TarotCardType)
                    .ToListAsync()
                    .ConfigureAwait(false);

                return tarotCards;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving tarot cards.");
                throw;
            }
        }

        public async Task<List<TarotCard>> GetTarotCardsByTypeId(int tarotCardTypeId)
        {
            try
            {
                List<TarotCard> tarotCards = await _context.TarotCards
                    .AsNoTracking()
                    .Where(tc => tc.TarotCardTypeId == tarotCardTypeId)
                    .OrderBy(tc => tc.DisplayOrder)
                    .Include(tc => tc.TarotCardType)
                    .ToListAsync()
                    .ConfigureAwait(false);
                
                return tarotCards;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An error occurred while retrieving tarot cards for type ID {tarotCardTypeId}.");
                throw;
            }
        }

        public async Task<List<TarotCardSpread>> GetTarotCardSpreads()
        {
            try
            {
                List<TarotCardSpread> tarotCardSpreads = await _context.TarotCardSpreads
                    .AsNoTracking()
                    .ToListAsync()
                    .ConfigureAwait(false);

                return tarotCardSpreads;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while retrieving tarot card spreads.");
                throw;
            }
        }
    }
}
