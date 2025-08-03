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
        builder.AllowAnyOrigin()                                            //CORS politikas�n� ekliyoruz.
               .AllowAnyMethod()                                         // Bunu yapmazsak, frontend ile backend aras�nda ileti�im kuramay�z.
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
        builder.RegisterModule(new AutofacBusinessModule());                              //AUTOFAC EKLENMES�
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
app.UseCors("AllowAllOrigins");                  // CORS politikas�n� uyguluyoruz. Bu sayede frontend ile backend aras�nda ileti�im kurabiliyoruz.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
