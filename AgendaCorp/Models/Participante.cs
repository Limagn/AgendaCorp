using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaCorp.Models
{
	public class Participante
	{
		public int ParticipanteId { get; set; }
		[Required]
		[DisplayName("Nome Completo")]
		public string Nome { get; set; }
		[DisplayName("E-mail")]
		public string Email { get; set; }
		[Required]
		public string Telefone { get; set; }

		public ICollection<Inscricao> Inscricoes { get; set; }
	}
}
