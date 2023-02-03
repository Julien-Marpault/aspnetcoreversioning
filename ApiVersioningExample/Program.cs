using ApiVersioningExample;
using Asp.Versioning;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
}).AddMvc().AddApiExplorer();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<SwaggerDefaultValues>();
    // retire le paramètre version de la documentation
    options.OperationFilter<RemoveVersionFromParameter>();
    // Remplace v{version} par le numéro de la version correspondant
    options.DocumentFilter<ReplaceVersionWithExactValueInPath>();

});
//builder.Services.AddSwaggerGen(options =>
//{


//options.DocInclusionPredicate((version, desc) =>
//{
//    if (!desc.TryGetMethodInfo(out MethodInfo methodInfo))
//        return false;

//    var versions = methodInfo.DeclaringType
//        .GetCustomAttributes(true)
//        .OfType<ApiVersionAttribute>()
//        .SelectMany(attr => attr.Versions);

//    var maps = methodInfo
//        .GetCustomAttributes(true)
//        .OfType<MapToApiVersionAttribute>()
//        .SelectMany(attr => attr.Versions)
//        .ToArray();

//    return versions.Any(v => $"v{v.ToString()}" == version) && (!maps.Any() || maps.Any(v => $"v{v.ToString()}" == version));
//});
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(
    options =>
    {
        foreach (var description in app.DescribeApiVersions())
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName);
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
