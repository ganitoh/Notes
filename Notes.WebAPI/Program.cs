using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Notes.Application;
using Notes.Persistance;

var builder = WebApplication.CreateBuilder(args);

#region Services
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddApplicationServices();
builder.Services.AddPersistanceServices();
builder.Services.AddPostgreSQL(
    builder.Configuration["ConnectionStrings:PostgreSQL"]!);
#endregion

var app = builder.Build();

#region Middleware
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseDefaultFiles(new DefaultFilesOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html"))
});
app.UseStaticFiles(new StaticFileOptions()
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "html"))
});


#endregion


app.Run();
