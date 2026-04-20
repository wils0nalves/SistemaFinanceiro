using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SistemaFinanceiro.Areas.Identity.Pages.Account.Manage
{
    public class ResetAuthenticatorModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<ResetAuthenticatorModel> _logger;

        public ResetAuthenticatorModel(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            ILogger<ResetAuthenticatorModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [TempData]
        public string StatusMessage { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            // 🔥 Desativa 2FA
            await _userManager.SetTwoFactorEnabledAsync(user, false);

            // 🔥 Gera nova chave do autenticador
            await _userManager.ResetAuthenticatorKeyAsync(user);

            var userId = await _userManager.GetUserIdAsync(user);

            _logger.LogInformation("Usuário com ID '{UserId}' redefiniu a chave do autenticador.", userId);

            // 🔥 Atualiza sessão
            await _signInManager.RefreshSignInAsync(user);

            // 🔥 Mensagem amigável (PT-BR)
            StatusMessage = "A chave do autenticador foi redefinida. Configure novamente seu aplicativo de autenticação.";

            // 🔥 Redireciona pra configurar novamente
            return RedirectToPage("./EnableAuthenticator");
        }
    }
}