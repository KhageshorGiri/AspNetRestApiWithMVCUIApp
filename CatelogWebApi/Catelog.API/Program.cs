using Catelog.API.Configurations;
using Catelog.API.Interfaces;
using Catelog.API.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//adding services as DI
//builder.Services.AddSingleton<IProduct, IProductService>();

BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));

var mongoDbSetting = builder.Configuration.GetSection("MangoDBConfiguration").Get<MongoDBConfiguration>();
builder.Services.AddSingleton<IMongoClient>(serviceProvider =>
{
    return new MongoClient(mongoDbSetting.ConnectionString);
});

// add service to validate the JWT token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "",
            ValidAudience = "",
            IssuerSigningKey = new SymmetricSecurityKey(
                                            Encoding.UTF8.GetBytes("ThisisSecretXKeyThaGeneratETheJWTTokenishdgihsuihiwhj")),
            ClockSkew = TimeSpan.Zero
        };
    });


builder.Services.AddSingleton<IProduct, ProductServiceMongoDb>();
builder.Services.AddSingleton<IUserManagement, UserManagementService>();
builder.Services.AddSingleton<IAuthentication, AuthenticationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();  // added to configure endpoints

//  added in pipelint to perform authentication and authorization for our web api
app.UseAuthentication();
app.UseAuthorization();

// configured by developer
app.UseEndpoints(endpoints => {
    endpoints.MapControllers();

});

// used to map controller action according to request. ##default flow  
//app.MapControllers();

app.Run();
