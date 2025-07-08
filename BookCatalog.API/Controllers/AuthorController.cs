using BookCatalog.Application.DTOs.AuthorDTOs;
using BookCatalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
    }

    [HttpGet]
    public async Task<ActionResult<List<AuthorResponseDto>>> GetAll()
    {
        var authors = await _authorService.GetAllAsync();
        return Ok(authors);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorResponseDto>> GetById(int id)
    {
        try
        {
            var author = await _authorService.GetByIdAsync(id);
            return Ok(author);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<AuthorResponseDto>> Create([FromBody] CreateAuthorRequestDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var author = await _authorService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<AuthorResponseDto>> Update(int id, [FromBody] UpdateAuthorRequestDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (id != request.Id) return BadRequest("ID in the URL does not match ID in the request body");

        try
        {
            var author = await _authorService.UpdateAsync(request);
            return Ok(author);
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
            await _authorService.DeleteAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}