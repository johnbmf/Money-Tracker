using Microsoft.EntityFrameworkCore;
using Money_Tracker.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddDbContext<AppDbContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mgo+DSMBaFt/QHRqVVhkVFpFdEBBXHxAd1p/VWJYdVt5flBPcDwsT3RfQF5jSn9VdkRgWXped3FSRQ==;Mgo+DSMBPh8sVXJ0S0J+XE9AflRDX3xKf0x/TGpQb19xflBPallYVBYiSV9jS31TdURlWX5dcHFVQWdeUg==;ORg4AjUWIQA/Gnt2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkZiX39fc3RQRmdUWEc=;MTM0MTczNkAzMjMwMmUzNDJlMzBLOTVhVm4yQ3lFNllKSzJWZU1DZktGczQ0SERPUHdodXlvdGZ4MzZwdFdZPQ==;MTM0MTczN0AzMjMwMmUzNDJlMzBrNGx0U1NNNmx4VU1sTCtnWFMrZDJyY05MdE56ZnVpWExpNFlNRDFHZVdJPQ==;NRAiBiAaIQQuGjN/V0Z+WE9EaFtKVmJLYVB3WmpQdldgdVRMZVVbQX9PIiBoS35RdUVgWHlecXdVQ2BUV0Z1;MTM0MTczOUAzMjMwMmUzNDJlMzBTU1FIZERGZEN5QVQxNURFTWo2eThFTklQempNWG1pQ0dWTC9FWU9Yd3ZjPQ==;MTM0MTc0MEAzMjMwMmUzNDJlMzBQdzdxQkc3Vms3VnFzQ3Z4SUo3bGVRT3dpN1RoY0VKWFdvUmU0cjdlc1RzPQ==;Mgo+DSMBMAY9C3t2VVhkQlFacldJXGFWfVJpTGpQdk5xdV9DaVZUTWY/P1ZhSXxQdkZiX39fc3RQRmlYUUc=;MTM0MTc0MkAzMjMwMmUzNDJlMzBEUVd6WnhlTE9JSkMzekZYdnRJalpDQ3dHZVJNT0JyanNPSURpZWlQNjZVPQ==;MTM0MTc0M0AzMjMwMmUzNDJlMzBTeTV0ZHUvZ0MvS0g3TnBqclh6b1c5cG5tZHcyZnlHeVFLWUFBQWgrY25zPQ==;MTM0MTc0NEAzMjMwMmUzNDJlMzBTU1FIZERGZEN5QVQxNURFTWo2eThFTklQempNWG1pQ0dWTC9FWU9Yd3ZjPQ==");

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
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
