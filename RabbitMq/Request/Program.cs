using MassTransit;
using Test.Core.Contracts;

var builder = WebApplication.CreateBuilder(args);

var host = builder.Configuration["MassTransit:Host"];
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder.Services.AddMassTransit(x => 
{
    x.AddBus(context => Bus.Factory.CreateUsingRabbitMq(c =>
    {
        c.Host(host);
        c.ConfigureEndpoints(context);
    }));

    x.AddRequestClient<ProductInfoRequest>();
});
builder.Services.AddMassTransitHostedService();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
