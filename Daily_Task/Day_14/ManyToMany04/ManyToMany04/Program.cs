using ManyToMany04.Interface;
using ManyToMany04.Model;
using ManyToMany04.Repository;
using ManyToMany04.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BookDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("Payoda")));
builder.Services.AddScoped<IBook, BookRepository>();
builder.Services.AddScoped<BookService>();
builder.Services.AddScoped<IAuthor, AuthorRepository>();
builder.Services.AddScoped<AuthorService>();



builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{ opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore; }); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

app.UseAuthorization();

app.MapControllers();

app.Run();
