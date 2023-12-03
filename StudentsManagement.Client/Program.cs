using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using StudentsManagement.Client;
using StudentsManagement.Client.Services;
using StudentsManagement.Shared.StudentRepository;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped<IStudentRepository, StudentService>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)
});


await builder.Build().RunAsync();
