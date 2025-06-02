using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgendaCorp.ViewModels
{
	public class PalestranteViewModel
	{
		public int? PalestranteId { get; set; }

		[Required]
		[DisplayName("Nome Completo")]
		public string Nome { get; set; }

		[DisplayName("E-mail")]
		public string Email { get; set; }

		public string Telefone { get; set; }

		[DisplayName("Área de Atuação")]
		public string Area { get; set; }

		[DisplayName("Eventos")]
		public List<int> EventoIds { get; set; } = new();
		[DisplayName("Eventos")]
		public List<SelectListItem>? EventosSelectList { get; set; }
	}
}
