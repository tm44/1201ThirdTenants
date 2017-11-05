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
            _currentFolder = Request.Url.LocalPath.Split('/')[1];

            GetSideNav();

            //if (actualRequestPath.LastIndexOf("/") == 0)
            //{
            //    _currentFolder = actualRequestPath.Substring(1);
            //    GetSideNav();
            //}
        }

        private void GetSideNav()
        {
            BasePage basePage = this.Page as BasePage;

            if (basePage == null)
                return;

            XmlDocument doc = basePage.GetSiteMapDocument();

            var rootPage = doc.SelectSingleNode(string.Format("/siteMap/siteMapNode[starts-with(translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '~/{0}')]", _currentFolder));
            var subFolders = doc.SelectNodes(string.Format("/siteMap/siteMapNode/siteMapNode[starts-with(translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '~/{0}/')]", _currentFolder));
            

            Panel outerPanel = new Panel();
            outerPanel.ClientIDMode = ClientIDMode.Static;
            outerPanel.ID = "leftNav";

            Panel rootPanel = new Panel();
            rootPanel.CssClass = "leftNavSecondLevel";

            var rootLink = new HyperLink()
            {
                Text = rootPage.Attributes["title"].Value,
                NavigateUrl = rootPage.Attributes["url"].Value
            };

            if (rootLink.NavigateUrl.Replace("~", "").Replace(".aspx", "").Replace("/", "") == Request.CurrentExecutionFilePath.Replace(".aspx", "").Replace("/", "").Replace("default", ""))
                rootPanel.CssClass += " selectedNav";

            rootPanel.Controls.Add(rootLink);

            outerPanel.Controls.Add(rootPanel);

            foreach (XmlNode node in subFolders)
            {
                Panel pnl = new Panel();
                pnl.CssClass = "leftNavSecondLevel";

                HyperLink link = new HyperLink();
                link.Text = node.Attributes["title"].Value;
                link.NavigateUrl = node.Attributes["url"].Value;

                if (link.NavigateUrl.Replace("~", "").Replace(".aspx", "").Replace("/", "") == Request.CurrentExecutionFilePath.Replace(".aspx", "").Replace("/", "").Replace("index", ""))
                    pnl.CssClass += " selectedNav";

                pnl.Controls.Add(link);

                outerPanel.Controls.Add(pnl);
                
            }
            PlaceHolder1.Controls.Add(outerPanel);
        }
    }
}