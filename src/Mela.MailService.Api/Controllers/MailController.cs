using MailKit.Net.Smtp;
using MailKit.Security;
using Mela.MailService.Api.Configuration;
using Mela.MailService.Api.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Mela.MailService.Api.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class MailController : ControllerBase
{
    private readonly SmtpConfiguration _configuration;

    public MailController(IOptionsMonitor<SmtpConfiguration> options)
    {
        _configuration = options.CurrentValue;
    }
    
    [HttpPost("send")]
    public async Task<IActionResult> SendMessageAsync(SendEmailRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.RecipientEmail))
            return BadRequest("Отсутствуют данные получателя");
    
        if (string.IsNullOrWhiteSpace(request.Content))
            return BadRequest("Отсутствует содержимое письма");

        var message = new MimeMessage
        {
            From = { new MailboxAddress(string.Empty, _configuration.UserName) },
            To = { new MailboxAddress(string.Empty, request.RecipientEmail) },
            Subject = "Результаты исследования",
            Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = request.Content },
        };

        using var client = new SmtpClient();
    
        try
        {
            await client.ConnectAsync(_configuration.Host, _configuration.Port, SecureSocketOptions.SslOnConnect);
            await client.AuthenticateAsync(_configuration.UserName, _configuration.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            return BadRequest($"В ходе отправки сообщения произошла ошибка: {e.Message}");
        }

        return Ok("Сообщение успешно отправлено");
    }
}