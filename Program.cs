global using FastEndpoints;
global using FastEndpoints.Security;
using FastEndpoints.Swagger;
using MongoDB.Entities;

var bld = WebApplication.CreateBuilder();
bld.Services
   .AddAuthenticationJwtBearer(o=>o.SigningKey = bld.Configuration["JWTSigningKey"])
   .AddAuthorization()
   .AddFastEndpoints()
   .SwaggerDocument(o=>o.AutoTagPathSegmentIndex = 2);

var app = bld.Build();
app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();

await DB.InitAsync(app.Configuration["MongoAddress"] ?? "localhost");

app.Run();