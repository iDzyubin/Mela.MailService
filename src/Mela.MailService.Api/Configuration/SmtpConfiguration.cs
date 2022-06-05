namespace Mela.MailService.Api.Configuration;

/// <summary>
///     Конфигурация SMTP соединения
/// </summary>
public class SmtpConfiguration
{
    public const string SectionName = "Smtp";
    
    /// <summary>
    ///     Хост
    /// </summary>
    public string Host { get; set; }
    
    /// <summary>
    ///     Порт
    /// </summary>
    public int Port { get; set; }
    
    /// <summary>
    ///     Наименование пользователя
    /// </summary>
    public string UserName { get; set; }
    
    /// <summary>
    ///     Пароль пользователя
    /// </summary>
    public string Password { get; set; }
}