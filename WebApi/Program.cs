using DAL;
using BLL;
using BLL.algorithm.Naive_Bayes_classifier;
using BLL.algorithm;
using BLL.algorithm.text_analysis;

using Microsoft.SqlServer.Server;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy("policy", builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped(typeof(CategoriesIDAL), typeof(CategoriesDAL));
builder.Services.AddScoped(typeof(CategoriesIBLL), typeof(CategoriesBLL));
builder.Services.AddScoped(typeof(WordsToCategoriesIDAL), typeof(WordsToCategoriesDAL));
builder.Services.AddScoped(typeof(WordsToCategoriesIBLL), typeof(WordsToCategoriesBLL));
builder.Services.AddScoped(typeof(ArticalsIDAL), typeof(ArticasDAL));
builder.Services.AddScoped(typeof(ArticelsIBLL), typeof(ArticelsBLL));
builder.Services.AddScoped(typeof(UsersIDAL), typeof(UsersDAL));
builder.Services.AddScoped(typeof(UsersIBLL), typeof(UsersBLL));
builder.Services.AddScoped(typeof(VocabularyToAriacleIDAL), typeof(VocabularyToAriacleDAL));
builder.Services.AddScoped(typeof(VocabularyToAriacleIBLL), typeof(VocabularyToAriacleBLL));
builder.Services.AddScoped(typeof(ArticaleToUserIDAL), typeof(ArticaleToUserDAL));
builder.Services.AddScoped(typeof(ArticaleToUserIBLL), typeof(ArticaleToUserBLL));
builder.Services.AddScoped(typeof(LevelIDAL), typeof(LevelDAL));
builder.Services.AddScoped(typeof(LevelIBLL), typeof(LevelBLL));
builder.Services.AddScoped(typeof(Itest), typeof(Test));
builder.Services.AddScoped(typeof(INaiveBasesAlgorithm), typeof(NaiveBasesAlgorithm));
builder.Services.AddScoped(typeof(ISortArical), typeof(SortArical));
builder.Services.AddScoped(typeof(IBuildProbilityMatrix), typeof(BuildProbilityMatrix));
builder.Services.AddScoped(typeof(ItraningModel), typeof(traningModel));
builder.Services.AddScoped(typeof(IDeleteArticle), typeof(DeleteArticle));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("policy");

app.MapControllers();

app.Run();
