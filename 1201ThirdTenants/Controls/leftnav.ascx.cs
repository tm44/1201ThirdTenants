using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _1201ThirdTenants.Controls
{
    public partial class leftnav : System.Web.UI.UserControl
    {
        private string _currentFolder = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string virtualSiteName = String.Empty;// ConfigurationManager.AppSettings["DevSiteName"].ToString();
            string actualRequestPath = Request.Url.AbsolutePath.ToString();//.Replace(virtualSiteName, String.Empty);
            _currentFolder = String.Empty;

            if (actualRequestPath.LastIndexOf("/") > 0 && actualRequestPath.IndexOf("/_admin/whatsnew") == -1)
            {
                _currentFolder = actualRequestPath.Substring(1, actualRequestPath.IndexOf("/", 1) - 1);
                GetSideNav();
            }
        }

        private void GetSideNav()
        {
            BasePage basePage = this.Page as BasePage;

            if (basePage == null)
            {
                return;
            }
            XmlDocument doc = basePage.GetSiteMapDocument();

            // use the translate() function to make a case-insensitive search
            //XmlNodeList subFolders = doc.SelectNodes("/siteMap/siteMapNode/siteMapNode[translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') ='~/" + _currentFolder.ToLower() + "/']/*");
            XmlNodeList subFolders = doc.SelectNodes("/siteMap/siteMapNode/siteMapNode[translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz') ='~/" + _currentFolder.ToLower() + "/']/*");

            foreach (XmlNode node in subFolders)
            {
                Panel pnl = new Panel();
                pnl.CssClass = "sideNavItem";

                HyperLink link = new HyperLink();
                link.Text = node.Attributes["title"].Value;
                link.NavigateUrl = node.Attributes["url"].Value;

                pnl.Controls.Add(link);

                //LiteralControl br = new LiteralControl("<br />");

                //PlaceHolder1.Controls.Add(link);
                PlaceHolder1.Controls.Add(pnl);
            }
        }
    }
}