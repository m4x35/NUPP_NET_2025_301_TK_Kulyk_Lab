using Microsoft.AspNetCore.Mvc;
using SimpleLibrary.Infrastructure.Models;
using SimpleLibrary.Infrastructure.Services;
using SimpleLibrary.REST.Models;

namespace SimpleLibrary.REST.Controllers;

[ApiController]
[Route("api/books")]
public class BooksController : ControllerBase
{
    private readonly ICrudServiceAsync<BookModel> _service;

    public BooksController(ICrudServiceAsync<BookModel> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookResponse>>> GetAll()
    {
        var books = await _service.ReadAllAsync();

        return Ok(books.Select(ToResponse));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<BookResponse>> GetById(Guid id)
    {
        var book = await _service.ReadAsync(id);

        if (book == null)
            return NotFound();

        return Ok(ToResponse(book));
    }

    [HttpGet("page/{page:int}/amount/{amount:int}")]
    public async Task<ActionResult<IEnumerable<BookResponse>>> GetPage(int page, int amount)
    {
        var books = await _service.ReadAllAsync(page, amount);

        return Ok(books.Select(ToResponse));
    }

    [HttpPost]
    public async Task<ActionResult<BookResponse>> Create(BookRequest request)
    {
        var book = new BookModel
        {
            OriginalId = Guid.NewGuid(),
            Title = request.Title,
            Year = request.Year,
            IsAvailable = request.IsAvailable,
            Author = request.Author,
            Pages = request.Pages,
            Genre = request.Genre
        };

        await _service.CreateAsync(book);

        return CreatedAtAction(nameof(GetById), new { id = book.OriginalId }, ToResponse(book));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, BookRequest request)
    {
        var book = await _service.ReadAsync(id);

        if (book == null)
            return NotFound();

        book.Title = request.Title;
        book.Year = request.Year;
        book.IsAvailable = request.IsAvailable;
        book.Author = request.Author;
        book.Pages = request.Pages;
        book.Genre = request.Genre;

        await _service.UpdateAsync(book);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var book = await _service.ReadAsync(id);

        if (book == null)
            return NotFound();

        await _service.RemoveAsync(book);

        return NoContent();
    }

    private static BookResponse ToResponse(BookModel book)
    {
        return new BookResponse
        {
            Id = book.OriginalId,
            Title = book.Title,
            Year = book.Year,
            IsAvailable = book.IsAvailable,
            Author = book.Author,
            Pages = book.Pages,
            Genre = book.Genre
        };
    }
}