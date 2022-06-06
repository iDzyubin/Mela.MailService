namespace Mela.MailService.Api.Requests;

/// <summary>
///     Запрос с данными для отправки сообщения пациенту
/// </summary>
/// <param name="RecipientEmail">Адрес получателя</param>
/// <param name="Subject">Тема сообщения</param>
/// <param name="Content">Содержимое сообщения</param>
public record SendEmailRequest(string RecipientEmail, string Subject, string Content);