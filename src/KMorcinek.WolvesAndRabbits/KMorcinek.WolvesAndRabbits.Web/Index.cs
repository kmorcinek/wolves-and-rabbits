using Nancy;

namespace KMorcinek.WolvesAndRabbits.Web
{
	public class Index : NancyModule
	{
		public Index()
		{
			Get["/"] = _ => View["Index"];
		}
	}
}