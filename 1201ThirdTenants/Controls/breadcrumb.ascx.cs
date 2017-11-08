using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace _1201ThirdTenants.Controls
{
    public partial class breadcrumb : System.Web.UI.UserControl
    {
        private string _currentFolder = String.Empty;
        private string _currentPage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            string virtualSiteName = String.Empty;// ConfigurationManager.AppSettings["DevSiteName"].ToString();
            string actualRequestPath = Request.Url.AbsolutePath.ToString();//.Replace(virtualSiteName, String.Empty);
            var requestArray = Request.Url.LocalPath.Split('/');

            _currentFolder = Request.Url.LocalPath.Split('/')[1];
            if (requestArray.Length > 2)
                _currentPage = requestArray[2];

            GetBreadcrumb();
        }

        private void GetBreadcrumb()
        {
            BasePage basePage = this.Page as BasePage;

            if (basePage == null)
                return;

            XmlDocument doc = basePage.GetSiteMapDocument();

            var rootPage = doc.SelectSingleNode(string.Format("/siteMap/siteMapNode[starts-with(translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '~/{0}')]", _currentFolder));

            var isRootPage = Request.Url.LocalPath.ToLower().EndsWith("default.aspx");
            if (isRootPage)
            {
                Placeholder1.Controls.Add(new LiteralControl(rootPage.Attributes["title"].Value));
                return;
            }
            else
                Placeholder1.Controls.Add(new LiteralControl($"<a href=\"{rootPage.Attributes["url"].Value.Replace("~", string.Empty)}\">{rootPage.Attributes["title"].Value}</a> /// "));

            var currentNode = doc.SelectSingleNode($"/siteMap/siteMapNode/siteMapNode[contains(translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '{_currentPage.ToLower()}')]");

            if (currentNode != null)
            {
                if (!currentNode.HasChildNodes || Request.Url.Segments.Length < 4)
                    Placeholder1.Controls.Add(new LiteralControl(currentNode.Attributes["title"].Value));
                else
                {
                    Placeholder1.Controls.Add(new LiteralControl($"<a href=\"{currentNode.Attributes["url"].Value.Replace("~", string.Empty)}\">{currentNode.Attributes["title"].Value}</a> /// "));
                    var currentLowestLevelNode = doc.SelectSingleNode($"/siteMap/siteMapNode/siteMapNode/siteMapNode[contains(translate(@url, 'ABCDEFGHIJKLMNOPQRSTUVWXYZ', 'abcdefghijklmnopqrstuvwxyz'), '/{Request.Url.Segments[3]}')]");
                    if (currentLowestLevelNode != null)
                        Placeholder1.Controls.Add(new LiteralControl(currentLowestLevelNode.Attributes["title"].Value));
                }
            }


        }
    }
}