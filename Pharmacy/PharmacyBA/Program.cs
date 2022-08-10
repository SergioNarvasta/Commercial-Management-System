using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PharmacyBA.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(  
    options => options.AddPolicy("AllowCors",  
        builder => {  
            builder  
            //.WithOrigins("http://localhost:4456") //AllowSpecificOrigins;  
            //.WithOrigins("http://localhost:4456", "http://localhost:4457") //AllowMultipleOrigins;  
                .AllowAnyOrigin() //AllowAllOrigins;  
                //.WithMethods("GET") //AllowSpecificMethods;  
                //.WithMethods("GET", "PUT") //AllowSpecificMethods;  
                //.WithMethods("GET", "PUT", "POST") //AllowSpecificMethods;  
                //.WithMethods("GET", "PUT", "POST", "DELETE") //AllowSpecificMethods;  
                .AllowAnyMethod() //AllowAllMethods;  
                //.WithHeaders("Accept", "Content-type", "Origin", "X-Custom-Header"); //AllowSpecificHeaders;  
                .AllowAnyHeader(); //AllowAllHeaders;  
        })  
);  

builder.Services.AddDbContext<PharmacyBAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PharmacyBAContext") ?? throw new InvalidOperationException("Connection string 'PharmacyBAContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
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

app.UseCors("AllowCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
