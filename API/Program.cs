using API.Data;
using Microsoft.EntityFrameworkCore;
using Restore.API.BL;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ProductServices, ProductServices>();
// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();

// Configure CORS
app.UseCors(builder => builder
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithOrigins("https://localhost:3000"));

// // Configure the HTTP request pipeline.
// if (app.Environment.IsDevelopment())
// {
//     app.UseSwagger();
//     app.UseSwaggerUI();
// }

// app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

DbSeeding.InitData(app);

app.Run();
