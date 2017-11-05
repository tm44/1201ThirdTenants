using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _1201ThirdTenants.Controls
{
    public partial class topnav : System.Web.UI.UserControl
    {
        private string _currentFolder = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string virtualSiteName = String.Empty;// ConfigurationManager.AppSettings["DevSiteName"].ToString();
            string actualRequestPath = Request.Url.AbsolutePath.ToString();//.Replace(virtualSiteName, String.Empty);
            _currentFolder = Request.Url.LocalPath.Split('/')[1];

            GetTopNav();
        }

        private void GetTopNav()
        {
            BasePage basePage = this.Page as BasePage;

            if (basePage == null)
                return;

            XmlDocument doc = basePage.GetSiteMapDocument();

            StringBuilder sb = new StringBuilder();

            sb.Append("<ul class=\"sm sm-clean\" id=\"main-menu\">");

            foreach (XmlNode topNode in doc.SelectNodes("/siteMap/siteMapNode"))
            {
                //var isActive = topNode.Attributes["url"].Value.Replace("~", "").Replace(".aspx", "").Replace("/", "") == Request.CurrentExecutionFilePath.Replace(".aspx", "").Replace("/", "").Replace("default", "");

                sb.AppendFormat("<li><a href=\"{0}\">{1}</a>", topNode.Attributes["url"].Value.Replace("~", ""), topNode.Attributes["title"].Value);
                if (!topNode.HasChildNodes)
                {
                    sb.Append("</li>");
                    continue;
                }
                sb.Append("<ul>");
                foreach (XmlNode secondLevel in topNode.ChildNodes)
                {
                    sb.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", secondLevel.Attributes["url"].Value.Replace("~",""), secondLevel.Attributes["title"].Value);
                }
                sb.Append("</ul></li>");
            }
            sb.Append("</ul>");
            MenuPlaceholder.Controls.Add(new LiteralControl(sb.ToString()));
        }

    }
}