using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Configuration.AddJsonFile("Ocelot.json");

builder.Services.AddOcelot();
    //.AddDelegatingHandler(() => new HttpClientHandler
    //{
    //    ServerCertificateCustomValidationCallback =
    //        HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
    //}, true);
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("gcfgytgyggygyuuguguugguguguguguuguguguguguguugughyuygfufyuf"))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();   // ?? MUST
app.UseAuthorization();

await app.UseOcelot();     // ?? LAST

app.Run();