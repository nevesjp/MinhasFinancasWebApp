using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MinhasFinancasWebApp.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username{ get; set; }
        [BindProperty]
        public string Password{ get; set; }
        public string MensagemErro{ get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (Username == "admin" &&  Password == "admin")
            {
                HttpContext.Session.SetString("UsuarioLogado", Username);

                return RedirectToPage("/Menu");
            }

            MensagemErro = "Usuário ou senha inválidos";
            return Page();
        }
    }
}
