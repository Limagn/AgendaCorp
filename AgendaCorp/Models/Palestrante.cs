﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaCorp.Models
{
	public class Palestrante
	{
		public int PalestranteId { get; set; }
		[Required]
		[DisplayName("Nome Completo")]
		public string Nome { get; set; }
		[DisplayName("E-mail")]
		public string Email { get; set; }
		public string Telefone { get; set; }
		[Required]
		[DisplayName("Área de Atuação")]
		public string Area { get; set; }

		public int EventoId { get; set; }
		public Evento Evento { get; set; }

	}
}
