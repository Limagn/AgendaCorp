using AgendaCorp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "AgendaCorp",
	pattern: "{controller=Evento}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "Palestrante",
	pattern: "{controller=Palestrante}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "Participante",
	pattern: "{controller=Participante}/{action=Index}/{id?}");
app.MapControllerRoute(
	name: "Inscricao",
	pattern: "{controller=Inscricao}/{action=Index}/{id?}");

//using (var scope = app.Services.CreateScope())
//{
//	var services = scope.ServiceProvider;
//	try
//	{
//		var context = services.GetRequiredService<AgendaCorpContext>();
//		// AgendaDbInitializer.Initializer(context);
//	}
//	catch (Exception ex)
//	{
//		var logger = services.GetRequiredService<ILogger<Program>>();
//		logger.LogError(ex, "Erro ao popular o banco de dados.");
//	}
//}

app.Run();
