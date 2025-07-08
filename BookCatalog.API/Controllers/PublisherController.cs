using BookCatalog.Application.DTOs.PublisherDTOs;
using BookCatalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublisherController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublisherController(IPublisherService publisherService)
    {
        _publisherService = publisherService ?? throw new ArgumentNullException(nameof(publisherService));
    }

    [HttpGet]
    public async Task<ActionResult<List<PublisherResponseDto>>> GetAll()
    {
        var publishers = await _publisherService.GetAllAsync();
        return Ok(publishers);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PublisherResponseDto>> GetById(int id)
    {
        try
        {
            var publisher = await _publisherService.GetByIdAsync(id);
            return Ok(publisher);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<PublisherResponseDto>> Create([FromBody] CreatePublisherRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var publisher = await _publisherService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = publisher.Id }, publisher);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<PublisherResponseDto>> Update(int id, [FromBody] UpdatePublisherRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (id != request.Id)
        {
            return BadRequest("ID in the URL does not match ID in the request body");
        }

        try
        {
            var publisher = await _publisherService.UpdateAsync(request);
            return Ok(publisher);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _publisherService.DeleteAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}