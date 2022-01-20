using CoreBlog.Business.Abstract;
using CoreBlog.Business.Concrete;
using CoreBlog.Business.ValidationRules;
using CoreBlog.DataAccess.Abstract;
using CoreBlog.DataAccess.Concrete;
using CoreBlog.DataAccess.Context;
using CoreBlog.DataAccess.UnitOfWork;
using CoreBlog.UI.Helpers;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.UI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                                    .RequireAuthenticatedUser()
                                      .Build();
                config.Filters.Add(new AuthorizeFilter(policy));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/Login/Index";
                });



            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("Default"), migration =>
                {
                    migration.MigrationsAssembly("CoreBlog.DataAccess");
                });
            });

            services.AddHttpContextAccessor();

            //Unitofwork

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //Data Access
            services.AddScoped(typeof(IGenericDal<>), typeof(GenericDal<>));
            services.AddScoped<IBlogDal, BlogDal>();
            services.AddScoped<IAboutDal, AboutDal>();
            services.AddScoped<ICategoryDal, CategoryDal>();
            services.AddScoped<ICommentDal, CommentDal>();
            services.AddScoped<IContactDal, ContactDal>();
            services.AddScoped<IWriterDal, WriterDal>();
            services.AddScoped<INewsLetterDal, NewsLetterDal>();
            services.AddScoped<INotificationDal, NotificationDal>();
            services.AddScoped<IMessageDal, MessageDal>();
            services.AddScoped<IMessage2Dal, Message2Dal>();


            //Business
            services.AddScoped(typeof(IGenericService<>), typeof(GenericManager<>));
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<IBlogService, BlogManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<IWriterService, WriterManager>();
            services.AddScoped<INewLetterService, NewsLetterManager>();
            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<INotificationService, NotificationManager>();
            services.AddScoped<IMessageService, MessageManager>();
            services.AddScoped<IMessage2Service, Message2Manager>();


            services.AddScoped<IUserClaimHelpers, UserClaimHelpers>();

            services.AddControllers().AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<WriterValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<ContactValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<BLogValidator>();
            });

            services.AddAutoMapper(typeof(Startup));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?code={0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Writer}/{action=WriterAdd}/{id?}");
            });
        }
    }
}
