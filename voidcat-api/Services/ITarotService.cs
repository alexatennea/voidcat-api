using voidcat_api.Data;
using voidcat_api.Models;
using TarotCard = voidcat_api.Models.TarotCard;
using TarotCardType = voidcat_api.Models.TarotCardType;

namespace voidcat_api.Services
{
    public interface ITarotService
    {
        Task<List<TarotCardType>> GetTarotCardTypes();
        Task<List<TarotCard>> GetTarotCards();
        Task<List<TarotCard>> GetTarotCardsById(int tarotCardTypeId);
        Task<List<TarotCardSpread>> GetTarotCardSpreads();
    }

    public class TarotService : ITarotService
    {
        private readonly ITarotRepository _tarotRepository;
        private readonly ICacheService _cacheService;

        public TarotService(ITarotRepository tarotRepository, ICacheService cacheService)
        {
            _tarotRepository = tarotRepository;
            _cacheService = cacheService;
        }

        public async Task<List<TarotCardType>> GetTarotCardTypes()
        {
            try
            {
                const string cacheKey = "tarotCardTypes";
            
                var tarotCardTypes = _cacheService.Get<List<TarotCardType>>(cacheKey);

                if (tarotCardTypes != null)
                {
                    return tarotCardTypes;
                }
            
                tarotCardTypes = await _tarotRepository.GetTarotCardTypes();
            
                _cacheService.Set(cacheKey, tarotCardTypes, TimeSpan.FromHours(1), TimeSpan.FromMinutes(30));

                return tarotCardTypes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<TarotCard>> GetTarotCards()
        {
            try
            {
                const string cacheKey = "tarotCards";
            
                var tarotCards = _cacheService.Get<List<TarotCard>>(cacheKey);

                if (tarotCards != null)
                {
                    return tarotCards;
                }

                tarotCards = await _tarotRepository.GetTarotCards();
            
                _cacheService.Set(cacheKey, tarotCards, TimeSpan.FromHours(1), TimeSpan.FromMinutes(30));

                return tarotCards;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<TarotCard>> GetTarotCardsById(int tarotCardTypeId)
        {
            try
            {
                string cacheKey = $"tarotCards_{tarotCardTypeId}";
            
                var tarotCards = _cacheService.Get<List<TarotCard>>(cacheKey);

                if (tarotCards != null)
                {
                    return tarotCards;
                }

                tarotCards = await _tarotRepository.GetTarotCardsByTypeId(tarotCardTypeId);
            
                _cacheService.Set(cacheKey, tarotCards, TimeSpan.FromHours(1), TimeSpan.FromMinutes(30));

                return tarotCards;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        
        public async Task<List<TarotCardSpread>> GetTarotCardSpreads()
        {
            try
            {
                const string cacheKey = "tarotCardSpreads";
            
                var tarotCardSpreads = _cacheService.Get<List<TarotCardSpread>>(cacheKey);

                if (tarotCardSpreads != null)
                {
                    return tarotCardSpreads;
                }

                tarotCardSpreads = await _tarotRepository.GetTarotCardSpreads();
            
                _cacheService.Set(cacheKey, tarotCardSpreads, TimeSpan.FromHours(1), TimeSpan.FromMinutes(30));

                return tarotCardSpreads;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}