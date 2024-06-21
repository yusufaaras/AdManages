using AdManageWeb.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AdManage.Application.Features.CQRS.Handlers;
using AdManage.Application.Interfaces;
using AdManage.Persistence.DbContexts;
using AdManage.Persistence.Repositories;
using AdManage.Domain.Entities;
using AdManageWeb.Models;
using AdManage.Application.Services;
using AdManage.Persistence.Factories;
using AdManage.Application.Adapters;
using AdManage.Persistence.Decorators;
using AdManage.Persistence.Strategies;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using AdManage.Persistence.Real_Time_Communication;

namespace AdManageWeb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // DbContext'i ekleyin
            builder.Services.AddDbContext<AdManageDbContext>();

			builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<AdManageDbContext>().AddErrorDescriber<CustomIdentityValidator>().AddEntityFrameworkStores<AdManageDbContext>();


			// Diğer servisleri ekleyin
			builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .SetIsOriginAllowed((host) => true)
                        .AllowCredentials();
                });
            });
            builder.Services.AddSignalR();

            // Repository ve Handler'ları ekleyin
            builder.Services.AddScoped<AdManageDbContext>();
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped(typeof(IBronzeRepository), typeof(BronzeRepository));

            builder.Services.AddScoped<GetBronzeQueryHandler>();
            builder.Services.AddScoped<GetBronzeByIdQueryHandler>();
            builder.Services.AddScoped<CreateBronzeCommandHandler>();
            builder.Services.AddScoped<UpdateBronzeCommandHandler>();
            builder.Services.AddScoped<RemoveBronzeCommandHandler>();

            builder.Services.AddTransient<MsSqlBronzeRepository>();
            builder.Services.AddTransient<IBronzeRepository, MsSqlBronzeRepositoryAdapter>();
            builder.Services.AddTransient<MsSqlBronzeRepositoryAdapter>();
            builder.Services.AddTransient<IBronzeRepository>(serviceProvider =>
            {
                var inner = serviceProvider.GetRequiredService<MsSqlBronzeRepositoryAdapter>();
                var logger = serviceProvider.GetRequiredService<ILogger<BronzeRepositoryWithLogging>>();
                return new BronzeRepositoryWithLogging(inner, logger);
            });


            builder.Services.AddScoped(typeof(IGoldRepository), typeof(GoldRepository));

            builder.Services.AddScoped<GetGoldQueryHandler>();
            builder.Services.AddScoped<GetGoldByIdQueryHandler>();
            builder.Services.AddScoped<CreateGoldCommandHandler>();
            builder.Services.AddScoped<UpdateGoldCommandHandler>();
            builder.Services.AddScoped<RemoveGoldCommandHandler>();
            builder.Services.AddTransient<IRepositoryFactory, RepositoryFactory>();
            builder.Services.AddTransient<IAdManagementService, AdManagementService>();
            
            builder.Services.AddScoped(typeof(ISilverRepository), typeof(SilverRepository));

            builder.Services.AddScoped<GetSilverQueryHandler>();
            builder.Services.AddScoped<GetSilverByIdQueryHandler>();
            builder.Services.AddScoped<CreateSilverCommandHandler>();
            builder.Services.AddScoped<UpdateSilverCommandHandler>();
            builder.Services.AddScoped<RemoveSilverCommandHandler>();

            builder.Services.AddScoped<ISilverPackagesStrategy, DefaultSilverPackagesStrategy>();
            builder.Services.AddScoped<ISilverPackagesStrategy, SpecialOfferSilverPackagesStrategy>();
            builder.Services.AddScoped<GetSilverQueryHandler>();

            builder.Services.AddScoped(typeof(IReservationRepository), typeof(ReservationRepository));

            builder.Services.AddScoped<GetReservationQueryHandler>();
            builder.Services.AddScoped<GetReservationByIdQueryHandler>();
            builder.Services.AddScoped<CreateReservationCommandHandler>();

            var app = builder.Build();

            // Middleware'leri yapılandırın
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
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

            // Endpoint'leri eşleştirin
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllerRoute(
                  name: "UserProcedures",
                  pattern: "{area:exists}/{controller=Login}/{action=Login}/{id?}");
            });
            

            app.MapHub<AdvertisementsHub>("/AdManageWebHub");

            //app.MapRazorPages();

            app.Run();

        }
    }

}
