using System.Text.Encodings.Web;

await _emailSender.SendEmailAsync(
    Input.Email,
    "Redefinição de Senha - Sistema Financeiro",
    $@"
    <h2>Redefinição de senha</h2>

    <p>Olá,</p>

    <p>Recebemos uma solicitação para redefinir sua senha.</p>

    <p>
        Clique no link abaixo para criar uma nova senha:
    </p>

    <p>
        <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>
            Redefinir senha
        </a>
    </p>

    <p>Se você não solicitou isso, ignore este e-mail.</p>

    <hr/>

    <p style='font-size:12px;color:gray;'>
        Sistema Financeiro
    </p>
    ");