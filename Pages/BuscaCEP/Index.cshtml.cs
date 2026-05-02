using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhasFinancasWebApp.Models;
using MinhasFinancasWebApp.Services;

namespace MinhasFinancasWebApp.Pages.BuscaCEP
{
    public class IndexModel : PageModel
    {
        private readonly BuscaCEPService _buscaCEPService;
        public IndexModel(BuscaCEPService buscaCEPService)
        {
            _buscaCEPService = buscaCEPService;
        }

        [BindProperty]
        public string cepConsultaText { get; set; }
        public RegistroCEP cepResult { get; set; }
        public string UsuarioLogado { get; set; }
        public IActionResult OnGet()
        {
            UsuarioLogado = HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(UsuarioLogado))
            {
                return RedirectToPage("/Login");
            }

            return Page();
        }

        public IActionResult OnPost() {
            if (string.IsNullOrWhiteSpace(cepConsultaText))
            {
                TempData["MensagemErro"] = "Informe um CEP valido!";
                return Page();
            }

            cepResult = _buscaCEPService.consultaGetCep(cepConsultaText.ToString());
            TempData["MensagemErro"] = $"CEP Informado: {cepConsultaText.ToString()}";
            return Page();
        }
    }
}
