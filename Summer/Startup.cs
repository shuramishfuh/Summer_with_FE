using Hangfire;
using Hangfire.Common;
using Microsoft.Owin;
using Owin;
using Summer.Function;

[assembly: OwinStartupAttribute(typeof(Summer.Startup))]
namespace Summer
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("DefaultConnection");
            app.UseHangfireDashboard();
            app.UseHangfireServer();
            //updates codes
            var manager = new RecurringJobManager();
            var codes = new PopulateCodes();
            manager.AddOrUpdate("Codes", Job.FromExpression(() => codes.UpdatingCodes()), Cron.Hourly()); // schedule task using hangfire
            codes.Statics();
            ConfigureAuth(app);

        }
    }
}
