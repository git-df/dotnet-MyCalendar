using Application;
using Microsoft.AspNetCore.Authentication.Cookies;
using Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddPersistance(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(op => {
        op.Cookie.Name = "mcAuth";
        op.LoginPath = "/Auth/SignIn";
        op.ExpireTimeSpan = TimeSpan.FromMinutes(20);
        op.AccessDeniedPath = "/Calendar/Index";
    });

builder.Services.AddAuthorization(op => {
    //[Authorize(Policy = "User")]
    op.AddPolicy("User",
        policy => policy
        .RequireClaim("Id")
        .RequireClaim("Email")
        .RequireClaim("FirstName")
        .RequireClaim("LastName"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
