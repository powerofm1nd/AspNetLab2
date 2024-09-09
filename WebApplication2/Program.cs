//ASP.NET LAB2 309 group E.Baranovskiy

using WebApplication2.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<ICompanySelector, CompanySelector>();

//Task1
//JSON
builder.Configuration.AddJsonFile("CustomConfig/Apple.json");
builder.Configuration["company_" + builder.Configuration["name"]] = builder.Configuration["employees"];
//XML
builder.Configuration.AddXmlFile("CustomConfig/Google.xml");
builder.Configuration["company_" + builder.Configuration["name"]] = builder.Configuration["employees"];
//INI
builder.Configuration.AddIniFile("CustomConfig/Microsoft.ini");
builder.Configuration["company_" + builder.Configuration["name"]] = builder.Configuration["employees"];

//Task 2
builder.Configuration.AddJsonFile("CustomConfig/Creator.json");

var app = builder.Build();

//Task 1
app.Use(async (context, next) =>
{
    var companySelectorService = app.Services.GetService<ICompanySelector>();
    await context.Response.WriteAsync("Biggest company: \n");
    await context.Response.WriteAsync(companySelectorService.GetBiggestCompany().ToString() + "\n");
    await next();
});

//Task 2
app.Use(async (context, next) =>
{
    await context.Response.WriteAsync($"Creator: {app.Configuration["creator_name"]} Group: {app.Configuration["creator_group"]}\n");
    await next();
});

app.Run();