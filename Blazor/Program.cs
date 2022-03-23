using Application.DAOs;
using Application.Logic;
using Blazorise;
using BlazorLoginApp.Authentication;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Contract;
using FileData.DataAccess;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IAuthService, AuthServiceImpl>();
builder.Services.AddScoped<AuthenticationStateProvider, SimpleAuthenticationStateProvider>();
builder.Services.AddScoped<IUserService, UserServiceImpl>();
builder.Services.AddScoped<IUserDAO, UserFileDAO>();
builder.Services.AddScoped<UserFileContext>();
builder.Services.AddScoped<IPostService, PostServiceImpl>();
builder.Services.AddScoped<IPostDAO, PostFileDAO>();
builder.Services.AddScoped<PostFileContext>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();