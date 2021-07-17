using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Features.FlashCards;

namespace ExampleCodeFirstApproch.Controllers
{
    public class FlashCardSetController : ControllerBase
    {

        private readonly DataContext _context;

        public FlashCardSetController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public List<FlashCardSet> Index()
        {
            var FlashCardSets = _context.FlashCardSet.ToList();
            return FlashCardSets;
        }

        [HttpGet("{id}")]
        public FlashCardSet Details(int id)
        {
            FlashCardSet flashcardset =
              _context.FlashCardSet.Where(x => x.FlashCardSetId == id).SingleOrDefault();
            return flashcardset;
        }
 

        [HttpPost]
        public async Task<ActionResult<FlashCardSet>> PostFlashCard(FlashCardSet flashcardset)
        {
            _context.FlashCardSet.Add(flashcardset);
            await _context.SaveChangesAsync();

            return CreatedAtAction("PostFlashCard", new { id = flashcardset.FlashCardSetId }, flashcardset);
        }

        [HttpPost]
        public ActionResult<FlashCardSet> Edit(FlashCardSet flashcardset)
        {
            FlashCardSet oldflashcardset = _context.FlashCardSet.Where(
              x => x.FlashCardSetId == flashcardset.FlashCardSetId).SingleOrDefault();
            if (oldflashcardset != null)
            {
                _context.Entry(oldflashcardset).CurrentValues.SetValues(flashcardset);
                _context.SaveChanges();
            }
            return flashcardset;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlashCardSet(int id)
        {
            var flashcardset = await _context.FlashCardSet.FindAsync(id);
            if (flashcardset == null)
            {
                return NotFound();
            }
            _context.FlashCardSet.Remove(flashcardset);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}