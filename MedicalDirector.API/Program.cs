using AutoMapper;
using MedicalDirector.API.DTOs.Profiles;
using MedicalDirector.Services;

var builder = WebApplication.CreateBuilder(args);
var AllowCorsLocalhost = "_allowCorsLocalhost";

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCorsLocalhost,
                      policy =>
                      {
                          policy.WithOrigins("https://localhost:4200");
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient();
builder.Services.AddScoped<IExternalService, ExternalService>();
builder.Services.AddScoped<MedicalDirector.API.Services.UserService>();

// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowCorsLocalhost);

app.UseAuthorization();

app.MapControllers();

app.Run();
