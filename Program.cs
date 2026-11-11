
var builder = WebApplication.CreateBuilder(args);

// Serviços da aplicação
builder.Services.AddControllersWithViews();

// Comunicação com a API LogiSmart
builder.Services.AddHttpClient("LogiSmartAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7193/");
});

// Armazenamento das sessões
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

// Autorização será utilizada na proteção das rotas
builder.Services.AddAuthorization();

var app = builder.Build();

// Configuração do ambiente
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// A sessão deve estar disponível antes dos Controllers
app.UseSession();

app.UseAuthorization();

// Arquivos estáticos
app.MapStaticAssets();

// Rota principal
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
