using HWFirst.Abstractions;
using HWFirst.Options;
using HWFirst.Services;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<ApiOptions>(builder.Configuration.GetSection(nameof(ApiOptions)));

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IMovieService, OMDBMovieService>();

WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseStatusCodePagesWithRedirects("/Home/Error?code={0}");
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.MapDefaultControllerRoute();

app.Run();
