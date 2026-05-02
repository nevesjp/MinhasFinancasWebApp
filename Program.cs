using MinhasFinancasWebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// lista de registro das services do app:
builder.Services.AddRazorPages();
builder.Services.AddScoped<FinanceiroService>();
builder.Services.AddScoped<BuscaCEPService>();
//Fim das services

//Cria Sessao
builder.Services.AddSession();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession();

// Pág inicial 
app.MapGet("/", context =>
{
    context.Response.Redirect("/Login");
    return Task.CompletedTask;
});

app.MapRazorPages();

app.Run();
