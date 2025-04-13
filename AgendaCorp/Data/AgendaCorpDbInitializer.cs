using AgendaCorp.Models;

namespace AgendaCorp.Data
{
	public class AgendaCorpDbInitializer
	{
		public static void Initializer(AgendaCorpContext context)
		{
			context.Database.EnsureCreated();
			if (context.Eventos.Any())
			{
				return;
			}
			var eventos = new Evento[]
			{
				new Evento { Nome = "Evento 1", Data = DateTime.Now, Local = "Local 1", Modalidade = "Presencial"},
				new Evento { Nome = "Evento 2", Data = DateTime.Now.AddDays(1), Local = "Local 2", Modalidade =	"Online" }
			};
			foreach (var evento in eventos)
			{
				context.Eventos.Add(evento);
				context.SaveChanges();
			}
		}
	}
}
