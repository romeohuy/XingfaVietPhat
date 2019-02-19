using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace WebXingFaUmbraco.Controllers
{
    public class HomeController : SurfaceController
    {
        private const string PATH_PARTIAL_VIEW = "~/Views/Partials/Home";
        // GET: Home
        public ActionResult RenderSliderImage()
        {
            return PartialView($"{PATH_PARTIAL_VIEW}/SliderImage.cshtml");
        }
    }
}