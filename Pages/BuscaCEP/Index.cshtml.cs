using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinhasFinancasWebApp.Pages.BuscaCEP
{
    public class IndexModel : PageModel
    {

        const string URILink = "https://cdn.apicep.com/file/apicep/";

        [BindProperty]
        public string cepConsultaText { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostConsulta() {

            if (cepConsultaText == null)
            {
                TempData["MensagemErro"] = "Informe um CEP valido!";
                return Page();
            }

            TempData["MensagemErro"] = "Consulta realizada com sucesso.";
            return Page();
        }
    }
}
