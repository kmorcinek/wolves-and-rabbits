using System.Web.Optimization;
using System.Web.Routing;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.Session;
using Nancy.TinyIoc;

namespace KMorcinek.WolvesAndRabbits.Web
{
	public class Bootstrapper : DefaultNancyBootstrapper
	{
		protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
		{
			base.ApplicationStartup(container, pipelines);
			this.Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("Scripts"));
			this.Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("app"));
			this.Conventions.StaticContentsConventions.Add(StaticContentConventionBuilder.AddDirectory("signalr"));
			CookieBasedSessions.Enable(pipelines);
			RouteTable.Routes.MapHubs();

            ConfigureBundles();
        }

        private void ConfigureBundles()
        {
            BundleTable.Bundles.Add(new Bundle("~/Content/Styles/styles.css")
                .Include("~/Content/Styles/reset.css")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/Styles/main.css")
            );

            BundleTable.Bundles.Add(new Bundle("~/Scripts/bundleVendorScripts.js")
                .Include("~/Scripts/jquery-2.0.0.min.js")
                .Include("~/Scripts/angular.min.js")
                .Include("~/scripts/jquery.signalR-1.1.1.min.js")
            );

            // Files that are included explicitly contain module definition
            // and need to be on the top
            BundleTable.Bundles.Add(new Bundle("~/Scripts/bundledJs.js")
                .Include("~/app/app.js")
                .IncludeDirectory("~/app", "*.js", true)
            );
        }

	}
}