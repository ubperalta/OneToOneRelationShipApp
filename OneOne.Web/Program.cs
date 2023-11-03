using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using OneOne.Web;
using Syncfusion.Blazor;
using Microsoft.Extensions.Http;
using OneOne.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NHaF5cWWBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdgWH5ec3RVQ2deVkN/WEM=");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7121/") });

//builder.Services.AddHttpClient("DefaultAPI", cl =>
//{
//    cl.BaseAddress = new Uri("https://localhost:7121/api/");
//    cl.DefaultRequestHeaders.Add("Accept", "application/json");
//});
builder.Services.AddScoped<IStudentService, StudentService>();
await builder.Build().RunAsync();
