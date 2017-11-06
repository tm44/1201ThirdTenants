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
        }

        private void GetSideNav()
        {
            BasePage basePage = this.Page as BasePage;

            if (basePage == null)
                return;

            XmlDocument doc = basePage.GetSiteMapDocument();

            var rootPage = doc.SelectSingleNode(string.Format("/siteMap/siteMapNode[starts-with(translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '~/{0}')]", _currentFolder));
            var subFolders = doc.SelectNodes(string.Format("/siteMap/siteMapNode/siteMapNode[starts-with(translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '~/{0}/')]", _currentFolder));
            var subSubFolders = doc.SelectNodes(string.Format("/siteMap/siteMapNode/siteMapNode[starts-with(translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '~/{0}/')]/*", _currentFolder));


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

            if (CleanUrl(rootLink.NavigateUrl) == CleanCurrentPath())
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

                if (CleanUrl(link.NavigateUrl) == CleanCurrentPath())
                    pnl.CssClass += " selectedNav";

                pnl.Controls.Add(link);

                outerPanel.Controls.Add(pnl);

                if (node.HasChildNodes)
                {
                    Panel level3container = new Panel();
                    level3container.CssClass = "leftNavThirdLevel selectedSubNav";

                    foreach (XmlNode thirdLevelNode in node.ChildNodes)
                    {
                        Panel level3pnl = new Panel();
                        //level3pnl.CssClass = "leftNavThirdLevel";

                        HyperLink level3link = new HyperLink();
                        level3link.Text = thirdLevelNode.Attributes["title"].Value;
                        level3link.NavigateUrl = thirdLevelNode.Attributes["url"].Value;

                        if (CleanUrl(level3link.NavigateUrl) == CleanCurrentPath())
                            level3pnl.CssClass += " thirdLevelSelectedLink";


                        level3pnl.Controls.Add(level3link);
                        level3container.Controls.Add(level3pnl);
                        outerPanel.Controls.Add(level3container);
                    }
                }
                
            }
            PlaceHolder1.Controls.Add(outerPanel);
        }

        private string CleanCurrentPath()
        {
            return Request.CurrentExecutionFilePath.Replace(".aspx", "").Replace("/", "").Replace("default", "");
        }

        private string CleanUrl(string url)
        {
            return url.Replace("~", "").Replace(".aspx", "").Replace("/", "");
        }
    }
}