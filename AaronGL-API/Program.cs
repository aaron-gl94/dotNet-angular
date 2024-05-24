using AaronGLAPI.Data;
using AaronGLAPI.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;


services.AddControllers();
builder.Services.AddDbContextFactory<BitacoraStoreContext>(options =>
    options.UseInMemoryDatabase("BitacoraStore")
);

builder.Services.AddHttpClient<SalesServicesApi>();
builder.Services.AddScoped<SalesServicesApi>();

services.AddCors(options => {
    options.AddPolicy("AllowAngularApp", builder => {
        builder.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();

    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowAngularApp");
app.UseAuthorization();
app.MapControllers();

app.Run();