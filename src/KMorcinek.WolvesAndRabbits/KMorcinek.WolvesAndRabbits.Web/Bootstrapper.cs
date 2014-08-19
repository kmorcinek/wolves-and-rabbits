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
		}
	}
}