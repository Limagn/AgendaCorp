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
		public string? Cep { get; set; }
		public string? Logradouro { get; set; }
		public string? Bairro { get; set; }
		public string? Cidade { get; set; }
		[DisplayName("Estado")]
		public string? Uf { get; set; }
		[Required]
		[DisplayName("Data do Evento")]
		public DateTime Data { get; set; }
		public string Modalidade { get; set; }

		public ICollection<PalestranteEvento>? PalestranteEvento { get; set; } = new List<PalestranteEvento>();

		[DisplayName("Inscrições")]
		public ICollection<Inscricao>? Inscricoes { get; set; } = new List<Inscricao>();

	}
}
