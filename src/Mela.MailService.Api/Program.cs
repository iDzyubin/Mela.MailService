using Mela.MailService.Api.Configuration;

var builder = WebApplication.CreateBuilder(args);

var smtpSection = builder.Configuration.GetSection(SmtpConfiguration.SectionName);
builder.Services.Configure<SmtpConfiguration>(smtpSection);
builder.Services.Configure<RouteOptions>(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

