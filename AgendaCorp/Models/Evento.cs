﻿using System.ComponentModel;
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
		[Required]
		public DateTime Data { get; set; }
		public string Modalidade { get; set; }

		public virtual ICollection<Palestrante>? Palestrantes { get; set; } = new List<Palestrante>();
		public virtual ICollection<Inscricao>? Inscricoes { get; set; } = new List<Inscricao>();

	}
}
