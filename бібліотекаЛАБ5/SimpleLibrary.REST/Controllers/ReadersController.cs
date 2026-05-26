using Microsoft.AspNetCore.Mvc;
using SimpleLibrary.Infrastructure.Models;
using SimpleLibrary.Infrastructure.Services;
using SimpleLibrary.REST.Models;

namespace SimpleLibrary.REST.Controllers;

[ApiController]
[Route("api/readers")]
public class ReadersController : ControllerBase
{
    private readonly ICrudServiceAsync<ReaderModel> _service;

    public ReadersController(ICrudServiceAsync<ReaderModel> service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReaderResponse>>> GetAll()
    {
        var readers = await _service.ReadAllAsync();

        return Ok(readers.Select(ToResponse));
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<ReaderResponse>> GetById(Guid id)
    {
        var reader = await _service.ReadAsync(id);

        if (reader == null)
            return NotFound();

        return Ok(ToResponse(reader));
    }

    [HttpPost]
    public async Task<ActionResult<ReaderResponse>> Create(ReaderRequest request)
    {
        var reader = new ReaderModel
        {
            OriginalId = Guid.NewGuid(),
            FullName = request.FullName,
            Phone = request.Phone,
            ReaderCardNumber = request.ReaderCardNumber
        };

        await _service.CreateAsync(reader);

        return CreatedAtAction(nameof(GetById), new { id = reader.OriginalId }, ToResponse(reader));
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, ReaderRequest request)
    {
        var reader = await _service.ReadAsync(id);

        if (reader == null)
            return NotFound();

        reader.FullName = request.FullName;
        reader.Phone = request.Phone;
        reader.ReaderCardNumber = request.ReaderCardNumber;

        await _service.UpdateAsync(reader);

        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var reader = await _service.ReadAsync(id);

        if (reader == null)
            return NotFound();

        await _service.RemoveAsync(reader);

        return NoContent();
    }

    private static ReaderResponse ToResponse(ReaderModel reader)
    {
        return new ReaderResponse
        {
            Id = reader.OriginalId,
            FullName = reader.FullName,
            Phone = reader.Phone,
            ReaderCardNumber = reader.ReaderCardNumber
        };
    }
}