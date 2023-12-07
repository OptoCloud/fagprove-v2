using backend.Database;
using backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    string[] defaultOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>()!;

    options.AddDefaultPolicy(builder => builder
        .WithOrigins(defaultOrigins)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
    );
});

builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("Database"));
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<INoteService, NoteService>();
builder.Services.AddScoped<IDirectoryService, DirectoryService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Note Keeper", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT Authorization header using the Bearer scheme. 
            Enter 'Bearer' [space] and then your token in the text input below.
            Example: 'Bearer 12345abcdef'",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

// Authentication middleware
app.Use(async (context, next) =>
{
    // Get the Authorization header from the request and check if it starts with "Bearer "
    var token = context.Request.Headers["Authorization"].FirstOrDefault();
    if (token?.StartsWith("Bearer ") ?? false)
    {
        // Split the token by the first space and get the second half
        token = token.Split(' ', 2).Last();

        // Find the user by the Authorization token
        var userService = context.RequestServices.GetRequiredService<IUserService>();
        var user = await userService.GetUserByTokenAsync(token);

        // If the user exists, add it to the context items so we can access it in the controllers
        if (user.TryPickT0(out var userEntity, out _))
        {
            context.Items["User"] = userEntity;
        }
    }

    await next();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
