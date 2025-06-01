using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgendaCorp.Data;
using AgendaCorp.Models;
using AgendaCorp.ViewModels;

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
				.Include(pe => pe.PalestranteEvento).ThenInclude(p => p.Evento)
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
                .Include(pe => pe.PalestranteEvento).ThenInclude(p => p.Evento)
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
            var viewModel = new PalestranteViewModel
            {
                EventosSelectList = _context.Eventos
                    .Select(e => new SelectListItem
                    {
                        Value = e.EventoId.ToString(),
                        Text = e.Nome
                    }).ToList()
            };
            //ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome");
            return View(viewModel);
        }

        // POST: Palestrantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PalestranteViewModel model)
        {
            if (ModelState.IsValid)
            {
                var palestrante = new Palestrante
                {
                    Nome = model.Nome,
                    Email = model.Email,
                    Telefone = model.Telefone,
                    Area = model.Area,
                };

                _context.Palestrantes.Add(palestrante);
                await _context.SaveChangesAsync();

                foreach (var eventoId in model.EventoIds)
                {
                    _context.PalestranteEventos.Add(new PalestranteEvento
                    {
                        PalestranteId = palestrante.PalestranteId,
                        EventoId = eventoId
                    });
                }

				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
            }

            model.EventosSelectList = _context.Eventos
                .Select(e => new SelectListItem
                {
                    Value = e.EventoId.ToString(),
					Text = e.Nome
				}).ToList();

			//ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", palestrante.PalestranteEvento);
			return View(model);
        }

        // GET: Palestrantes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palestrante = await _context.Palestrantes
                .Include(p => p.PalestranteEvento)
                .FirstOrDefaultAsync(p => p.PalestranteId == id);

            if (palestrante == null)
            {
                return NotFound();
            }

            var viewModel = new PalestranteViewModel
            {
                PalestranteId = palestrante.PalestranteId,
                Nome = palestrante.Nome,
                Email = palestrante.Email,
                Telefone = palestrante.Telefone,
                Area = palestrante.Area,
                EventoIds = palestrante.PalestranteEvento
                    .Select(pe => pe.EventoId)
                    .ToList(),
                EventosSelectList = _context.Eventos
                    .Select(e => new SelectListItem
                    {
                        Value = e.EventoId.ToString(),
                        Text = e.Nome
                    }).ToList()
            };

            //ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", palestrante.PalestranteEvento);
            return View(viewModel);
        }

        // POST: Palestrantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PalestranteViewModel model)
        {
            if (id != model.PalestranteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var palestrante = await _context.Palestrantes
						.Include(p => p.PalestranteEvento)
						.FirstOrDefaultAsync(p => p.PalestranteId == id);

                    if (palestrante == null)
					{
						return NotFound();
					}

                    palestrante.Nome = model.Nome;
                    palestrante.Email = model.Email;
					palestrante.Telefone = model.Telefone;
                    palestrante.Area = model.Area;

                    _context.PalestranteEventos.RemoveRange(palestrante.PalestranteEvento);

                    foreach (var eventoId in model.EventoIds)
                    {
                        _context.PalestranteEventos.Add(new PalestranteEvento
                        {
                            PalestranteId = palestrante.PalestranteId,
                            EventoId = eventoId
						});
                    }

                    
                    await _context.SaveChangesAsync();
    				return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PalestranteExists((int)model.PalestranteId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, $"Ocorreu um erro ao atualizar o palestrante: {ex.Message}");

					model.EventosSelectList = await _context.Eventos
				        .Select(e => new SelectListItem
				        {
					        Value = e.EventoId.ToString(),
					        Text = e.Nome
				        }).ToListAsync();

					return View(model);
				}
            }

			model.EventosSelectList = await _context.Eventos
				.Select(e => new SelectListItem
				{
					Value = e.EventoId.ToString(),
					Text = e.Nome
				}).ToListAsync();

            //ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", palestrante.PalestranteEvento);
            return View(model);
		}

        // GET: Palestrantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var palestrante = await _context.Palestrantes
                .Include(pe => pe.PalestranteEvento).ThenInclude(p => p.Evento)
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
