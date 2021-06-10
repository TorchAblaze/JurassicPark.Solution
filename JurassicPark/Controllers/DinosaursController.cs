using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JurassicPark.Models;
using System.Linq;

namespace JurassicPark.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class DinosaursController : ControllerBase
  {
    private readonly JurassicParkContext _db;
    public DinosaursController(JurassicParkContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dinosaur>>> Get()
    {
      return await _db.Dinosaurs.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Dinosaur>> GetDinosaur(int id)
    {
      var dinosaur = await _db.Dinosaurs.FindAsync(id);
      if (dinosaur == null)
      {
        return NotFound();
      }

      return dinosaur;
    }

    [HttpPost]
    public async Task<ActionResult<Dinosaur>> Post(Dinosaur dinosaur)
    {
      _db.Dinosaurs.Add(dinosaur);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetDinosaur), new { id = dinosaur.DinosaurId }, dinosaur);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Dinosaur dinosaur)
    {
      if (id != dinosaur.DinosaurId)
      {
        return BadRequest();
      }

      _db.Entry(dinosaur).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DinosaurExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }
      return NoContent();
    }
    private bool DinosaurExists(int id)
    {
      return _db.Dinosaurs.Any(e => e.DinosaurId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
      var dinosaur = await _db.Dinosaurs.FindAsync(id);
      if (dinosaur == null)
      {
        return NotFound();
      }

      _db.Dinosaurs.Remove(dinosaur);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}