using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Contracts;
using MoviesApi.Models;

namespace MoviesApi.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class MoviesController : ControllerBase
{
    private readonly IUnitOfWork unitOfWork;
    public MoviesController(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesAsync()
    {
        try
        {
            var movies = await unitOfWork.MoviesRepository.Get().ToListAsync();

            return Ok(movies);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id:int}", Name = "GetMovieById")]
    public async Task<ActionResult<Movie>> GetMovieAsync(int id)
    {
        try
        {
            var movie = await unitOfWork.MoviesRepository.GetById(prop => prop.Id == id);

            if (movie is null) return NotFound("Movie not found.");

            return Ok(movie);
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovieAsync(Movie movie)
    {
        try
        {
            if (movie is null) return BadRequest("Check the field(s) and try again");

            unitOfWork.MoviesRepository.Create(movie);

            await unitOfWork.Commit();

            return CreatedAtRoute("GetMovieById", new { id = movie.Id }, movie);
        }
        catch (SystemException ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult> UpdateMovieAsync(int id, Movie movie)
    {
        try
        {
            if (movie.Id != id) return BadRequest("Check the field(s) and try again.");

            unitOfWork.MoviesRepository.Update(movie);

            await unitOfWork.Commit();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteMovieAsync(int id)
    {
        try
        {
            var movie = await unitOfWork.MoviesRepository.GetById(prop => prop.Id == id);

            if (movie is null) return NotFound("Movie not found.");

            unitOfWork.MoviesRepository.Delete(movie);

            await unitOfWork.Commit();

            return NoContent();
        }
        catch (System.Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
