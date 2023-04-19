using EventMgt.Core.Config;
using EventMgt.Repo.Data;
using EventMgt.Repo.Data.GenericRepository.Implementation;
using EventMgt.Repo.Data.GenericRepository.Interface;
using EventMgt.Repo.Data.Repository.Implementation;
using EventMgt.Repo.Data.Repository.Interface;
using EventMgt.Service.Implementation;
using EventMgt.Service.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EventMgtContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.Configure<APIConfig>(builder.Configuration.GetSection("APIConfig"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRepository, UserRepository>(); 
builder.Services.AddScoped<IApplicationUserService, ApplicationUserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>(); 
builder.Services.AddScoped<IEventParticipantService, EventParticipantService>();
builder.Services.AddScoped<IParticipantInvitationService, ParticipantInvitationService>();
builder.Services.AddScoped<IParticipantInvitationRepo, ParticipantInvitationRepo>();
builder.Services.AddMemoryCache();
builder.Services.AddHttpClient();
//builder.Services.AddScoped<IGenericRepository, GenericRepository>();

//void ConfigureServices(IServiceCollection services)
//{
//    services.AddTransient<IUnitOfWork, UnitOfWork>();
//}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
