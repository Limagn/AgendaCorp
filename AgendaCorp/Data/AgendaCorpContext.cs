using AgendaCorp.Models;
using Microsoft.EntityFrameworkCore;

namespace AgendaCorp.Data
{
	public class AgendaCorpContext : DbContext
	{
		public AgendaCorpContext(DbContextOptions<AgendaCorpContext> options) : base(options)
		{

		}
		public DbSet<Evento> Eventos { get; set; }
		public DbSet<Palestrante> Palestrantes { get; set; }
		public DbSet<Participante> Participantes { get; set; }
		public DbSet<Inscricao> Inscricoes { get; set; }
		public DbSet<PalestranteEvento> PalestranteEventos { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PalestranteEvento>()
				.HasKey(pe => new { pe.PalestranteId, pe.EventoId });
			modelBuilder.Entity<PalestranteEvento>()
				.HasOne(e => e.Palestrante)
				.WithMany(p => p.PalestranteEvento)
				.HasForeignKey(pe => pe.PalestranteId);
			modelBuilder.Entity<PalestranteEvento>()
				.HasOne(e => e.Evento)
				.WithMany(p => p.PalestranteEvento)
				.HasForeignKey(pe => pe.EventoId);
		}
	}
}
