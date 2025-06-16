using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TrainingPlansApi.Models;
using TrainingPlansApi.Data;

namespace TrainingPlansApi.Controllers
{
}
[Route("api/[controller]")]
[ApiController]
public class TrainingPlansController : ControllerBase
{
    // ³¹czenie z klas¹ data
    private readonly TrainingPlansContext _context;

    public TrainingPlansController(TrainingPlansContext context)
    {
        _context = context;
    }

    // GET: api/TrainingPlans
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TrainingPlan>>> GetTrainingPlans()
    {
        return await _context.TrainingPlans.ToListAsync();
    }

    // GET: api/TrainingPlans/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<TrainingPlan>> GetTrainingPlan(int id)
    {
        var trainingPlan = await _context.TrainingPlans.FindAsync(id);

        if (trainingPlan == null)
        {
            // Dodaj logowanie przed zwróceniem b³êdu
            Console.WriteLine($"TrainingPlan with ID {id} not found!");
            return NotFound(new { Code = 404, Message = "Training plan not found" });
        }

        return trainingPlan;
    }


    // POST: api/TrainingPlans
    [HttpPost("post")]
    public async Task<ActionResult<TrainingPlan>> PostTrainingPlan(TrainingPlan trainingPlan)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { Code = 400, Message = "Invalid model" });
        }

        try
        {
            trainingPlan.CreatedAt = DateTime.UtcNow;
            _context.TrainingPlans.Add(trainingPlan);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTrainingPlan), new { id = trainingPlan.Id }, trainingPlan);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Code = 500, Message = ex.Message });
        }
    }


    [HttpPost("add")]
    public async Task<IActionResult> AddTrainingPlan([FromForm] TrainingPlan plan)
    {
        if (plan == null || !ModelState.IsValid)
        {
            return BadRequest(new { message = "Nieprawid³owe dane." });
        }

        plan.CreatedAt = DateTime.UtcNow; // Ustawianie wartoœci domyœlnej zgodnej z zakresem bazy danych

        _context.TrainingPlans.Add(plan);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Plan zosta³ zapisany." });
    }



    // PUT: api/TrainingPlans/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> PutTrainingPlan(int id, TrainingPlan trainingPlan)
    {
        if (id != trainingPlan.Id)
        {
            return BadRequest(new { Code = 400, Message = "ID mismatch" });
        }

        _context.Entry(trainingPlan).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!TrainingPlanExists(id))
            {
                return NotFound(new { Code = 404, Message = "Training plan not found" });
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/TrainingPlans/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrainingPlan(int id)
    {
        var trainingPlan = await _context.TrainingPlans.FindAsync(id);
        if (trainingPlan == null)
        {
            return NotFound(new { Code = 404, Message = "Training plan not found" });
        }

        _context.TrainingPlans.Remove(trainingPlan);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/TrainingPlans/upload
    [HttpPost("upload")]
    public async Task<IActionResult> UploadDocument()
    {
        try
        {
            var file = Request.Form.Files[0];

            if (file.Length > 0)
            {
                var filePath = Path.Combine("Uploads", file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                return Ok(new { Code = 200, Message = "File uploaded successfully", FilePath = filePath });
            }
            return BadRequest(new { Code = 400, Message = "Empty file" });
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Code = 500, Message = ex.Message });
        }
    }

    private bool TrainingPlanExists(int id)
    {
        return _context.TrainingPlans.Any(e => e.Id == id);
    }
}
