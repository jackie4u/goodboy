using GoodBoy.Api.Persistence;
using Microsoft.EntityFrameworkCore;
using FastEndpoints;
using GoodBoy.Api.Features.Offerings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<GoodBoyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// builder.Services.AddControllers();
// builder.Services.AddOpenApi();
builder.Services.AddFastEndpoints();

// Services

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    //app.MapOpenApi();
//    app.MapFastEndpoints();
//}

app.UseHttpsRedirection();

// app.MapControllers();
app.UseFastEndpoints();
// app.UseAuthorization();

app.Run();