using System.Data;
using codecord_api;
using codecord_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient("TaskApiClient", (c) => {
    c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
});

builder.Services.AddHttpClient("EmailApiClient", (c) => {
    c.BaseAddress = new Uri("https://mandrillapp.com/api/1.0/");
});

builder.Services.AddControllers();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IUsersService, UsersService>();
// Add mapper
// builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    DbContextOptionsBuilder dbContextOptionsBuilder = options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
