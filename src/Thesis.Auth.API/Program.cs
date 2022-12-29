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
	var smtpClientOptions = builder.Configuration.GetSection(nameof(SmtpClientOptions)).Get<SmtpClientOptions>();
	if (smtpClientOptions == null)
	{
		throw new Exception("SmtpClientOptions is null");
	}
	
	var codeTemplateOptions = builder.Configuration.GetSection(nameof(CodeTemplateOptions)).Get<CodeTemplateOptions>();
	if (codeTemplateOptions == null)
	{
		throw new Exception("CodeTemplateOptions is null");
	}
	builder.Services.AddSingleton<ICodeSender>(new EmailSenderService(smtpClientOptions, codeTemplateOptions));
}

builder.Services.AddSingleton<JwtCreator>();

var app = builder.BuildWebApplication();

app.Run();