using Microsoft.AspNetCore.Mvc;


namespace AgendaCorp.Controllers
{
    public class EnderecoController : Controller
    {
        [HttpGet]
		public async Task<IActionResult> BuscarPorCep(string cep)
        {
            if (string.IsNullOrEmpty(cep))
			{
				return BadRequest("CEP não pode ser vazio.");
			}

            using (var client = new HttpClient())
            {
                var url = $"https://viacep.com.br/ws/{cep}/json/";
				var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
			    {
				    return BadRequest("CEP não encontrado.");
			    }

                var json = await response.Content.ReadAsStringAsync();
                return Content(json, "application/json");
			}
        }
    }
}
