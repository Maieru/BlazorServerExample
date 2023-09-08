using Bussiness.Context;
using Bussiness.Repository.StudentRepository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// To map controller, you need to add this line!!!
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

// Adds an HttpClient that is pre-configured to base address of the site.
builder.Services.AddTransient(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["BaseUrl"]) });

builder.Services.AddDbContextFactory<SchoolContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SchoolDatabase")));

// Adds a scoped Repository. All repository needs to be added this way.
builder.Services.AddScoped<IStudentRepository,  StudentRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// To map controller, you need to add this line!!!
app.MapControllers();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
