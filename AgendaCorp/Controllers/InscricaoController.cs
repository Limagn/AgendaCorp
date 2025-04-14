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
    public class InscricaoController : Controller
    {
        private readonly AgendaCorpContext _context;

        public InscricaoController(AgendaCorpContext context)
        {
            _context = context;
        }

        // GET: Inscricao
        public async Task<IActionResult> Index()
        {
            var agendaCorpContext = _context.Inscricoes.Include(i => i.Evento).Include(i => i.Participante);
            return View(await agendaCorpContext.ToListAsync());
        }

        // GET: Inscricao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .Include(i => i.Evento)
                .Include(i => i.Participante)
                .FirstOrDefaultAsync(m => m.InscricaoId == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // GET: Inscricao/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome");
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "ParticipanteId", "Nome");
            return View();
        }

        // POST: Inscricao/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscricaoId,EventoId,ParticipanteId,DataInscricao,Status")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "ParticipanteId", "Nome", inscricao.ParticipanteId);
            return View(inscricao);
        }

        // GET: Inscricao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "ParticipanteId", "Nome", inscricao.ParticipanteId);
            return View(inscricao);
        }

        // POST: Inscricao/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscricaoId,EventoId,ParticipanteId,DataInscricao,Status")] Inscricao inscricao)
        {
            if (id != inscricao.InscricaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricaoExists(inscricao.InscricaoId))
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
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "ParticipanteId", "Nome", inscricao.ParticipanteId);
            return View(inscricao);
        }

        // GET: Inscricao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricoes
                .Include(i => i.Evento)
                .Include(i => i.Participante)
                .FirstOrDefaultAsync(m => m.InscricaoId == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscricoes.Any(e => e.InscricaoId == id);
        }
    }
}
