using Faculdade.Data;
using Faculdade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Faculdade.Controllers
{
    public class EstudanteController : Controller
    {
        private readonly FaculdadeContext _context;

        public EstudanteController(FaculdadeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Estudantes.OrderBy(i => i.Nome).ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome","Curso")] Estudante estudante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(estudante);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Não foi possivel cadastrar o estudante.");
            }
            return View(estudante);
        }

        public async Task<IActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var estudante = await _context.Estudantes.SingleOrDefaultAsync(i => i.Matricula == id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        public bool EstudanteExists(long? id)
        {
            return _context.Estudantes.Any(est => est.Matricula == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(long? id, [Bind("Matricula", "Nome", "Curso")] Estudante estudante)
        {
            if (id != estudante.Matricula)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(estudante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EstudanteExists(estudante.Matricula))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(estudante);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var estudante = await _context.Estudantes.SingleOrDefaultAsync(i => i.Matricula == id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var estudante = await _context.Estudantes.SingleOrDefaultAsync(i => i.Matricula == id);
            if (estudante == null)
            {
                return NotFound();
            }
            return View(estudante);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> DeleteConfirmed(long? id)
        {
            var estudante = await _context.Estudantes.SingleOrDefaultAsync(i => i.Matricula == id);
            _context.Estudantes.Remove(estudante);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
