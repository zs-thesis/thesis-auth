using Microsoft.EntityFrameworkCore;
using Thesis.Auth;
using Thesis.Auth.Helpers;
using Thesis.Auth.Options;
using Thesis.Auth.Services;
using Thesis.Services.Common.Helpers;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connectionString));
//AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var codeSenderType = builder.Configuration.GetValue<string>("CodeSenderType");
if (codeSenderType == "Email")
{
	var smtpClientOptions = builder.Configuration.GetSection("SmtpClientOptions").Get<SmtpClientOptions>()!;
	builder.Services.AddSingleton<ICodeSender>(new EmailSenderService(smtpClientOptions));
}

builder.Services.AddSingleton<JwtCreator>();

var app = builder.BuildWebApplication();

app.Run();