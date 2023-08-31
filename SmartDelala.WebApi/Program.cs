using SmartDelala.Persistence;
using System.Reflection;
using SmartDelala.Application;
using Microsoft.OpenApi.Models;
using Serilog;
using SmartDelala.WebApi.Middlewares;
using SmartDelala.WebApi;
using SmartDelala.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddSingleton<ExceptionHandler>();
builder.Services.ConfigureApplicationService(builder.Configuration);
builder.Services.ConfigurePersistenceService(builder.Configuration);
builder.Services.ConfigureInfrastructureService(builder.Configuration);
builder.Services.AddAuthentication(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Host.UseSerilog();

AddSwaggerDoc(builder.Services);
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(o =>
{
	o.AddPolicy("CorsPolicy",
		builder => builder.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
}

app.UseCors("CorsPolicy");
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SmartDelala.WebApi v1"));

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization(); 

// Use Serilog for logging
app.UseSerilogRequestLogging();
app.UseMiddleware<ExceptionHandler>();

app.MapControllers();

app.Run();

void AddSwaggerDoc(IServiceCollection services)
{
    
    services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "SmartDelala API",
            Version = "v1",
            Description = "SmartDelala API Services",
            Contact = new OpenApiContact
            {
                Name = "SmartDelala Backend Team"
            },
        });
        // use the generated xml file
        c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));

        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "Bearer",
            BearerFormat = "JWT",
            In = ParameterLocation.Header,
            Description = "JWT Authorization header using the Bearer scheme."
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
                new string[] {}
            }
        });
    });
}