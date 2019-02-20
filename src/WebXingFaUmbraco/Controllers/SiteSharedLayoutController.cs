using System.Collections.Generic;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Mvc;
using WebXingFaUmbraco.Models;
namespace WebXingFaUmbraco.Controllers
{
    public class SiteSharedLayoutController : SurfaceController
    {
        private const string PATH_PARTIAL_VIEW = "~/Views/Partials/SharedLayout";
        // GET: SiteSharedLayout
        public ActionResult RenderHeader()
        {
            var nav = GetsNavigation();
            return PartialView($"{PATH_PARTIAL_VIEW}/Header.cshtml", nav);
        }
        public ActionResult RenderFooter()
        {
            return PartialView($"{PATH_PARTIAL_VIEW}/Footer.cshtml");
        }

        private List<Navigation.NavigationList> GetsNavigation()
        {
            int pageId = int.Parse(CurrentPage.Path.Split(',')[1]);
            IPublishedContent pageInfo = Umbraco.Content(pageId);
            var nav = new List<Navigation.NavigationList>
            {
                new Navigation.NavigationList(new Navigation.NavigationLinkInfo(pageInfo.Name,pageInfo.Url))
            };
            nav.AddRange(GetsSubNavigation(pageInfo));
            return nav;
        }

        private List<Navigation.NavigationList> GetsSubNavigation(dynamic page)
        {
            var navList = new List<Navigation.NavigationList>();
            var subPages = page.Children.Where("Visible");
            if (subPages.Any())
            {
                foreach (var subPage in subPages.ToList())
                {
                    var navListItem = new Navigation.NavigationList(new Navigation.NavigationLinkInfo(subPage.Name, subPage.Url))
                    {
                        NavItems = GetsSubNavigation(subPage)
                    };
                    navList.Add(navListItem);
                }
            }
            return navList;
        }
    }
}