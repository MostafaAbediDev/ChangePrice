using _0_FrameWork.Application;
using ProductManagement.Application;
using ProductManagement.Configuration;
using ProductManagement.Domain.ExchangeRateAgg;
using ProductManagement.Infrastructure.EFCore.Repository;
using ServiceHost;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("PriceChangeDb");

ProductManagementBoostrapper.Configure(builder.Services, connectionString);

builder.Services.AddTransient<IFileUploader, FileUploader>();
builder.Services.AddHttpClient(); 
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.MapControllers();

app.Run();
