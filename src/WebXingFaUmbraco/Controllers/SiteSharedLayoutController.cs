using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace WebXingFaUmbraco.Controllers
{
    public class SiteSharedLayoutController : SurfaceController
    {
        private const string PATH_PARTIAL_VIEW = "~/Views/Partials/SharedLayout";
        // GET: SiteSharedLayout
        public ActionResult RenderHeader()
        {
            return PartialView($"{PATH_PARTIAL_VIEW}/Header.cshtml");
        }
        public ActionResult RenderFooter()
        {
            return PartialView($"{PATH_PARTIAL_VIEW}/Footer.cshtml");
        }
    }
}