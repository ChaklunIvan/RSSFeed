using RSSFeed.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

//Configure services
builder.Services.AddControllers()
       .Services.AddSwaggerGenerator()
       .ConfigureSqliteContext(builder.Configuration)
       .AddServiceConfiguration()
       .AddAutoMapper(typeof(Program))
       .ConfigureIdentity();

var app = builder.Build();

//Configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();
