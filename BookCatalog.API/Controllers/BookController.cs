using BookCatalog.Application.DTOs.BookDTOs;
using BookCatalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookCatalog.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService  _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService ?? throw new ArgumentNullException(nameof(bookService));
    }

    [HttpGet]
    public async Task<ActionResult<List<BookResponseDto>>> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookResponseDto>> GetById(int id)
    {
        try
        {
            var book = await _bookService.GetByIdAsync(id);
            return Ok(book);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<BookResponseDto>> Create([FromBody] CreateBookRequestDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        
        var book = await _bookService.CreateAsync(request);
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<BookResponseDto>> Update(int id, [FromBody] UpdateBookRequestDto request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        if (id != request.Id) return BadRequest("ID in the URL does not match ID in the request body");

        try
        {
            var book = await _bookService.UpdateAsync(request);
            return Ok(book);
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }
        catch (ArgumentException ex)
        {
            return NotFound(ex.Message);
        }
    }
    
    
    
    
    
    
    
    
    
    
}