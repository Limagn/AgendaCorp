using System.ComponentModel;

namespace AgendaCorp.Models
{
	public class Inscricao
	{
		public int InscricaoId { get; set; }
		[DisplayName("Evento")]
		public int EventoId { get; set; }
		public Evento? Evento { get; set; }
		[DisplayName("Participante")]
		public int ParticipanteId { get; set; }
		public Participante? Participante { get; set; }
		[DisplayName("Data de Inscrição")]
		public DateTime DataInscricao { get; set; } = DateTime.Now;
		public string Status { get; set; }
	}
}
