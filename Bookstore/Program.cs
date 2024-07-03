using Bussiness.IuserBL;
using Bussiness.USERbl;
using Repository.Context;
using Repository.Interface;
using Repository.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("ApiCorsPolicy", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    builder.WithOrigins("http://localhost:4200/", "https://localhost:7086/").AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));
builder.Services.AddSingleton<BookContext>();
builder.Services.AddTransient<IuserRL, UserRL>();
builder.Services.AddTransient<IUserBL, UserBL>();

builder.Services.AddTransient<IBookRL, BookRL>();
builder.Services.AddTransient<IBookBL, BookBL>();

builder.Services.AddTransient<IFeddBackRLcs, FeedBookRL>();
builder.Services.AddTransient<IFeedBackBL, FeedBackBL>();

builder.Services.AddTransient<ICartRL, CartRL>();
builder.Services.AddTransient<ICartBL, CartBL>();

builder.Services.AddTransient<IAddressRL, AddressRl>();
builder.Services.AddTransient<IAddressBL, AddressBL>();

builder.Services.AddTransient<IAttendence, AttendenceRL>();
builder.Services.AddTransient<IAttendenceBL, AttendenceBL>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("ApiCorsPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
