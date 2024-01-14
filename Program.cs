var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient("TaskApiClient", (c) => {
    c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com");
});

builder.Services.AddHttpClient("EmailApiClient", (c) => {
    c.BaseAddress = new Uri("https://mandrillapp.com/api/1.0/");
});

builder.Services.AddControllers();
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
