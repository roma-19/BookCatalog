using BookCatalog.Application.DTOs.GenreDTOs;
using BookCatalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _genreService;

    public GenreController(IGenreService genreService)
    {
        _genreService = genreService ?? throw new ArgumentNullException(nameof(genreService));
    }

    [HttpGet]
    public async Task<ActionResult<List<GenreResponseDto>>> GetAll()
    {
        var genres = await _genreService.GetAllAsync();
        return Ok(genres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GenreResponseDto>> GetById(int id)
    {
        try
        {
            var genre = await _genreService.GetByIdAsync(id);
            return Ok(genre);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<GenreResponseDto>> Create([FromBody] CreateGenreRequestDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var genre = await _genreService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = genre.Id }, genre);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<GenreResponseDto>> Update(int id, [FromBody] UpdateGenreRequestDto request)
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
            var genre = await _genreService.UpdateAsync(request);
            return Ok(genre);
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
            await _genreService.DeleteAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
}