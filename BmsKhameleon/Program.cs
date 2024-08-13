using BmsKhameleon.Core.Domain.RepositoryContracts;
using BmsKhameleon.Core.ServiceContracts;
using BmsKhameleon.Core.Services;
using BmsKhameleon.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddHsts(options =>
{
    options.Preload = true;
    options.IncludeSubDomains = true;
    options.MaxAge = TimeSpan.FromDays(365);
});

//DbContext
builder.Services.AddDbContext<AccountDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//services
//builder.Services.AddScoped<IAccountsService, AccountsService>();
//builder.Services.AddScoped<ITransactionsService, TransactionsService>();

//build
var app = builder.Build();

app.MapControllers();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Run();
