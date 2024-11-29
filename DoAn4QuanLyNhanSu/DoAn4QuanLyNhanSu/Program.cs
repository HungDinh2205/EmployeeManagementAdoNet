using BUS.Interfaces;
using DAL.Helper.Interface;
using DAL.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using BUS;
using DAL;
using DAO.Helper;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ITruyVanDuLieu, TruyVanDuLieu>();
builder.Services.AddTransient<IDantocDAL, DantocDAL>();
builder.Services.AddTransient<IDantocBUS, DantocBUS>();
builder.Services.AddTransient<ITongiaoDAL, TongiaoDAL>();
builder.Services.AddTransient<ITongiaoBUS, TongiaoBUS>();
builder.Services.AddTransient<IPhongbanDAL, PhongbanDAL>();
builder.Services.AddTransient<IPhongbanBUS, PhongbanBUS>();
builder.Services.AddTransient<ILoaicongDAL, LoaicongDAL>();
builder.Services.AddTransient<ILoaicongBUS, LoaicongBUS>();
builder.Services.AddTransient<ILoaicaDAL, LoaicaDAL>();
builder.Services.AddTransient<ILoaicaBUS, LoaicaBUS>();
builder.Services.AddTransient<INhanvienDAL, NhanvienDAL>();
builder.Services.AddTransient<INhanvienBUS, NhanvienBUS>();
builder.Services.AddTransient<IBangcongDAL, BangcongDAL>();
builder.Services.AddTransient<IBangcongBUS, BangcongBUS>();
builder.Services.AddTransient<ITrinhdoDAL, TrinhdoDAL>();
builder.Services.AddTransient<ITrinhdoBUS, TrinhdoBUS>();
builder.Services.AddTransient<IChucvuDAL, ChucvuDAL>();
builder.Services.AddTransient<IChucvuBUS, ChucvuBUS>();
builder.Services.AddTransient<IBophanDAL, BophanDAL>();
builder.Services.AddTransient<IBophanBUS, BophanBUS>();
builder.Services.AddTransient<IPhucapDAL, PhucapDAL>();
builder.Services.AddTransient<IPhucapBUS, PhucapBUS>();
builder.Services.AddTransient<IBaohiemDAL, BaohiemDAL>();
builder.Services.AddTransient<IBaohiemBUS, BaohiemBUS>();
builder.Services.AddTransient<IHopdongDAL, HopdongDAL>();
builder.Services.AddTransient<IHopdongBUS, HopdongBUS>();
builder.Services.AddTransient<ITangcaDAL, TangcaDAL>();
builder.Services.AddTransient<ITangcaBUS, TangcaBUS>();
builder.Services.AddTransient<INhanvienPhucapDAL, NhanvienPhucapDAL>();
builder.Services.AddTransient<INhanvienPhucapBUS, NhanvienPhucapBUS>();
builder.Services.AddTransient<IUngluongDAL, UngluongDAL>();
builder.Services.AddTransient<IUngluongBUS, UngluongBUS>();
builder.Services.AddTransient<IKhenthuongKyluatDAL, KhenthuongKyluatDAL>();
builder.Services.AddTransient<IKhenthuongKyluatBUS, KhenthuongKyluatBUS>();
builder.Services.AddTransient<IChamcongDAL, ChamcongDAL>();
builder.Services.AddTransient<IChamcongBUS, ChamcongBUS>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new DateOnlyJsonConverter());
    });
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new TimeOnlyJsonConverter());
    });
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
