using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Contracts;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class StarsController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    public StarsController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Star>>> GetStarsAsync()
    {
        try
        {
            var stars = await unitOfWork.StarsRepository.Get().ToListAsync();

            return Ok(stars);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id:int}", Name = "GetStarById")]
    public async Task<ActionResult<Star>> GetStarAsync(int id)
    {
        try
        {
            var star = await unitOfWork.StarsRepository.GetById(prop => prop.Id == id);

            if (star is null) return NotFound("Star not found.");

            return Ok(star);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Star>> CreateStarAsync(Star star)
    {
        try
        {
            if (star is null) return BadRequest("Check the field(s) and try again.");

            unitOfWork.StarsRepository.Create(star);

            await unitOfWork.Commit();

            return CreatedAtRoute("GetStarById", new { id = star.Id }, star);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateStarAsync(int id, Star star)
    {
        try
        {
            if (star.Id != id) return BadRequest("Check the field(s) and try again.");

            unitOfWork.StarsRepository.Update(star);

            await unitOfWork.Commit();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteStarAsync(int id)
    {
        try
        {
            var star = await unitOfWork.StarsRepository.GetById(prop => prop.Id == id);

            if (star is null) return NotFound("Star not found.");

            unitOfWork.StarsRepository.Delete(star);

            await unitOfWork.Commit();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
