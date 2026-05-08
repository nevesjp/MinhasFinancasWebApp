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
        public string CepConsultaText { get; set; }
        public RegistroCEP CepResult { get; set; }
        public List<RegistroCEP> CepList { get; set; }
        public string UsuarioLogado { get; set; }
        public IActionResult OnGet()
        {
            UsuarioLogado = HttpContext.Session.GetString("UsuarioLogado");

            if (string.IsNullOrEmpty(UsuarioLogado))
            {
                return RedirectToPage("/Login");
            }
            CarregarDados();
            return Page();
        }

        private void CarregarDados()
        {
            CepResult = _buscaCEPService.SetRegistro();
            CepList = _buscaCEPService.Listar();
        }

        public IActionResult OnPostCep() {
            if (ValidarCampos(CepConsultaText))
            {
                TempData["StatusErro"] = "Informe um CEP valido!";
                CarregarDados();
                return Page();
            }

            try
            {
                CepResult = _buscaCEPService.consultaGetCep(CepConsultaText);
                _buscaCEPService.Adicionar(CepResult);
                TempData["StatusSucess"] = $"Consulta ao CEP {CepConsultaText} realizada com sucesso.";
                return RedirectToPage();
            }
            catch (Exception ex) 
            { 
                TempData["StatusErro"] = $"Erro ao consultar o CEP: {ex.Message}";
                CarregarDados();
                return Page();
            }
        }

        private bool ValidarCampos(string campo)
        {
            return string.IsNullOrWhiteSpace(campo);
        }
    }
}
