using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaCorp.Data;
using AgendaCorp.Models;

namespace AgendaCorp.Controllers
{
    public class PalestranteController : Controller
    {
        private readonly AgendaCorpContext _context;

        public PalestranteController(AgendaCorpContext context)
        {
            _context = context;
        }

        // GET: Palestrantes
        public async Task<IActionResult> Index()
        {
            var agendaCorpContext = await _context.Palestrantes
                .Include(p => p.Evento)
                .OrderBy(a => a.Nome)
                .ToListAsync();

            return View(agendaCorpContext);
        }

        // GET: Palestrantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palestrante = await _context.Palestrantes
                .Include(p => p.Evento)
                .FirstOrDefaultAsync(m => m.PalestranteId == id);
            if (palestrante == null)
            {
                return NotFound();
            }

            return View(palestrante);
        }

        // GET: Palestrantes/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome");
            return View();
        }

        // POST: Palestrantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PalestranteId,Nome,Email,Telefone,Area,EventoId")] Palestrante palestrante)
        {
            if (ModelState.IsValid)
            {
                _context.Add(palestrante);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", palestrante.EventoId);
            return View(palestrante);
        }

        // GET: Palestrantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palestrante = await _context.Palestrantes.FindAsync(id);
            if (palestrante == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", palestrante.EventoId);
            return View(palestrante);
        }

        // POST: Palestrantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PalestranteId,Nome,Email,Telefone,Area,EventoId")] Palestrante palestrante)
        {
            if (id != palestrante.PalestranteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(palestrante);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalestranteExists(palestrante.PalestranteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", palestrante.EventoId);
            return View(palestrante);
        }

        // GET: Palestrantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palestrante = await _context.Palestrantes
                .Include(p => p.Evento)
                .FirstOrDefaultAsync(m => m.PalestranteId == id);
            if (palestrante == null)
            {
                return NotFound();
            }

            return View(palestrante);
        }

        // POST: Palestrantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var palestrante = await _context.Palestrantes.FindAsync(id);
            if (palestrante != null)
            {
                _context.Palestrantes.Remove(palestrante);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PalestranteExists(int id)
        {
            return _context.Palestrantes.Any(e => e.PalestranteId == id);
        }
    }
}
