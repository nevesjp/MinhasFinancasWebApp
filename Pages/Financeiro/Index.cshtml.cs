using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MinhasFinancasWebApp.Models;
using MinhasFinancasWebApp.Services;

namespace MinhasFinancasWebApp.Pages.Financeiro
{
    public class IndexModel : PageModel
    {
        // injeta o service
        private readonly FinanceiroService _financeiroService;

        public IndexModel(FinanceiroService financeiroService)
        {
            _financeiroService = financeiroService;
        }

        // declara objetos
        [BindProperty]
        public LancamentoFinanceiro NovoLancamento { get; set; }
        public List<LancamentoFinanceiro> Lancamentos { get; set; }
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo { get; set; }
        public string UsuarioLogado { get; set; }
        // onget no carregamento. validar sessao usuario
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
        // no envio do formulario
        public IActionResult OnPost()
        {
            bool campoValidado = ValidarCampos(NovoLancamento.Descricao);
            if (campoValidado) campoValidado = ValidarCampos(NovoLancamento.Categoria);

            if (NovoLancamento.Valor <= 0 || !campoValidado)
            {
                TempData["Erro"] = "Alguns campos precisam ser preenchidos corretamente.";
                CarregarDados();
                return Page();
            }

            _financeiroService.Adicionar(NovoLancamento);

            TempData["Sucesso"] = "Lancamento cadastrado com sucesso.";

            return RedirectToPage();
        }

        public IActionResult OnPostExcluir(Guid id)
        {
            _financeiroService.Remover(id);
            TempData["Sucesso"] = "Lançamento removido com sucesso.";
            return RedirectToPage();
        }

        private bool ValidarCampos(string lancamentoCampo)
        {
            return !string.IsNullOrWhiteSpace(lancamentoCampo);
        }

        private void CarregarDados()
        {
            Lancamentos = _financeiroService.Listar();
            TotalReceitas = _financeiroService.TotalReceitas();
            TotalDespesas = _financeiroService.TotalDespesas();
            Saldo = _financeiroService.Saldo();
        }

        public IActionResult OnPostSair()
        {
            var guidTransacao = Guid.NewGuid().ToString();

            HttpContext.Session.Clear();

            TempData["MensagemSucesso"] = $"Logoff efetuado com sucesso. Transação: {guidTransacao}";

            return RedirectToPage("/Login");
        }
    }
}
