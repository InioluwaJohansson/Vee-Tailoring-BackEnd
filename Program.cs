using Vee_Tailoring.Authentication;
using Vee_Tailoring.Interfaces.Services;
using Vee_Tailoring.Interfaces.Respositories;
using Vee_Tailoring.Implementations.Services;
using Vee_Tailoring.Implementations.Respositories;
using Vee_Tailoring.Emails;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Vee_Tailoring.Context;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Vee_Tailoring;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(x => x.AddPolicy("Policies", c =>
{
    c.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
}));
builder.Services.AddScoped<IArmTypeRepo, ArmTypeRepo>();
builder.Services.AddScoped<ICardRepo, CardRepo>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();
builder.Services.AddScoped<IClothCategoryRepo, ClothCategoryRepo>();
builder.Services.AddScoped<IClothGenderRepo, ClothGenderRepo>();
builder.Services.AddScoped<IColorRepo, ColorRepo>();
builder.Services.AddScoped<ICommentRepo, CommentRepo>();
builder.Services.AddScoped<IComplaintRepo, ComplaintRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<IDefaultPriceRepo, DefaultPriceRepo>();
builder.Services.AddScoped<IMaterialRepo, MaterialRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IPatternRepo, PatternRepo>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepo>();
builder.Services.AddScoped<IPostRepo, PostRepo>();
builder.Services.AddScoped<IRoleRepo, RoleRepo>();
builder.Services.AddScoped<IStyleRepo, StyleRepo>();
builder.Services.AddScoped<IStaffRepo, StaffRepo>();
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<ITemplateRepo, TemplateRepo>();
builder.Services.AddScoped<ITokenRepo, TokenRepo>();
builder.Services.AddScoped<IArmTypeService, ArmTypeService>();
builder.Services.AddScoped<ICardService, CardService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IClothCategoryService, ClothCategoryService>();
builder.Services.AddScoped<IClothGenderService, ClothGenderService>();
builder.Services.AddScoped<IColorService, ColorService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IComplaintService, ComplaintService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IDefaultPriceService, DefaultPriceService>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IPatternService, PatternService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IStaffService, StaffService>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ITemplateService, TemplateService>();
builder.Services.AddScoped<IEmailSend, EmailSender>();
builder.Services.AddHostedService<VBackgroundService>();
builder.Services.AddHttpContextAccessor();
var connectionString = builder.Configuration.GetConnectionString("TailoringContext");
builder.Services.AddDbContext<TailoringContext>(c => c.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Vee Tailoring", Version = "v1" });
});

var key = "Authorization key";
builder.Services.AddSingleton<IJWTAuthentication>(new JWTAuthentication(key));

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = true;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("Policies");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
