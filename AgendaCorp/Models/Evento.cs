using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaCorp.Models
{
	public class Evento
	{
		public int EventoId { get; set; }
		[Required]
		[DisplayName("Nome do Evento")]
		public string Nome { get; set; }
		public string Local { get; set; }
		public string Cidade { get; set; }
		[DisplayName("Estado")]
		public string Uf { get; set; }
		[Required]
		[DisplayName("Data do Evento")]
		public DateTime Data { get; set; }
		public string Modalidade { get; set; }

		public ICollection<Palestrante>? Palestrantes { get; set; } = new List<Palestrante>();
		[DisplayName("Inscrições")]
		public ICollection<Inscricao>? Inscricoes { get; set; } = new List<Inscricao>();

	}
}
