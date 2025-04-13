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
	}
}
