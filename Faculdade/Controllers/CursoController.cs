using Faculdade.Data;
using Faculdade.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Faculdade.Controllers
{
    public class CursoController : Controller
    {
        private readonly FaculdadeContext _context;

        public CursoController(FaculdadeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Cursos.OrderBy(i => i.Nome).ToListAsync());
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome")] Curso curso)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(curso);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            catch(DbUpdateException) 
            {
                ModelState.AddModelError("", "Não foi possivel cadastrar o curso.");
            }
            return View(curso);
        }

        public async Task<IActionResult> Edit(long id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.SingleOrDefaultAsync(i => i.CursoId == id);
            if(curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        public bool CursoExists(long? id)
        {
            return _context.Cursos.Any(cur => cur.CursoId == id);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(long? id,[Bind("CursoId", "Nome")] Curso curso) 
        {
            if (id != curso.CursoId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CursoExists(curso.CursoId))
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
            return View(curso);
        }

        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.SingleOrDefaultAsync(i => i.CursoId == id );
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var curso = await _context.Cursos.SingleOrDefaultAsync(i => i.CursoId == id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> DeleteConfirmed(long? id)
        {
            var curso = await _context.Cursos.SingleOrDefaultAsync(i => i.CursoId == id);
            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
