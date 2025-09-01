using Microsoft.EntityFrameworkCore;
using WebApplication8.Data;

var builder = WebApplication.CreateBuilder(args);

// ✅ سجل الـ DbContext وربطه مع SQL Server
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();

// تفعيل Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// --- إضافة CORS ---
// يسمح لأي موقع بالوصول (لتطوير)
// لاحقًا يمكنك تغييره لرابط فرونت محدد فقط
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()   // السماح لأي دومين
              .AllowAnyHeader()
              .AllowAnyMethod();
        // إذا أردت تحديد رابط محدد للفرونت:
        // policy.WithOrigins("http://127.0.0.1:5500")
        //       .AllowAnyHeader()
        //       .AllowAnyMethod();
    });
});

var app = builder.Build();

// تفعيل Swagger في التطوير
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ✅ تفعيل CORS قبل Authorization و MapControllers
app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
