using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Ymyp67CvProject.Business.DependencyResolvers.Autofac;
using Ymyp67CvProject.Business.Mappers.AutoMapper;
using Ymyp67CvProject.DataAccess.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(option=>
{
    option.AddPolicy("AllowAllOrigins", builder =>
    {
        builder.AllowAnyOrigin()                                            //CORS politikasýný ekliyoruz.
               .AllowAnyMethod()                                         // Bunu yapmazsak, frontend ile backend arasýnda iletiþim kuramayýz.
               .AllowAnyHeader();
    });
});

builder.Services.AddControllers();
builder.Services.AddDbContext<Ymyp67CvProjectDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MeltemHome"), options =>
    {
        options.MigrationsAssembly(Assembly.GetAssembly(typeof(Ymyp67CvProjectDbContext))!.GetName().Name);
    });
});


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>( builder =>
    {
        builder.RegisterModule(new AutofacBusinessModule());                              //AUTOFAC EKLENMESÝ
    });
builder.Services.AddAutoMapper(typeof(MapProfile).Assembly);


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
app.UseCors("AllowAllOrigins");                  // CORS politikasýný uyguluyoruz. Bu sayede frontend ile backend arasýnda iletiþim kurabiliyoruz.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
