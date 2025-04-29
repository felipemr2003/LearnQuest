using LearnQuest.Aplicacao.Auth.Profiles;
using LearnQuest.Aplicacao.Auth.Servicos;
using LearnQuest.Aplicacao.Auth.Servicos.Interfaces;
using LearnQuest.Aplicacao.Class.Profiles;
using LearnQuest.Aplicacao.Class.Servicos;
using LearnQuest.Aplicacao.Class.Servicos.Interfaces;
using LearnQuest.Aplicacao.Grade.Servicos;
using LearnQuest.Aplicacao.Grade.Servicos.Interfaces;
using LearnQuest.Aplicacao.Parent.Profiles;
using LearnQuest.Aplicacao.Parent.Servicos;
using LearnQuest.Aplicacao.Parent.Servicos.Interfaces;
using LearnQuest.Aplicacao.Student.Profiles;
using LearnQuest.Aplicacao.Student.Servicos;
using LearnQuest.Aplicacao.Student.Servicos.Interfaces;
using LearnQuest.Aplicacao.Subject.Servicos;
using LearnQuest.Aplicacao.Subject.Servicos.Interfaces;
using LearnQuest.Aplicacao.Teacher.Profiles;
using LearnQuest.Aplicacao.Teacher.Servicos;
using LearnQuest.Aplicacao.Teacher.Servicos.Interfaces;
using LearnQuest.Dominio.Auth.Servicos;
using LearnQuest.Dominio.Auth.Servicos.Interfaces;
using LearnQuest.Dominio.Class.Servicos;
using LearnQuest.Dominio.Class.Servicos.Interfaces;
using LearnQuest.Dominio.Grade.Servicos;
using LearnQuest.Dominio.Grade.Servicos.Interfaces;
using LearnQuest.Dominio.Interfaces;
using LearnQuest.Dominio.Parent.Servicos;
using LearnQuest.Dominio.Parent.Servicos.Interfaces;
using LearnQuest.Dominio.Student.Servicos;
using LearnQuest.Dominio.Student.Servicos.Interfaces;
using LearnQuest.Dominio.Subject.Servicos;
using LearnQuest.Dominio.Subject.Servicos.Interfaces;
using LearnQuest.Dominio.Teacher.Servicos;
using LearnQuest.Dominio.Teacher.Servicos.Interface;
using LearnQuest.Infra;
using LearnQuest.Infra.Repositorios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["MySQLConnection:MySQLConnectionString"];
var serverVersion = new MariaDbServerVersion(new Version(10, 4, 17)); // Versão exata do seu MariaDB
builder.Services.AddDbContext<LearnQuestDbContext>(options => options.UseMySql(connectionString, serverVersion));

builder.Services.AddScoped(typeof(IRepositorio<>), typeof(Repositorio<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IParentServico, ParentServico>();
builder.Services.AddScoped<IStudentServico, StudentServico>();
builder.Services.AddScoped<ITeacherServico, TeacherServico>();
builder.Services.AddScoped<IClasseServico, ClasseServico>();
builder.Services.AddScoped<ISubjectServico, SubjectServico>();
builder.Services.AddScoped<IGradeServico, GradeServico>();
builder.Services.AddScoped<IAuthServico, AuthServico>();


builder.Services.AddScoped<IParentAppServico, ParentAppServico>();
builder.Services.AddScoped<IStudentAppServico, StudentAppServico>();
builder.Services.AddScoped<ITeacherAppServico, TeacherAppServico>();
builder.Services.AddScoped<IClassAppServico, ClassAppServico>();
builder.Services.AddScoped<ISubjectAppServico, SubjectAppServico>();
builder.Services.AddScoped<IGradeAppServico, GradeAppServico>();
builder.Services.AddScoped<IAuthAppServico, AuthAppServicos>();

// builder.Services.AddAutoMapper(
//     typeof(ClassProfile)
// // typeof(StudentProfile),
// // typeof(ParentProfile),
// // typeof(TeacherProfile),
// // typeof(SubjectProfile),
// // typeof(GradeProfile)
// );

builder.Services.AddAutoMapper(
    typeof(ParentProfile),
    typeof(StudentProfile),
    typeof(ClassProfile),
    typeof(AuthProfile),
    typeof(TeacherProfile)
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Optionally disable HTTPS redirection in development to avoid the warning
}
else
{
    app.UseHttpsRedirection();
}
app.UseCors(MyAllowSpecificOrigins);

app.MapControllers();

app.Run();

