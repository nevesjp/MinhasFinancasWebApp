using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinhasFinancasWebApp.Pages
{
    public class MenuModel : PageModel
    {
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

        public IActionResult OnPostSair()
        {
            var guidTransacao = Guid.NewGuid().ToString();

            HttpContext.Session.Clear();

            TempData["MensagemSucesso"] = $"Logoff efetuado com sucesso. Transação: {guidTransacao}";

            return RedirectToPage("/Login");
        }
    }
}
