//Construtor da aplicacao (basicamente a gente esta criando a aplicacao web para esse codigo)
var builder = WebApplication.CreateBuilder(args);


//Permite qu a API entenda e responda com arquivos JSON
builder.Services.AddOpenApi();

//Registra o servicos de Controllers 
builder.Services.AddControllers();


//Configurando as repostas e envios da API
builder.Services.AddCors(options =>
{
    options.AddPolicy("MinhaPoliticaDeAcesso", policy =>
    {
       //Colocando politicas de acesso, permisoes http, e do header da requisicao
       policy.AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader(); 
    });
});


//Criando o app (coisa  que vai ser usado no resto do codigo)
var app = builder.Build();




//IMPORTANTE: dessa parte do app pra baixo  vai ser apenas comportamentos que vao ser feitos
//Em cima criacao, injecao de dependencias e tudo mais, depois configuracao de comportamento



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//Redireciona http para https
app.UseHttpsRedirection();

app.UseCors("MinhaPoliticaDeAcesso");

//Diz para a API procurar as rotas dentro da Controller
app.MapControllers();


//Roda a aplicacao
app.Run();
