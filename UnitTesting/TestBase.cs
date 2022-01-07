using Microsoft.Extensions.DependencyInjection;
using Persistance.Context;
using Xunit;

namespace UnitTesting
{
    public class TestBase : IClassFixture<Fixture>
    {
        protected ServiceProvider Services; // IOC container to get the required service
        protected ApplicationContext CommandContext { get; private set; } // Unit of work
        protected TestBase(Fixture fixture)
        {
            Services = fixture.ServiceProvider;
            CommandContext = Services.GetService<ApplicationContext>();
        }
        public static void Destroy(ApplicationContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
