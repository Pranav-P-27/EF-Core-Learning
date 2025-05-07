using Microsoft.EntityFrameworkCore;
using ProductShop.Infrastructure.DbContexts;
using ProductShop.Infrastructure;
using ProductShop.Application;
using ProductShop.Infrastructure.Common;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddCors(options => { 
    options.AddPolicy("CustomPolicy", x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

#region DataBase Connecitivity
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Data Seeding
static async void UpdateDatabaseAsync(IHost host)
{
    using(var scope = host.Services .CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var context = services.GetRequiredService<ApplicationDbContext>();
            if (context.Database.IsSqlServer())
            {
                context.Database.Migrate();
            }
            await SeedData.SeedDataAsync(context);

        }
        catch (Exception ex)
        {

        }
    }
}
#endregion

var app = builder.Build();
UpdateDatabaseAsync(app);
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");
app.UseCors("CustomPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
