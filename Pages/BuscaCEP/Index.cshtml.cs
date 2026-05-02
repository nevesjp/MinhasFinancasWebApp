using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhasFinancasWebApp.Services;

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

        public IActionResult OnPost() {
            if (string.IsNullOrWhiteSpace(cepConsultaText))
            {
                TempData["MensagemErro"] = "Informe um CEP valido!";
                return Page();
            }

            TempData["MensagemErro"] = $"CEP Informado: {cepConsultaText.ToString()}";
            return Page();
        }
    }
}
