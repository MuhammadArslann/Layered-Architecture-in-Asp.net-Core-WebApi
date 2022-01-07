using System;
using System.Collections.Generic;
using System.Security.Claims;
using Applications.AutoMapper;
using Applications.Interfaces;
using Applications.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Persistance.Context;

namespace UnitTesting
{
    public class Fixture
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public ApplicationContext CommandContext { get; private set; }
        public Fixture()
        {
            var services = new ServiceCollection();

            // IOC container
            services.AddDbContextPool<ApplicationContext>(option => option.UseInMemoryDatabase("InMemoryDb"));
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);

            ServiceProvider = services.BuildServiceProvider();
            CommandContext = ServiceProvider.GetService<ApplicationContext>();
            CommandContext.Seed();
            CommandContext.Seeds();
        }
    }
    public static class SeedData
    {
        public static int CompanyId = 1;
        public static void Seed(this ApplicationContext ctx)
        {
            var dummyCompany = new Core.Models.Company { Name = "Seed", Phone = 1, Website = "website" };
            ctx.Company.Add(dummyCompany);
            ctx.SaveChanges();
            CompanyId = dummyCompany.CompanyId;
        }


        public static int Id = 10;
        public static void Seeds(this ApplicationContext ctx)
        {
            var dummyProject = new Core.Models.Projects { Name = "Alter", Code = "12", Description = "This is description!" };
            ctx.Projects.Add(dummyProject);
            ctx.SaveChanges();
            Id = dummyProject.Id;
        }
    }
}
