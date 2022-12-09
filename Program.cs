global using FastEndpoints;
global using FastEndpoints.Security;
using FastEndpoints.Swagger;
using MongoDB.Entities;

var builder = WebApplication.CreateBuilder();
builder.Services.AddFastEndpoints();
builder.Services.AddAuthenticationJWTBearer(builder.Configuration["JWTSigningKey"]!);
builder.Services.AddSwaggerDoc(tagIndex: 2);

var app = builder.Build();
app.UseAuthentication();
app.UseAuthorization();
app.UseFastEndpoints();
app.UseSwaggerGen();

await DB.InitAsync(app.Configuration["MongoAddress"]);

app.Run();
