using Microsoft.AspNetCore.Mvc;
using DAL.Library;
using DAL;

namespace form.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CrudBaseContorller<T,TKeyType> : ControllerBase
where T : class
where TKeyType: IComparable
{

    private readonly ILogger _logger;
    private readonly Repository<T,TKeyType> _repository;

    public CrudBaseContorller(
        ILogger logger,
        ApplicationDBContext context
        )
    {
        _logger = logger;
        _repository = new(context);
    }
    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        var entities = _repository.GetAll().ToList();
        return Ok(entities);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(TKeyType id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        return Ok(entity);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Create([FromBody] T entity)
    {
        await _repository.AddAsync(entity);
        return CreatedAtAction(nameof(GetById), null, entity);
    }

    [HttpPut("{id}")]
    public virtual async Task<IActionResult> Update(TKeyType id, [FromBody] T entity)
    {
        // if (id != entity.Id)
        // {
        //     return BadRequest();
        // }

        await _repository.UpdateAsync(entity);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public virtual async Task<IActionResult> Delete(TKeyType id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
        {
            return NotFound();
        }

        await _repository.DeleteAsync(entity);
        return NoContent();
    }

}
