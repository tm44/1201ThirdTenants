<%@ Register Src="~/Controls/topnav.ascx" TagPrefix="uc1" TagName="topnav" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>1201 Third Tenants</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <link href="Content/sm-core-css.css" rel="stylesheet" />
    <link href="Content/sm-clean.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
    <style>
        #main-menu {
            border-bottom: none;
        }
    </style>
</head>
<body>
    <div class="container">
        <div class="row header">
            <div class="col-md-3" style="padding-left: 0;">
                <img src="Images/logo.png" class="img-responsiveXXX" height="22" width="475" alt="1201 Third Avenue" />
            </div>
            <div class="col-md-4 pull-right hidden-xs" style="font-size: .9em">
                <span id="phone">206-224-1201</span>
                <input type="text" id="searchbox" name="search" />
                <input type="image" src="/images/search.gif" height="16" width="61" alt="Search" id="search">
            </div>
        </div>
        <div class="row">
            <div class="col-sm-10 col-sm-offset-2">
                <nav style="margin-right: 29px;">
                    <uc1:topnav runat="server" ID="topnavcontrol" />
                </nav>
            </div>
        </div>

        <div class="row" style="background-image: url(/images/1201_home.jpg); background-size: 100% auto; height: 404px; background-repeat: no-repeat;">
            <div style="position: relative; top: 0; left: 0; color: white;">
                <img src="Images/quicklinks.png" width="172" height="29" alt="Quick Links" id="whatsNewImg" />
                <div class="whatsNew">
                    <div><a href="/media/14628/1201_third_tenant_newsletter_10-2017.pdf" target="_blank">October Newsletter</a></div>
                    <div><a href="/media/31521/1201_third_tenant_newsletter_09-2017.pdf" target="_blank">September Newsletter</a></div>
                    <div style="background: none;">
                        <a href="/media/31220/1201_third_tenant_newsletter_08-2017.pdf" target="_blank">August Newsletter</a>
                    </div>
                </div>
                <div id="banner" class="hidden-xs"></div>
            </div>
        </div>
        <div class="row hidden-xs">
            <footer class="pull-right">
                <a href="http://www.wrightrunstad.com" target="_blank">
                    <img src="/images/wrc_logo.jpg" width="214" height="13" alt="Wright Runstad &amp; Company" id="wrc_logo"></a>
                Copyright &copy <%=System.DateTime.Now.Year %>
            </footer>
        </div>
    </div>
    <!-- SmartMenus jQuery plugin -->
    <%--    <script type="text/javascript" src="../jquery.smartmenus.js"></script>

    <!-- SmartMenus jQuery Bootstrap Addon -->
    <script type="text/javascript" src="../addons/bootstrap/jquery.smartmenus.bootstrap.js"></script>--%>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script src="Scripts/jquery.smartmenus.min.js"></script>
    <script>
        $(function () {
            $('#main-menu').smartmenus();
            var $mainMenuState = $('#main-menu-state');
            if ($mainMenuState.length) {
                // animate mobile menu
                $mainMenuState.change(function (e) {
                    var $menu = $('#main-menu');
                    if (this.checked) {
                        $menu.hide().slideDown(250, function () { $menu.css('display', ''); });
                    } else {
                        $menu.show().slideUp(250, function () { $menu.css('display', ''); });
                    }
                });
                // hide mobile menu beforeunload
                $(window).on('beforeunload unload', function () {
                    if ($mainMenuState[0].checked) {
                        $mainMenuState[0].click();
                    }
                });
            }
        });
    </script>
</body>
</html>
