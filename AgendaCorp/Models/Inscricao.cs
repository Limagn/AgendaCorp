using System.ComponentModel;

namespace AgendaCorp.Models
{
	public class Inscricao
	{
		public int InscricaoId { get; set; }
		[DisplayName("Evento")]
		public int EventoId { get; set; }
		public Evento? Evento { get; set; }

		public int ParticipanteId { get; set; }
		public Participante? Participante { get; set; }
		public DateTime DataInscricao { get; set; }
		public string Status { get; set; }
	}
}
