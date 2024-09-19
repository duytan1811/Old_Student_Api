#pragma warning disable SA1200 // Using directives should be placed correctly
using System.Text;
using STM.Common.Constants;
using STM.DataAccess.Contexts;
using STM.Entities.Models;
using STM.Repositories;
#pragma warning disable SA1210 // Using directives should be ordered alphabetically by namespace
using STM.Services.IServices;
using STM.Services.Services;
#pragma warning restore SA1210 // Using directives should be ordered alphabetically by namespace
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using STM.API;
#pragma warning restore SA1200 // Using directives should be placed correctly

var builder = WebApplication.CreateBuilder(args);
var loggerFactory = new LoggerFactory();

var connectionString = Environment.GetEnvironmentVariable("DATABASE_URL");
if (string.IsNullOrEmpty(connectionString))
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
}

builder.Services.AddDbContext<STMDbContext>(options =>
   options.UseSqlServer(connectionString, builder => builder.MigrationsAssembly("STM.DataAccess")));

// For Identity
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<STMDbContext>();

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}) // Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        RequireExpirationTime = false,
        ClockSkew = TimeSpan.Zero,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"])),
    };
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "STM.API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    c.OperationFilter<CustomHeaderSwagger>();
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer",
                            },
                        },
                        new string[] { }
                    },
                });
});

// Using AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Using In-memory caching
builder.Services.AddMemoryCache();

builder.Services.Configure<FormOptions>(o =>
{
    o.ValueLengthLimit = int.MaxValue;
    o.MultipartBodyLengthLimit = int.MaxValue;
    o.MemoryBufferThreshold = int.MaxValue;
});

builder.Services.AddDirectoryBrowser();

// Using Distributed cache using Redis
var redisConfiguration = builder.Configuration.GetSection("RedisCache:Configuration").Value;
var redisInstanceName = builder.Configuration.GetSection("RedisCache:InstanceName").Value;
builder.Services.AddStackExchangeRedisCache(option =>
{
    option.Configuration = string.IsNullOrWhiteSpace(redisConfiguration) ? CacheSettings.DistributedRedisConfiguration : redisConfiguration;
    option.InstanceName = string.IsNullOrWhiteSpace(redisInstanceName) ? CacheSettings.DistributedRedisInstanceName : redisInstanceName;
});

builder.Services.AddDirectoryBrowser();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork<STMDbContext>>();

// Add scoped services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDropdownService, DropdownService>();
builder.Services.AddScoped<ISettingService, SettingService>();
builder.Services.AddScoped<IMajorService, MajorService>();

// Add transient services
builder.Services.AddTransient<IActionContextAccessor, ActionContextAccessor>();

// Add singleton services
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddCors();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var initialiser = scope.ServiceProvider.GetRequiredService<STMDbContext>();
        initialiser.Database.Migrate();
    }
    catch (Exception ex)
    {
        var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();

        logger.LogError(ex, "An error occurred during master database initialisation.");

        throw;
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseCors(x => x
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials());

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

loggerFactory.AddLog4Net();

app.MapControllers();

app.Run();
