using System.Web;
using System.Web.Caching;
using System.Web.UI;
using System.Xml;

namespace _1201ThirdTenants
{
    public class BasePage : Page
    {
        public BasePage()
        {
            //Page.EnableViewState = false;
        }

        public XmlDocument GetSiteMapDocument()
        {
            XmlDocument doc = (XmlDocument)HttpRuntime.Cache["SiteMap"];
            if (doc == null)
            {
                doc = new XmlDocument();
                doc.Load(Server.MapPath("~/web.sitemap"));

                CacheDependency dep = new CacheDependency(Server.MapPath("~/web.sitemap"));
                HttpRuntime.Cache.Insert("SiteMap", doc, dep);
            }

            return doc;
        }
    }
}