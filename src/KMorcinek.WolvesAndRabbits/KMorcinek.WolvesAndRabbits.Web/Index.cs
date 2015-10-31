using System.Web.Optimization;
using Nancy;

namespace KMorcinek.WolvesAndRabbits.Web
{
    public class Index : NancyModule
    {
        public Index()
        {
            Get["/"] = _ => View["Index", new
            {
                Styles = Styles.Render("~/Content/Styles/styles.css").ToString(),
                BundledVendorScripts = Scripts.Render("~/Scripts/bundleVendorScripts.js").ToString(),
                BundledScripts = Scripts.Render("~/Scripts/bundledJs.js").ToString(),
            }];
        }
    }
}