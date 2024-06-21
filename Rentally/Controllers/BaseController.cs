using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Rentally.WEB.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (User.Identity.IsAuthenticated)
            {
                var imageUrl = User.Claims.FirstOrDefault(c => c.Type == "ImageUrl")?.Value;
                ViewData["UserImageUrl"] = imageUrl;
            }
        }
    }
}
