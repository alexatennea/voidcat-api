using Microsoft.AspNetCore.Mvc;
using voidcat_api.Helpers;
using voidcat_api.Models;
using voidcat_api.Services;

namespace voidcat_api.Controllers;

[ApiController]
[Route("api/tarot")]
public class TarotController(IChatGptService chatGptService, ITarotService tarotService) : ControllerBase
{
    [HttpPost("interpret")]
    public async Task<IActionResult> InterpretTarotCards([FromBody] TarotReadingRequest request)
    {
        try
        {
            var prompt = PromptHelper.CreateTarotPrompt(request);
            var response = await chatGptService.GetAssistantResponseAsync(prompt);
            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, "Internal server error occurred while interpreting tarot cards.");
        }
    }

    [HttpGet("cards")]
    public async Task<IActionResult> GetTarotCards()
    {
        try
        {
            var tarotCards = await tarotService.GetTarotCards();

            if (tarotCards.Count == 0)
            {
                return NotFound("No tarot cards found.");
            }

            return Ok(tarotCards);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred while retrieving tarot cards.");
        }
    }
    
    [HttpGet("cards/{tarotCardTypeId}")]
    public async Task<IActionResult> GetTarotCardsById([FromRoute] int tarotCardTypeId)
    {
        try
        {
            var tarotCards = await tarotService.GetTarotCardsById(tarotCardTypeId).ConfigureAwait(false);

            if (tarotCards.Count == 0)
            {
                return NotFound($"No tarot cards found for type ID {tarotCardTypeId}.");
            }

            return Ok(tarotCards);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred while retrieving tarot cards by ID.");
        }
    }
    
    [HttpGet("card-types")]
    public async Task<IActionResult> GetTarotCardTypes()
    {
        try
        {
            var tarotCardTypes = await tarotService.GetTarotCardTypes().ConfigureAwait(false);

            if (tarotCardTypes == null || tarotCardTypes.Count == 0)
            {
                return NotFound("No tarot card types found.");
            }

            return Ok(tarotCardTypes);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred while retrieving tarot card types.");
        }
    }

    [HttpGet("spreads")]
    public async Task<IActionResult> GetTarotCardSpreads()
    {
        try
        {
            var tarotCardSpreads = await tarotService.GetTarotCardSpreads().ConfigureAwait(false);

            if (tarotCardSpreads == null || tarotCardSpreads.Count == 0)
            {
                return NotFound("No tarot card spreads found.");
            }

            return Ok(tarotCardSpreads);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Internal server error occurred while retrieving tarot card spreads.");
        }
    }
    
    [HttpGet("ping")]
    public IActionResult Ping() => Ok("pong");
}